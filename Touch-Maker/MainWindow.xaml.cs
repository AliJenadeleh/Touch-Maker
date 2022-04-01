using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Touch_Maker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enable_Generate()
        {
            Btn_Generate.IsEnabled =
                !string.IsNullOrEmpty(txt_src.Text) &&
                !string.IsNullOrEmpty(txt_dest.Text);
        }

        private void btn_src_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                FileName = "*.png",
                Filter = "*.png | *.png",
                Title = "Select a source image"
            };
            if (dlg.ShowDialog() == true)
            {
                txt_src.Text = dlg.FileName;
            }
            Enable_Generate();
        }

        private void btn_dest_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog()
            {

                Title = "Select output directory",
                Filter = "Directory|*.this.directory",
                FileName = "select"
            };

            if (dlg.ShowDialog() == true)
            {
                string path = dlg.FileName;
                path = path.Replace("\\select.this.directory", "");
                path = path.Replace(".this.directory", "");

                txt_dest.Text = path;
            }
            Enable_Generate();
        }

        private void SaveAs(string Dest, string FileName, int Width, int Height, Bitmap Bmp)
        {
            var bmp = new Bitmap(Bmp, Width, Height);
            string path = Path.Combine(Dest, $"{FileName}{Width}.png");

            if (File.Exists(path))
                File.Delete(path);

            bmp.Save(path, ImageFormat.Png);
        }

        private void SaveAsIcon(string Dest, string FileName, int Width, int Height, Bitmap Bmp)
        {
            var bmp = new Bitmap(Bmp, Width, Height);
            string path = Path.Combine(Dest, $"{FileName}{Width}.ico");

            if (File.Exists(path))
                File.Delete(path);

            bmp.Save(path, ImageFormat.Icon);
        }

        private void SaveAsFavicon(string Dest, string FileName, Bitmap Bmp)
        {
            var bmp = new Bitmap(Bmp, 16, 16);
            string path = Path.Combine(Dest, $"favicon.ico");

            if (File.Exists(path))
                File.Delete(path);

            bmp.Save(path, ImageFormat.Icon);
        }

        private void Btn_Generate_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;

            string src = txt_src.Text;
            string dest = txt_dest.Text;
            string touchName = "touch-";
            string iconName = "icon-";

            var bmp = (Bitmap)Bitmap.FromFile(src);
            if (chk_touch.IsChecked == true)
            {
                SaveAs(dest, touchName, 36, 36, bmp);
                SaveAs(dest, touchName, 48, 48, bmp);
                SaveAs(dest, touchName, 57, 57, bmp);
                SaveAs(dest, touchName, 72, 72, bmp);
                SaveAs(dest, touchName, 76, 76, bmp);
                SaveAs(dest, touchName, 96, 96, bmp);
                SaveAs(dest, touchName, 144, 144, bmp);
                SaveAs(dest, touchName, 152, 152, bmp);
                SaveAs(dest, touchName, 167, 167, bmp);
                SaveAs(dest, touchName, 180, 180, bmp);
                SaveAs(dest, touchName, 192, 192, bmp);
                SaveAs(dest, touchName, 196, 196, bmp);
                SaveAs(dest, touchName, 512, 512, bmp);
            }

            if (chk_icon16.IsChecked == true)
                SaveAsIcon(dest, iconName, 16, 16, bmp);

            if (chk_icon32.IsChecked == true)
                SaveAsIcon(dest, iconName, 32, 32, bmp);

            if (chk_icon64.IsChecked == true)
                SaveAsIcon(dest, iconName, 64, 64, bmp);

            if (chk_icon128.IsChecked == true)
                SaveAsIcon(dest, iconName, 128, 128, bmp);

            if (chk_icon256.IsChecked == true)
                SaveAsIcon(dest, iconName, 256, 256, bmp);

            if (chk_favicon.IsChecked == true)
                SaveAsFavicon(dest, touchName, bmp);

            MessageBox.Show("All Images Generated Successfully.");
            (sender as Button).IsEnabled = true;
        }
    }
}
