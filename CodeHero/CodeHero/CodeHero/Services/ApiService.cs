using CodeHero.Helpers;
using CodeHero.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeHero.Services
{
    public class ApiService : IApiService
    {
        public async Task<ApiData<Character>> GetCharacters(int offset, int limit)
        {
            var querystring = string.Empty;
            if (offset > 0)
                querystring += $"&offset={offset.ToString()}";
            if (limit > 0)
                querystring += $"&limit={limit.ToString()}";

            var result = await MakeHttpCall<ApiResult<Character>>("characters", querystring);
            
            return result.Data;
        }

        private async Task<TOutput> MakeHttpCall<TOutput>(string query, string querystring)
        {

            HttpClient client = new HttpClient();

            string url = $"{Settings.BaseUrl}{query}?ts=1&apikey={Settings.ApiKey}{querystring}";


            using (var response = await client.GetAsync(url))
            {
                try
                {
                    var responseText = await response.Content.ReadAsStringAsync();
                    
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<TOutput>(responseText);
                    }
                    else
                    {
                        throw new Exception(string.Format("Response Statuscode for {0}: {1}", url, response.StatusCode));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }
    }
}
