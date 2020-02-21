using CodeHero.Helpers;
using CodeHero.Models;
using CodeHero.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CodeHero.UnitTests.Services
{
    [TestFixture]
    public class ApiServiceTests
    {
        private ApiService _apiService;

        [SetUp]
        public void SetUp()
        {
            _apiService = new ApiService();
        }

        [Test]
        public async Task GetCharacters_WhenCalled_ReturnsApiData()
        {
            var result = await _apiService.GetCharacters(0, Settings.CharactersPerRequest);
            Assert.That(result, Is.TypeOf<ApiData<Character>>());
        }
    }
}
