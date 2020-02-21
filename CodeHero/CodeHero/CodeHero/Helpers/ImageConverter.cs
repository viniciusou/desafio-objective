using CodeHero.Models;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace CodeHero.Helpers
{
    public class ImageConverter : IValueConverter
    {
        static WebClient Client = new WebClient();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageUrl = value as ImageUrl;
            var byteArray = Client.DownloadData($"{imageUrl.Path}/{Settings.ImageAspectRatio}.{imageUrl.Extension}");
            return ImageSource.FromStream(() => new MemoryStream(byteArray));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
