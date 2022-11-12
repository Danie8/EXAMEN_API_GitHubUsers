using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace EXAMEN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string URL_API = "https://api.github.com/users";

        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task<string> APIasync()
        {            
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("product", "1"));
                var response = await httpClient.GetAsync(URL_API);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else return "error";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn_prueba.IsEnabled = false;
            var t = Task.Run(() => APIasync());
            txt_Response.Text = t.Result.ToString();
            btn_prueba.IsEnabled = true;
        }

    }
}

