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
    /// Логика взаимодействия для Rukovoditel.xaml
    /// </summary>
    public partial class Rukovoditel : Window
    {
        public TehnikaEntities1 te = new TehnikaEntities1();
        public Rukovoditel()
        {
            InitializeComponent();
            te = new TehnikaEntities1();
            te.Technics.Load(); // загружаем данные
            TehnGrid.ItemsSource = te.Technics.Local.ToBindingList(); // устанавливаем привязку к кэшу

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
                System.Windows.Data.CollectionViewSource categoryViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
                te.Technics.ToList();
                categoryViewSource.Source = te.Technics.Local;
            
        }

    }
}
