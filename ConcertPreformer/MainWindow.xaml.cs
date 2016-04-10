using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.IO;
namespace ConcertPreformer
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

            SoundPlayer sound;
        bool config;
        bool changemode = false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"config.txt"))
            {
                config = true;
            }
            else
            {
                config = false;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
         if(changemode == false) {  
            try { 
             sound = new System.Media.SoundPlayer(@"sounds\" + e.Key + @".wav");
            sound.PlaySync();
                LastPlayedLabel.Content = "Last Played: " + e.Key + ".wav";
            }
            catch
            {
                LastPlayedLabel.Content = "The last played track was not found.";
            }
            }
            else
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



                dlg.DefaultExt = ".wav";
                dlg.Filter = "Wave Files (*.wav)|*.wav";


                Nullable<bool> result = dlg.ShowDialog();


                if (result == true)
                {
                    try
                    {
                        string filename = dlg.FileName;

                        File.Move(filename, @"sounds/" + e.Key + @".wav");
                    }
                    catch
                    {
                        LastPlayedLabel.Content = "An error occurred!";
                        if (MessageBox.Show("An error occurred! Would you like to report the error?", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            
                        }
                        else
                        {
                           //github issues
                        }
                    }
                }
            }
        }
        private void btnChangeKey_Click(object sender, RoutedEventArgs e)
        {
            changemode = true;
            LastPlayedLabel.Content = "Press a key.";
        }
    }
    }

