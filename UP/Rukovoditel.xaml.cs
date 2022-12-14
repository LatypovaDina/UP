using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для Rukovoditel.xaml
    /// </summary>
    public partial class Rukovoditel : System.Windows.Window
    {
        public TehnikaEntities2 te = new TehnikaEntities2();
        /// <summary>
        /// При открытии данной страницы сразу загружаются данные в таблицу
        /// </summary>
        public Rukovoditel()
        {
            InitializeComponent();
            te = new TehnikaEntities2();
            te.Technics.Load(); // загружаем данные
            TehnGrid.DataContext = te.Technics.ToList(); // устанавливаем привязку к кэшу

        }
       
        private void spisoktov_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
           
               
        }
        private void TehnGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TehnGrid_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TehnGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
        /// <summary>
        /// Описание метода удаления записи из БД
        /// </summary>
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            using (TehnikaEntities2 db = new TehnikaEntities2())
            {
                Technics p1 = db.Technics.FirstOrDefault();
                if (p1 != null)
                {
                    db.Technics.Remove(p1);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Описание метода для добавления новой записи в БД
        /// </summary>
        private void new_Click(object sender, RoutedEventArgs e)
        {
            using (TehnikaEntities2 db = new TehnikaEntities2())
            {
                Technics p1 = new Technics { Inv_number = Convert.ToInt32(inv.Text), Name = name.Text, Model = model.Text, Purchase_date = Convert.ToDateTime(date.Text), Price = Convert.ToInt32(price.Text), Room_number = 7};
                // добавление
                db.Technics.Add(p1);
                db.SaveChanges();   // сохранение изменений
                var techn = db.Technics.ToList();
            }

        }
        /// <summary>
        /// Описание метода обновления таблицы
        /// </summary>
        private void update_Click(object sender, RoutedEventArgs e)
        {
            te = new TehnikaEntities2();
            te.Technics.Load(); // загружаем данные
            TehnGrid.DataContext = te.Technics.ToList(); // устанавливаем привязку к кэшу
        }
        /// <summary>
        /// Обработка нажатия кнопки выхода
        /// </summary>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        /// <summary>
        /// Описание метода сохранения изменений
        /// </summary>
        private void save_Click(object sender, RoutedEventArgs e)
        {
            using (TehnikaEntities2 db = new TehnikaEntities2())
            {
                // получаем первый объект
                Technics tn = db.Technics.FirstOrDefault();
                tn.Inv_number = Convert.ToInt32(inv.Text);
                tn.Name = name.Text;
                tn.Model = model.Text;
                tn.Price = Convert.ToInt32(price.Text);
                tn.Room_number = 5; 
                db.SaveChanges();   // сохраняем изменения
            }
        }
        /// <summary>
        /// Описание метода сохранения таблицы в PDF формате
        /// </summary>
        private void pdf_Click(object sender, RoutedEventArgs e)
        {
            List<Technics> technica = new List<Technics>();
            using (TehnikaEntities2 ie3 = new TehnikaEntities2())
            {
                foreach (Technics tech in ie3.Technics)
                {
                    technica.Add(tech);
                }
                Excel.Application app = new Excel.Application();
                app.SheetsInNewWorkbook = 1;
                Workbook workbook = app.Workbooks.Add(Type.Missing);
                Worksheet worksheet = app.Worksheets.Item[1];
                //определяем столбцы для вывода таблицы
                worksheet.Cells[1][1] = "Инвентарный номер";
                worksheet.Cells[2][1] = "Название";
                worksheet.Cells[3][1] = "Модель";
                worksheet.Cells[4][1] = "Дата приобретения";
                worksheet.Cells[5][1] = "Стоимость";
                for (int i = 0; i < technica.Count; i++)
                {
                    //выводим содержимое БД в соответствующий столбец
                    worksheet.Cells[1][i + 2] = technica[i].Inv_number;
                    worksheet.Cells[2][i + 2] = technica[i].Name;
                    worksheet.Cells[3][i + 2] = technica[i].Model;
                    worksheet.Cells[4][i + 2] = technica[i].Purchase_date;
                    worksheet.Cells[5][i + 2] = technica[i].Price;
                }
                app.Visible = true;
                app.ActiveWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, @"C:\Users\Латыповлар\LatypovaUP.pdf");
            }
        }
        /// <summary>
        /// Описание метода перехода в окно подразделений
        /// </summary>
        private void razdel_Click(object sender, RoutedEventArgs e)
        {
            Podrazdeleniye pod = new Podrazdeleniye();
            pod.Show();
        }
       
    }
}
