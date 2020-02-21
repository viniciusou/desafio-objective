using System;
using System.Collections.Generic;
using System.Text;

namespace CodeHero.Helpers
{
    public static class Settings
    {
        public static string BaseUrl => "https://gateway.marvel.com/v1/public/";
        public static string ApiKey => "449e48dd30ae8702b4a787c56feb6d7a&hash=6f1e84fd315fe162e424c23cc22102f8";
        public static string ImageAspectRatio => "standard_medium";

        public const int CharactersPerRequest = 20;

    }
}
