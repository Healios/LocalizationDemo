using Microsoft.Extensions.Localization;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Core.MVVM
{

    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        // Fields.
        private const string INDEXER_NAME = "i18n";
        protected INavigationService NavigationService { get; private set; }
        protected IStringLocalizer Localizer { get; private set; }

        // Constructors.
        public ViewModelBase(INavigationService navigationService, IStringLocalizer localizer)
        {
            NavigationService = navigationService;
            Localizer = localizer;
        }

        // Properties.
        [IndexerName(INDEXER_NAME)]
        public string this[string key] => Localizer[key];

        [IndexerName(INDEXER_NAME)]
        public string this[string key, string argument] => Localizer[key, argument];

        [IndexerName(INDEXER_NAME)]
        public string this[string key, object[] arguments] => Localizer[key, arguments];

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        // Methods.
        public IEnumerable<CultureInfo> GetAvailableLanguages() => new List<CultureInfo>() { new CultureInfo("da"), new CultureInfo("en") };
        
        public void SetLanguage(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            RaisePropertyChanged(INDEXER_NAME);
            OnLanguageChanged();
        }

        public virtual void OnLanguageChanged()
        {
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}
