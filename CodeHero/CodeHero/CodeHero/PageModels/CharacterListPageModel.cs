using Akavache;
using CodeHero.Helpers;
using CodeHero.Models;
using CodeHero.Services;
using FreshMvvm;
using MvvmHelpers;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeHero.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class CharacterListPageModel : FreshBasePageModel
    {
        private readonly IApiService _iApiService;

        public ObservableRangeCollection<Character> Characters { get; private set; }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set { selectedCharacter = value; SelectCharacterPageModel(value); }
        }

        public ICommand LoadCharactersCommand { get; }

        public ICommand SelectCharacterCommand { get; private set; }

        public CharacterListPageModel(IApiService IApiService)
        {
            _iApiService = IApiService;
            LoadCharactersCommand = new Command<int>((int offset) => LoadCharacters(offset));
            Characters = new ObservableRangeCollection<Character>();
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            LoadCharacters(0);
        }

        public void LoadCharacters(int offset, int limit = Settings.CharactersPerRequest)
        {
            IsBusy = true;

            var cache = BlobCache.LocalMachine;
            var cachedApiData = cache.GetAndFetchLatest($"ApiData_{offset}", () => _iApiService.GetCharacters(offset, limit),
                timeOffset =>
                {
                    TimeSpan elapsed = DateTimeOffset.Now - timeOffset;
                    return elapsed > new TimeSpan(hours: 1, minutes: 0, seconds: 0);
                });

            cachedApiData.Subscribe(apiData => {
                Characters.AddRange(apiData.Results);
            });
          
            IsBusy = false;
        }

        private void SelectCharacterPageModel(Character character)
        {
            CoreMethods.PushPageModel<CharacterDetailPageModel>(character);
        }
    }
}
