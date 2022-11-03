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

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработка нажатия на кнопку "Войти"
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            using (TehnikaEntities2 te = new TehnikaEntities2())
            {

                if (te.Users.Any(i => i.Login == Login.Text && i.Password == Password.Text && i.Role == "admin"))
                {
                    //Если роль - Админ, то открываем страницу для админа
                    Rukovoditel ruk = new Rukovoditel();
                    ruk.Show();
                    this.Close();
                }

                else if (te.Users.Any(i => i.Login == Login.Text && i.Password == Password.Text && i.Role == "rab"))
                {
                    //Если роль - rab, то открываем страницу для обычного работника
                    Mat_otv mat = new Mat_otv();
                    mat.Show();
                    this.Close();
                }
                
                else if (te.Users.Any(i => i.Login != Login.Text))
                {
                    MessageBox.Show("Вы ввели неверный логин(");
                }
                else if (te.Users.Any(i => i.Password != Password.Text))
                {
                    MessageBox.Show("Пароль неверный(");
                }
            }
        }
    }
}
