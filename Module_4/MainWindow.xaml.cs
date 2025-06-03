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
using Xceed.Words.NET;

namespace Module_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApiService ApiService;
        private int TestCount;
        private string DOCPARH = "C:\\Users\\darina.o\\Desktop\\9\\ТестКейс.docx";
        public MainWindow()
        {
            InitializeComponent();
            ApiService = new ApiService();
            TestCount = 1;
        }

        private async void GetDataAcyncClick(object sender, RoutedEventArgs e)
        {
            string getResult = await ApiService.GetDataFromApi();
            PostDataBox.Text = getResult;
            GetDataBox.Text = "";
        }

        private void PostDataToWordClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PostDataBox.Text))
            {
                MessageBox.Show("Сначала получите данные");
                return;
            }
            try {
                string numberText = $"Тест №{TestCount++}";
                string waitingText = InnHelper.Convert(PostDataBox.Text);
                string resultText = InnHelper.IsCorrect(PostDataBox.Text) ? "Успешно": "Неуспешно";

                using(var doc = DocX.Load(DOCPARH))
                {
                    var table = doc.Tables[0];
                    var row = table.InsertRow();

                    row.Cells[0].Paragraphs[0].Append(numberText);
                    row.Cells[1].Paragraphs[0].Append(waitingText);
                    row.Cells[2].Paragraphs[0].Append(resultText);

                    doc.Save();

                    GetDataBox.Text = resultText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи в Word: {ex.Message}");

            }
        }


    }
}
