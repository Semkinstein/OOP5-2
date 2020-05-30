using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP5._2
{
    /// <summary>
    /// Логика взаимодействия для UserCard.xaml
    /// </summary>
    public partial class UserCard : UserControl
    {
        //public string name;
        //public string surname;
        //public string job;
        public string status;
        Popup codePopup = new Popup();

        int likeCounter = 0;
        int dislikeCounetr = 0;

        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }

        public string Sur
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }

        public string Job
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }

        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
             "labelName", // имя параметра в разметке
             typeof(string), // тип данных параметра
             typeof(UserCard), // тип данных элемента управления
             new PropertyMetadata(string.Empty, LoginChanged));

        private static void LoginChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var userCard = obj as UserCard;
            userCard.labelName.Content = userCard.Login;
        }        public static readonly DependencyProperty surProperty = DependencyProperty.Register(
             "labelSurname", // имя параметра в разметке
             typeof(string), // тип данных параметра
             typeof(UserCard), // тип данных элемента управления
             new PropertyMetadata(string.Empty, surChanged));

        private static void surChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var userCard = obj as UserCard;
            userCard.labelSurname.Content = userCard.Sur;

        }        public static readonly DependencyProperty jobProperty = DependencyProperty.Register(
             "labelJob", // имя параметра в разметке
             typeof(string), // тип данных параметра
             typeof(UserCard), // тип данных элемента управления
             new PropertyMetadata(string.Empty, jobChanged));

        private static void jobChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var userCard = obj as UserCard;
            userCard.labelJob.Content = userCard.Job;

        }        

        public UserCard(string name, string surname, string job, string status, BitmapImage img)
        {
            InitializeComponent();
            cardGrid.Width = 600;
            cardGrid.Height = 250;
            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;

            //this.name = name;
            //this.surname = surname;
            //this.job = job;
            //this.status = status;

            //labelJob.Content = this.job;
            //labelName.Content = this.name;
            //labelSurname.Content = this.surname;

            if (img == null)
            {
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/nopic.png"));
            }
            else
            {
                image.Source = img;
            }

            ToolTip likett = new ToolTip();
            likett.Content = "Лайк";
            butPic1.ToolTip = likett;
            ToolTip dislikett = new ToolTip();
            dislikett.Content = "Дизлайк";
            butPic2.ToolTip = dislikett;
            Image ing = new Image();
            ing.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/like.png"));
            butPic1.Content = ing;
            

            Image ing2 = new Image();
            ing2.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/dislike.png"));
            butPic2.Content = ing2;
        }



        private void LabelName_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Content = "Имя";
            labelName.ToolTip = tt;
        }

        private void LabelSurname_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Content = "Фамилия";
            labelSurname.ToolTip = tt;
        }

        private void LabelJob_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Content = "Должность";
            labelJob.ToolTip = tt;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            
            TextBlock popupText = new TextBlock();
            popupText.Text = status;
            popupText.Background = Brushes.White;
            codePopup.Child = popupText;
            codePopup.PlacementTarget = image;
            codePopup.VerticalOffset = -15;
            codePopup.HorizontalAlignment = HorizontalAlignment.Center;
            codePopup.IsOpen = true;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            codePopup.IsOpen = false;
        }

        private void ButPic1_Click(object sender, RoutedEventArgs e)
        {
            likeCounter++;
            labelCnt1.Content = likeCounter;
        }

        private void ButPic2_Click(object sender, RoutedEventArgs e)
        {
            dislikeCounetr++;
            labelCnt2.Content = dislikeCounetr;
        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelName.Content = textBoxName.Text;
        }

        private void TextBoxNameSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelSurname.Content = textBoxNameSurname.Text;
        }

        private void TextBoxNameJob_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelJob.Content = textBoxNameJob.Text;
        }
    }
}
