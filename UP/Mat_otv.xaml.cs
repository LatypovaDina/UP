using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для Mat_otv.xaml
    /// </summary>
    public partial class Mat_otv : Window
    {
        /// <summary>
        /// При открытии данной страницы сразу загружаются данные в таблицу
        /// </summary>
        public Mat_otv()
        {
            InitializeComponent();
            TehnikaEntities2 te = new TehnikaEntities2();
            te.Technics.Load(); 
            TehnGrid.DataContext = te.Technics.ToList(); 
        }
        /// <summary>
        /// Обработка нажатия кнопки выхода из аккаунта
        /// </summary>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        /// <summary>
        /// Обработка нажатия кнопки для перехода в подразделения
        /// </summary>
        private void razdel_Click(object sender, RoutedEventArgs e)
        {
            Podrazdeleniye pod = new Podrazdeleniye();
            pod.Show();
        }
        /// <summary>
        /// Обработка нажатия кнопки для обновления данных в таблице
        /// </summary>
        private void update_Click(object sender, RoutedEventArgs e)
        {
            TehnikaEntities2 te = new TehnikaEntities2();
            te.Technics.Load(); 
            TehnGrid.DataContext = te.Technics.ToList();
        }

        private void TehnGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
