using CodeHero.Models;
using FreshMvvm;

namespace CodeHero.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class CharacterDetailPageModel : FreshBasePageModel
    {
        public Character Character { get; private set; }

        public CharacterDetailPageModel() { }

        public override void Init(object initData)
        {
            base.Init(initData);

            Character = initData as Character;
        }
    }
}
