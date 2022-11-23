using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        public CustomerPage()
        {
            InitializeComponent();
            ChooseCustomer().ConfigureAwait(false);
        }
        public async Task ChooseCustomer()
        {

            var collection = new ObservableCollection<KeyValuePair<string, int>>();
            using var client = new HttpClient();

            foreach (var customers in await client.GetFromJsonAsync<IEnumerable<CustomerModel>>("https://localhost:7153/api/productcategories"))
                collection.Add(new KeyValuePair<string, int>(customers.Name, customers.Id));
            cb_customer_list.ItemsSource = collection;

        }
        private async void btn_Customer_save_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:7153/api/customers", new CustomerCreateModel
            {
                Name = tb_Customer_Name.Text,
                
                //Id = tb_Customer_Id.Text,
            });
            tb_Customer_Name.Text = string.Empty;
            tb_Customer_Id.Text = string.Empty;

        }
    }
}
