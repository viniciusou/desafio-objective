using Newtonsoft.Json;

namespace CodeHero.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ImageUrl
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("extension")]
        public string Extension { get; set; }
    }
}
