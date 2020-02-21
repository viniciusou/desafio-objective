using Newtonsoft.Json;
using System.Collections.Generic;

namespace CodeHero.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("thumbnail")]
        public ImageUrl ImageUrl { get; set; }
    }
}
