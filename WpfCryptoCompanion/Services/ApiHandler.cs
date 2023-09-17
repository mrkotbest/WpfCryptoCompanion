using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WpfCryptoCompanion.Models;

namespace WpfCryptoCompanion.Services
{
	public class ApiHandler
	{
		private const string GET_COINS_DATA_URL = "https://api.coincap.io/v2/assets";

		public async Task<IEnumerable<Coin>> GetCoinsAsync()
		{
			try
			{
				HttpClient client = new();
				string apiUrl = $"{GET_COINS_DATA_URL}?limit=1000";

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				var json = await response.Content.ReadAsStringAsync();
				var root = JsonConvert.DeserializeObject<RootService<Coin[]>>(json);

				return root.Data;
			}
			catch (HttpRequestException ex)
			{
				Debug.WriteLine($"HTTP Request Error: {ex.Message}");
				return Enumerable.Empty<Coin>();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error: {ex.Message}");
				return Enumerable.Empty<Coin>();
			}
		}

		public async Task<IEnumerable<PairByCoin>> GetExchangersAsync(Coin? coin)
		{
			try
			{
				HttpClient client = new();
				string apiUrl = $"{GET_COINS_DATA_URL}/{coin.Id}/markets";

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				var json = await response.Content.ReadAsStringAsync();
				var root = JsonConvert.DeserializeObject<RootService<PairByCoin[]>>(json);

				return root.Data;
			}
			catch (HttpRequestException ex)
			{
				Debug.WriteLine($"HTTP Request Error: {ex.Message}");
				return Enumerable.Empty<PairByCoin>();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error: {ex.Message}");
				return Enumerable.Empty<PairByCoin>();
			}
		}
	}
}