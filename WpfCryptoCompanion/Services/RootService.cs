using Newtonsoft.Json;

namespace WpfCryptoCompanion.Services
{
	public class RootService<T>
	{
		[JsonProperty("data")]
		public T Data { get; set; }
	}
}