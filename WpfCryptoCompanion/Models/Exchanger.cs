using Newtonsoft.Json;

namespace WpfCryptoCompanion.Models
{
	public class Exchanger
	{
		[JsonProperty("exchangeId")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("volumeUsd")]
		public float? VolumeUsd { get; set; }
	}
}