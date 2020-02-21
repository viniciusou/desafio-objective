using CodeHero.Models;
using CodeHero.PageModels;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeHero.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterListPage : ContentPage
    {
        CharacterListPageModel pageModel;

        public CharacterListPage()
        {
            InitializeComponent();

            VerifyListEnd();

            VerifyCharacterSearch();            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            pageModel = BindingContext as CharacterListPageModel;

        }

        private void VerifyListEnd()
        {
            lvwCharacters.ItemAppearing += (sender, e) =>
            {
                if (pageModel.Characters == null || pageModel.IsBusy || pageModel.Characters.Count == 0)
                    return;

                if ((Character)e.Item == pageModel.Characters[pageModel.Characters.Count - 1])
                {
                    pageModel.LoadCharactersCommand.Execute(pageModel.Characters.Count);
                }
            };
        }

        private void VerifyCharacterSearch()
        {
            sbrCharacters.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    lvwCharacters.ItemsSource = pageModel.Characters;
                }
                else
                {
                    lvwCharacters.ItemsSource = pageModel.Characters.Where(c => c.Name.ToLower().Contains(e.NewTextValue.ToLower()));
                }
            };
        }
    }
}