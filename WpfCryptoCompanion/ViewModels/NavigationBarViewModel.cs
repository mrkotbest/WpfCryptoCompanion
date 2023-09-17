using System.Windows.Input;
using WpfCryptoCompanion.Commands;
using WpfCryptoCompanion.Services;

namespace WpfCryptoCompanion.ViewModels
{
	public class NavigationBarViewModel : BaseViewModel
	{
		public ICommand NavigateHomeCommand { get; }

        public NavigationBarViewModel(NavigationService<HomeViewModel> homeNaviService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNaviService);
        }
    }
}