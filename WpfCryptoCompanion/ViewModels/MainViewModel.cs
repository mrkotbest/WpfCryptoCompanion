using WpfCryptoCompanion.Stores;

namespace WpfCryptoCompanion.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private readonly NavigationStore _naviStore;

		public BaseViewModel CurrentViewModel => _naviStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _naviStore = navigationStore;
            _naviStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

		private void OnCurrentViewModelChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
		}
	}
}