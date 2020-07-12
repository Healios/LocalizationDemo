using Prism.Navigation;
using Core.MVVM;
using Microsoft.Extensions.Localization;
using LocalizationDemo.Resources;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;

namespace LocalizationDemo.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        // Constructors.
        public MainPageViewModel(INavigationService navigationService, IStringLocalizer<MainPageViewResources> localizer) : base(navigationService, localizer)
        {
            GetAvailableLanguages().ToList().ForEach(cultureInfo => Languages.Add(cultureInfo));
            ItemTappedCommand = new DelegateCommand(ItemTapped);
        }

        // Properties.
        public ObservableCollection<CultureInfo> Languages { get; } = new ObservableCollection<CultureInfo>();

        private CultureInfo selectedLanguage;
        public CultureInfo SelectedLanguage
        {
            get { return selectedLanguage; }
            set { SetProperty(ref selectedLanguage, value); }
        }

        // Commands.
        public ICommand ItemTappedCommand { get; set; }
        private void ItemTapped() => SetLanguage(SelectedLanguage);
    }
}
