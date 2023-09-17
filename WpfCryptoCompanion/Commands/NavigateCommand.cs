using WpfCryptoCompanion.Services;
using WpfCryptoCompanion.ViewModels;

namespace WpfCryptoCompanion.Commands
{
	public class NavigateCommand<TViewModel> : BaseCommand
		where TViewModel : BaseViewModel
	{
		private readonly NavigationService<TViewModel> _naviService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _naviService = navigationService;
        }

        public override void Execute(object? parameter)
		{
			_naviService.Navigate();
		}
	}
}