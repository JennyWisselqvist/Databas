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
using WpfApp.Models.Enteties;
using WpfApp.Services;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private ObservableCollection<KeyValuePair<string, int>> products = new ObservableCollection<KeyValuePair<string, int>>();

        public OrderPage()
        {
            InitializeComponent();
            ChooseProduct().ConfigureAwait(false);
            ChooseCustomer().ConfigureAwait(false);
        }
    public async Task ChooseCustomer()
    {

        var collection = new ObservableCollection<KeyValuePair<string, int>>();
        using var client = new HttpClient();

            var customers = await client.GetFromJsonAsync<IEnumerable<CustomerModel>>("https://localhost:7153/api/customers");



        foreach (var customer in customers)
            collection.Add(new KeyValuePair<string, int>(customer.Name, customer.Id));
        cb_customer_list.ItemsSource = collection;

    }

    public async Task ChooseProduct()
        {

            var collection = new ObservableCollection<KeyValuePair<string, Guid>>();
            using var client = new HttpClient();

            foreach (var products in await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7153/api/products"))
                collection.Add(new KeyValuePair<string, Guid>(products.Name, products.Id));
            cb_products_list.ItemsSource = collection;

        }

        private async void btn_Add_ProductToList_Click(object sender, RoutedEventArgs e)
        {
            lv_OrderRows.ItemsSource = products;

        }

        private async void btn_Create_Order_Click(object sender, RoutedEventArgs e)
        {
            // gör om så att products blir en foreachloop istället
            //jag vet inte hur jag ska göra

            var orderModel = new OrderModel
            {
                CustomerId = int.Parse(cb_customer_list.SelectedValue.ToString()),

            };

            foreach (var order in products)



                

        }
    }
}
