using CodeHero.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeHero.Services
{
    public interface IApiService
    {
        Task<ApiData<Character>> GetCharacters(int offset, int limit);
    }
}
