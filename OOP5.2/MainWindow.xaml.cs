using Microsoft.Win32;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace OOP5._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int cardHeight = 10;
        OpenFileDialog fileDialog = new OpenFileDialog();
        BitmapImage img = null;

        public static object Instance { get; internal set; }

        public MainWindow()
        {
            InitializeComponent();
            fileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName != null && textBoxSurname != null && textBoxJob != null && textBoxInfo != null)
            {
                UserCard card = new UserCard(textBoxName.Text, textBoxSurname.Text, textBoxJob.Text, textBoxInfo.Text, img);
                card.Margin = new Thickness(200, cardHeight, 0, 0);
                grid.Children.Add(card);
                cardHeight += 260;
            }
            img = null;
        }

        private void ButtonImage_Click(object sender, RoutedEventArgs e)
        {
            if (fileDialog.ShowDialog() == true)
            {
                string filename = fileDialog.FileName;
                img = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }
    }
}
