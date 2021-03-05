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
    [ValueConversion(typeof(string), typeof(BitmapImage))]
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
            var path = (string)value;

            //if the path is null, ignore
            if (path == null)
                return null;

            //Get name of the item
            var name = TreeView.GetFileFolderName(path);

            //By default, we presume an image
            var image = "Images/file.png";

            //if name is blank. we presume it's a drive as we cannot have a blank file or folder name
            if (string.IsNullOrEmpty(name))
                image = "Images/drive.png";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "Images/folderclosed.png";
         
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
