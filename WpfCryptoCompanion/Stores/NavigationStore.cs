using System;
using WpfCryptoCompanion.ViewModels;

namespace WpfCryptoCompanion.Stores
{
	public class NavigationStore
	{
		private BaseViewModel _currentViewModel;
		
		public Action CurrentViewModelChanged;

		public BaseViewModel CurrentViewModel
		{
			get => _currentViewModel;
			set
			{
				if (value == null) return;

				_currentViewModel = value;
				OnCurrentViewModelChanged();
			}
		}

		private void OnCurrentViewModelChanged()
		{
			CurrentViewModelChanged?.Invoke();
		}
	}
}