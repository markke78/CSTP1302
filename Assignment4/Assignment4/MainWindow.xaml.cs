using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int angle;
        public MainWindow()
        {
            InitializeComponent();
            
        }



        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            if (imgDog.Visibility == Visibility.Visible)
            {
                imgDog.Visibility = Visibility.Hidden;
            }
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            if (imgDog.Visibility != Visibility.Visible)
            {
                imgDog.Visibility = Visibility.Visible;
            }
        }

        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            angle = angle + 90;
            RotateTransform rotateTransform = new RotateTransform(angle) { CenterX = imgDog.ActualHeight / 2, CenterY = imgDog.ActualWidth / 2 };
            imgDog.RenderTransform = rotateTransform;
        }

        MediaPlayer mediaPlayer = new MediaPlayer();
        String fileName= @"C:\Users\markk\OneDrive\VCC\Winter2023\CSTP1302\Assignment4\Assignment4\Audio\Chopin-nocturne-op-9-no-2.mp3";

        private void btnAudioOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = false,
                DefaultExt = ".mp3"
            };
            bool? dialogOk = openFileDialog.ShowDialog();
            if (dialogOk == true)
            {
                fileName = openFileDialog.FileName;
                adFileName.Text = openFileDialog.FileName;
                mediaPlayer.Open(new Uri(fileName));
            }


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
                lblStatus.Content = string.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblStatus.Content = "No file selected...";
        }

        private void btnAudioPlay_Click(object sender, RoutedEventArgs e)
        {

/*            mediaPlayer.Open(new Uri(fileName));
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();*/
            mediaPlayer.Play();
        }

        private void btnAudioPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnAudioStop_Click(object sender, RoutedEventArgs e)
        {
            btnPause.IsEnabled = false;
            btnPlay.IsEnabled = true;
            mediaPlayer.Stop();
        }

        private void openMoive_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "MP4 File (*.mp4)|*.mp4|3GP File (*.3gp)|*.3gp|Audio File (*.wma)|*.wma|MOV File (*.mov)|*.mov|AVI File (*.avi)|*.avi|Flash Video(*.flv)|*.flv|Video File (*.wmv)|*.wmv|MPEG-2 File (*.mpeg)|*.mpeg|WebM Video (*.webm)|*.webm|All files (*.*)|*.*";
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fd.ShowDialog();
            string filename = fd.FileName;

            movieInput.Text = filename;
            Uri u = new Uri(filename);
            me.Source = u;
            me.Volume = 100.5;
            MediaState opt = MediaState.Play;
            me.LoadedBehavior = opt;

        }

        private void videoPlay_Click(object sender, RoutedEventArgs e)
        {
            MediaState ms = MediaState.Play;
            me.LoadedBehavior = ms;
        }

        private void videoPause_Click(object sender, RoutedEventArgs e)
        {
            MediaState uc = MediaState.Pause;
            me.LoadedBehavior = uc;
        }

        private void videoStop_Click(object sender, RoutedEventArgs e)
        {
            videoPause.IsEnabled = false;
            videoPlay.IsEnabled = true;
            me.LoadedBehavior = MediaState.Stop;
        }

        private void videoExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        string videoURL = @"C:\Users\markk\OneDrive\VCC\Winter2023\CSTP1302\Assignment4\Assignment4\Video\file_example_MP4_480_1_5MG.mp4";
        
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // create URI object because MediaElement does not directly support the Video URL
                Uri obj = new Uri(videoURL);
                // set the local video URL via URI then attach this Uri object to Media Element using its
                // Source property
                me.Source = obj;
                // now url is successfully set to MediaElement. Next step is to play the Media Element
                // this is done by MediaState built-in class
                MediaState opt = MediaState.Play;
                // now attach this play state to MediaElement using its important property LoadedBehaviour
                me.LoadedBehavior = opt;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Message: " + ex.Message);
            }
        }


    }
}
