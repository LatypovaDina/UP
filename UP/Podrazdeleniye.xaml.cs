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
    /// Логика взаимодействия для Podrazdeleniye.xaml
    /// </summary>
    public partial class Podrazdeleniye : Window
    {
        public TehnikaEntities2 te = new TehnikaEntities2();
        public Podrazdeleniye()
        {
            InitializeComponent();
             
            te = new TehnikaEntities2();
            te.Unit.Load(); // загружаем данные
            PodrazdelGrid.DataContext = te.Unit.ToList(); 

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void PodrazdelGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
        
        private void PodrazdelGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void PodrazdelGrid_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TehnikaEntities2 db = new TehnikaEntities2())
                {
                    // получаем первый объект
                    Unit tn = db.Unit.FirstOrDefault();
                    tn.Unit_number = Convert.ToInt32(number.Text);
                    tn.ID_person = Convert.ToInt32(id.Text);
                    tn.Unit_name = name.Text;
                    tn.Full_name = full.Text;
                    tn.Short_name = shortt.Text;
                    db.SaveChanges();   // сохраняем изменения
                }
            }
            catch
            {
                MessageBox.Show("Успешно передано");
            }
        }
    }
}
