using Newtonsoft.Json;
using PheggCore.Website;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore
{
	public static class WebRequests
	{
		public async static Task<HttpResponseMessage> Get(string Url)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(Url);

					return await client.GetAsync(client.BaseAddress);
				}
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
				return null;
			}
		}
		public async static Task<HttpResponseMessage> Get(string Url, Dictionary<string, string> Headers)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(Url);
					if (Headers != null)
						foreach (var header in Headers)
							client.DefaultRequestHeaders.Add(header.Key, header.Value);

					HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

					if (Settings.Debug)
						Logger.Write($"{response.StatusCode} " + await response.Content.ReadAsStringAsync());

					return response;
				}
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
				return null;
			}
		}

		public async static Task<HttpResponseMessage> Delete(string Url)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(Url);

					return await client.DeleteAsync(client.BaseAddress);
				}
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
				return null;
			}
		}
		public async static Task<HttpResponseMessage> Delete(string Url, Dictionary<string, string> Headers)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(Url);
					if (Headers != null)
						foreach (var header in Headers)
							client.DefaultRequestHeaders.Add(header.Key, header.Value);


					var response = await client.DeleteAsync(client.BaseAddress);

					if (Settings.Debug)
						Logger.Write($"{response.StatusCode} " + await response.Content.ReadAsStringAsync());

					return response;
				}
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
				return null;
			}
		}

		public async static Task<HttpResponseMessage> Post(string Url, StringContent Content)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(Url);


					return await client.PostAsync(client.BaseAddress, Content);
				}
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
				return null;
			}
		}
		public async static Task<HttpResponseMessage> Post(string Url, Dictionary<string, string> Headers, StringContent Content)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(Url);
					if (Headers != null)
						foreach (var header in Headers)
							client.DefaultRequestHeaders.Add(header.Key, header.Value);

					var response = await client.PostAsync(client.BaseAddress, Content);

					if (Settings.Debug)
						Logger.Write($"{response.StatusCode} " + await response.Content.ReadAsStringAsync());

					return response;
				}
			}
			catch (Exception e)
			{
				Logger.Write(e.ToString(), Logger.MessageSeverity.Error);
				return null;
			}
		}
	}
}
