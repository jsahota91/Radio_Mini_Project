using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Media;
using RadioApp;

namespace RadioWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Radio radio = new Radio();
        string output = "";
        private string[] mylist = new string[4];
        
        public MainWindow()
        {
            InitializeComponent();
            mylist[0] = "pack://siteoforigin:,,,/media/photograph.mp3";
            mylist[1] = "pack://siteoforigin:,,,/media/shape-of-you.mp3";
            mylist[2] = "pack://siteoforigin:,,,/media/thinking-out-loud.mp3";
            mylist[3] = "pack://siteoforigin:,,,/media/just-the-way-you-are.mp3";
            
            RadioCh1.Source = new Uri(mylist[0]);
            output = radio.Play();
            OutputTextBlock.Text = output;
        }
        

        //Play and Pause method
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            RadioCh1.Play();
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            RadioCh1.Pause();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            RadioCh1.Stop();
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            RadioCh1.Volume = (double)volumeSlider.Value;
        }
        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            radio.TurnOff();
            output = radio.Play();
            OutputTextBlock.Text = output;
        }

        private void BtnOn_Click(object sender, RoutedEventArgs e)
        {
           radio.TurnOn();
           MessageBox.Show("Radio is on");
        }

        private void BtnChannel_Click(object sender, RoutedEventArgs e)
        {
            //name of button
            string channel = ((Button)sender).Name;
            if(radio.On == true)
            {
                switch (channel)
                {
                    case "Ch1":
                        radio.Channel = 1;
                        RadioCh1.Play();
                        output = radio.Play();
                        OutputTextBlock.Text = output;
                        break;
                    case "Ch2":
                        radio.Channel = 2;
                        output = radio.Play();
                        OutputTextBlock.Text = output;
                        break;
                    case "Ch3":
                        radio.Channel = 3;
                        output = radio.Play();
                        OutputTextBlock.Text = output;
                        break;
                    case "Ch4":
                        radio.Channel = 4;
                        output = radio.Play();
                        OutputTextBlock.Text = output;
                        break;
                }
                RadioCh1.Source = new Uri(mylist[radio.Channel - 1]);
            }
            
            
        }

        //private void RadioCh1_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mylist.Length -1; i++)
        //    {
        //        Uri current = new Uri(mylist[i]);
        //        if(RadioCh1.Source == current)
        //        {
        //            RadioCh1.Source = new Uri(mylist[i + 1]);
        //            break;
        //        }
        //    }
        //    RadioCh1.Play();
        //}
    }
}
