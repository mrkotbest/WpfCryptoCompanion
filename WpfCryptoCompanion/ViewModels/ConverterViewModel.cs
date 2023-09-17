using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpfCryptoCompanion.Models;
using WpfCryptoCompanion.Services;

namespace WpfCryptoCompanion.ViewModels
{
	public class ConverterViewModel : BaseViewModel
	{
		private readonly ApiHandler _apiHandler = new();

		private IEnumerable<Coin> _coins;
		private Coin _firstCoin;
		private Coin _secondCoin;
		private float _firstAmount = 1;
		private string _firstAmountText = "1";

		public NavigationBarViewModel NavigationBarViewModel { get; }

		public IEnumerable<Coin> Coins
		{
			get => _coins;
			set
			{
				_coins = value;
				OnPropertyChanged(nameof(Coins));
			}
		}
		public Coin FirstCoin
		{
			get => _firstCoin;
			set
			{
				if (value != null)
				{
					_firstCoin = value;
					OnPropertyChanged(nameof(FirstCoin));
					OnPropertyChanged(nameof(SecondAmount));
				}
			}
		}
		public Coin SecondCoin
		{
			get => _secondCoin;
			set
			{
				if (value != null)
				{
					_secondCoin = value;
					OnPropertyChanged(nameof(SecondCoin));
					OnPropertyChanged(nameof(SecondAmount));
				}
			}
		}
		public float FirstAmount
		{
			get => _firstAmount;
			set
			{
				_firstAmount = value;
				OnPropertyChanged(nameof(SecondAmount));
			}
		}
		public string FirstAmountText
		{
			get => _firstAmountText;
			set
			{
				if (value == string.Empty)
					FirstAmount = 0;

				if (float.TryParse(value, out var result))
					FirstAmount = result;
				_firstAmountText = value;

				OnPropertyChanged(nameof(FirstAmountText));
			}
		}

		public string SecondAmount
		{
			get
			{
				if (_firstCoin == null || _secondCoin == null)
					return string.Empty;
				return $"{_firstAmount} {_firstCoin.Name} ({_firstCoin.Symbol})   =   " +
					$"{((_firstAmount * _firstCoin.Price) / _secondCoin.Price)} {_secondCoin.Name} ({_secondCoin.Symbol})";
			}
		}

        public ConverterViewModel(NavigationBarViewModel naviBarViewModel)
        {
			NavigationBarViewModel = naviBarViewModel;
			InitCoins();
        }

		private async void InitCoins()
		{
			await LoadCoinsAsync();
		}

		private async Task LoadCoinsAsync()
		{
			Coins = await _apiHandler.GetCoinsAsync();

			FirstCoin = Coins.First();
			SecondCoin = Coins.Skip(1).First();
		}
	}
}