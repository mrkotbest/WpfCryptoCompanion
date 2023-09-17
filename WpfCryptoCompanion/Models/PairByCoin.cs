using Newtonsoft.Json;

namespace WpfCryptoCompanion.Models
{
	public class PairByCoin : Pair
	{
		[JsonProperty("exchangeId")]
		public override string ExchangeId { get; set; }
	}
}