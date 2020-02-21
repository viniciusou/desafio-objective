using CodeHero.Helpers;
using CodeHero.PageModels;
using CodeHero.Services;
using Moq;
using NUnit.Framework;

namespace CodeHero.UnitTests.PageModels
{
    [TestFixture]
    public class CharacterListPageModelTests
    {
        private Mock<IApiService> _apiService;
        private CharacterListPageModel _pageModel;

        [SetUp]
        public void Setup()
        {
            _apiService = new Mock<IApiService>();
            _pageModel = new CharacterListPageModel(_apiService.Object);
        }

        [Test]
        public void LoadCharacters_WhenCalled_GetDataFromCache()
        {
            _pageModel.LoadCharacters(0);

            _apiService.Verify(s => s.GetCharacters(0, Settings.CharactersPerRequest), Times.Never);
        }
    }
}
