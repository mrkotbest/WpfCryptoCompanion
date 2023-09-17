using Newtonsoft.Json;

namespace WpfCryptoCompanion.Models
{
	public class Coin
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("rank")]
		public short Rank { get; set; }

		[JsonProperty("priceUsd")]
		public float? Price { get; set; }

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("supply")]
		public float? Supply { get; set; }

		[JsonProperty("marketCapUsd")]
		public float? MarketCapUsd { get; set; }

		[JsonProperty("volumeUsd24Hr")]
		public float? VolumeUsd { get; set; }

		[JsonProperty("changePercent24Hr")]
		public float? ChangePercent { get; set; }

		[JsonProperty("vwap24Hr")]
		public float? Vwap { get; set; }
	}
}