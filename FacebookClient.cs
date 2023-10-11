using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FacebookDotNet
{
	public interface IFacebookClient
	{
		Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);
		Task PostAsync(string accessToken, string endpoint, object data, string args = null);
	}

	public class FacebookClient : IFacebookClient
	{
		private readonly HttpClient _httpClient;

		public FacebookClient()
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://graph.facebook.com/v18.0/")
			};
			_httpClient.DefaultRequestHeaders
				.Accept
				.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
		{
			//endpoint example:accountId?fields=events
			//args example: {updated_time,category,cover,description,end_time,event_times,id,is_canceled,is_draft,is_page_owned,name,place,start_time,type}
			//full url example: https://graph.facebook.com/v18.0/yourAccountId?fields=events{category,updated_time,cover,description,end_time,event_times,id,is_canceled,is_draft,is_page_owned,name,place,start_time,type}&access_token=yourAccessToken"

			var response = await _httpClient.GetAsync($"{endpoint}{args}&access_token={accessToken}");
			if (!response.IsSuccessStatusCode)
			{
				throw new Exception($"{(int)response.StatusCode} {response.ReasonPhrase} {await response.Content.ReadAsStringAsync()}");
			}

			var result = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(result);
		}

		public async Task PostAsync(string accessToken, string endpoint, object data, string args = null)
		{
			var payload = GetPayload(data);
			await _httpClient.PostAsync($"{endpoint}?access_token={accessToken}&{args}", payload);
		}

		private static StringContent GetPayload(object data)
		{
			var json = JsonConvert.SerializeObject(data);

			return new StringContent(json, Encoding.UTF8, "application/json");
		}
	}
}
