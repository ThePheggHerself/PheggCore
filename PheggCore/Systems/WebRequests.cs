using Newtonsoft.Json;
using PheggCore.Website.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Systems
{
	public static class WebRequests
	{
		public async static Task<HttpResponseMessage> Get(string Url)
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(Url);

				return await client.GetAsync(client.BaseAddress);
			}
		}
		public async static Task<APIResponse> Get(string Url, Dictionary<string, string> Headers)
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(Url);
				if (Headers != null)
					foreach (var header in Headers)
						client.DefaultRequestHeaders.Add(header.Key, header.Value);

				var response = await client.GetAsync(client.BaseAddress);

				if (Core.Debug)
					Console.WriteLine(await response.Content.ReadAsStringAsync());

				return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
			}
		}

		public async static Task<HttpResponseMessage> Delete(string Url)
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(Url);

				return await client.DeleteAsync(client.BaseAddress);
			}
		}
		public async static Task<APIResponse> Delete(string Url, Dictionary<string, string> Headers)
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(Url);
				if (Headers != null)
					foreach (var header in Headers)
						client.DefaultRequestHeaders.Add(header.Key, header.Value);


				var response = await client.DeleteAsync(client.BaseAddress);

				if (Core.Debug)
					Console.WriteLine(await response.Content.ReadAsStringAsync());

				return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
			}
		}

		public async static Task<HttpResponseMessage> Post(string Url, StringContent Content)
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(Url);


				return await client.PostAsync(client.BaseAddress, Content);
			}
		}
		public async static Task<APIResponse> Post(string Url, Dictionary<string, string> Headers, StringContent Content)
		{
			using (HttpClient client = new HttpClient())
			{
				Debug.Print(JsonConvert.SerializeObject(Content.ReadAsStringAsync()));

				client.BaseAddress = new Uri(Url);
				if (Headers != null)
					foreach (var header in Headers)
						client.DefaultRequestHeaders.Add(header.Key, header.Value);

				var response = await client.PostAsync(client.BaseAddress, Content);

				if (Core.Debug)
					Console.WriteLine(await response.Content.ReadAsStringAsync());

				return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
			}
		}
	}
}
