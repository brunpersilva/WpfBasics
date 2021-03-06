using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfBasics
{
    /// <summary>
    /// Converts a Fullpath to a specific image type of a drive, folder or file
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //By default, we presume an image
            var image = "Images/file.png";

            //Set the image depending on the directory type
            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/drive.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/folderclosed.png";
                    break;
            }
           return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
