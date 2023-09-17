using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfCryptoCompanion.Models;
using WpfCryptoCompanion.Services;

namespace WpfCryptoCompanion.ViewModels
{
	public class DetailsViewModel : BaseViewModel
	{
		private readonly ApiHandler _apiHandler = new();
		private List<PairByCoin> _pairs = new();

		private Coin _coin;

		public ICollectionView PairsView => CollectionViewSource.GetDefaultView(_pairs);

		public string CoinName => $"{Coin.Name} ({Coin.Symbol})";
		public Coin Coin
		{
			get => _coin;
			set
			{
				_coin = value;
				OnPropertyChanged(nameof(Coin));
			}
		}

        public DetailsViewModel(Coin coin)
        {
            Coin = coin;
			InitPairs(Coin);
        }

		private async void InitPairs(Coin? coin)
		{
			await LoadPairsAsync(coin);
		}

		private async Task LoadPairsAsync(Coin? coin)
		{
			_pairs.Clear();
			var pairs = await _apiHandler.GetExchangersAsync(coin);
			foreach (PairByCoin pair in pairs)
			{
				_pairs.Add(pair);
			}
		}
    }
}