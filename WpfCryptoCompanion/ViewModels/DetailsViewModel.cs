using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WpfCryptoCompanion.Models;
using WpfCryptoCompanion.Services;

namespace WpfCryptoCompanion.ViewModels
{
	public class DetailsViewModel : BaseViewModel
	{
		private readonly ApiHandler _apiHandler = new();
		private ObservableCollection<PairByCoin> _pairs;

		public NavigationBarViewModel NavigationBarViewModel { get; }

		public Coin Coin { get; set; }
		public string CoinName => $"{Coin.Name} ({Coin.Symbol})";
		public ObservableCollection<PairByCoin> Pairs
		{
			get => _pairs;
			set
			{
				_pairs = value;
				OnPropertyChanged(nameof(Pairs));
			}
		}

        public DetailsViewModel(NavigationBarViewModel naviBarViewModel, Coin coin)
        {
			NavigationBarViewModel = naviBarViewModel;

			Pairs = new();

            Coin = coin;
			InitPairs(Coin);
        }

		private async void InitPairs(Coin? coin)
		{
			await LoadPairsAsync(coin);
		}

		private async Task LoadPairsAsync(Coin? coin)
		{
			Pairs.Clear();
			var pairs = await _apiHandler.GetExchangersAsync(coin);
			foreach (PairByCoin pair in pairs)
			{
				Pairs.Add(pair);
			}
		}
    }
}