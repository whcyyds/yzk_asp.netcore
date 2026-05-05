using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks; // 为 Task.Delay 添加

namespace 异步不要用sleep_作业
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

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ;
            string url = input1.Text;
            string result = await GetWWWAsync(url);
            txtStatus.Text = result.Substring(0, 4);

        }


        private async Task<string> GetWWWAsync(string url)
        {
            string result;
            using (HttpClient httpClient = new HttpClient())
            {

                int err_time = 0;
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        result = await httpClient.GetStringAsync(url);
                        return result;

                    }
                    catch
                    {
                        await Task.Delay(500);
                        err_time += 1;
                        if (err_time > 2) { return "下载失败"; }
                    }
                    
                }

            }
            return "下载失败111";

        }
    }
}