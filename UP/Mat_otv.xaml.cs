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
        public TehnikaEntities2 te = new TehnikaEntities2();
        public Mat_otv()
        {
            InitializeComponent();
            te.Technics.Load(); // загружаем данные
            TehnGrid.DataContext = te.Technics.ToList(); // устанавливаем привязку к кэшу
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void razdel_Click(object sender, RoutedEventArgs e)
        {
            Podrazdeleniye pod = new Podrazdeleniye();
            pod.Show();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            te = new TehnikaEntities2();
            te.Technics.Load(); // загружаем данные
            TehnGrid.DataContext = te.Technics.ToList(); // устанавливаем привязку к кэшу
        }

        private void TehnGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
