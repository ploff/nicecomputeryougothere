using System.Diagnostics;
using System.IO;
using System.Windows.Input;

namespace nicecomputeryougothere
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            videoBase64.videoDecode();
            string vidpath = Path.GetTempPath() + "\\video.mp4";
            
            MediaElement.Source = new Uri(vidpath);
            MediaElement.Play();
            MediaElement.MediaEnded += (_, _) =>
            {
                Close();
                Process.Start("shutdown", "/l"); // /l for logoff
                //File.Delete(vidpath);
            };
            
            KeyDown += MainWindow_KeyDown;
        }
        
        private static void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.LeftAlt) || e.KeyboardDevice.IsKeyDown(Key.RightAlt) && e.SystemKey == Key.F4)
            {
                e.Handled = true;
            }
        }
    }
}