using Newtonsoft.Json;

namespace WpfCryptoCompanion.Models
{
	public class Pair
	{
		public string PairName => $"{BaseSymbol}/{QuoteSymbol}";

		[JsonProperty("baseSymbol")]
		public string BaseSymbol { get; set; }

		[JsonProperty("exchangeId")]
		public virtual string ExchangeId { get; set; }

		[JsonProperty("priceUsd")]
		public float PriceUsd { get; set; }

		[JsonProperty("quoteSymbol")]
		public string QuoteSymbol { get; set; }

		[JsonProperty("volumeUsd24Hr")]
		public float VolumeUsd { get; set; }
	}
}