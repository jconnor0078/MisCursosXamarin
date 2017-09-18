using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MisCursosXamarin
{
    public partial class MainPage : ContentPage
    {

        JArray arrData;

        public MainPage()
        {
            InitializeComponent();

            loadJsonAsync();
        }

        private async Task loadJsonAsync()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://area51.pe/sol/")
            };

            string url = string.Format("tienda.json");
            var resp = await client.GetAsync(url);
            var result = resp.Content.ReadAsStringAsync().Result;

            JObject value = JObject.Parse(result);

            arrData = (JArray)value["tienda"];

            Debug.WriteLine(arrData);

            fillData(arrData);
        }

        private void fillData(JArray arrData)
        {
            var data = new List<Product>();
            for (int i = 0; i < arrData.Count; i++)
            {
                string cant = "Cantidad" + ((JArray)arrData[i]["items"]).Count;

                Product tmp = new Product
                {
                    nombre= arrData[i]["nombre"].ToString(),
                    cantidad= cant,
                    imagen= "http://area51.pe/sol/" + arrData[i]["imagen"],
                    items= (JArray)arrData[i]["items"]
                };
                data.Add(tmp);
            }
            list.ItemsSource= data;

            list.ItemSelected += List_ItemSelected; 
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;

            if (e.SelectedItem == null) return;

            //DisplayAlert("Próximamente", (list.SelectedItem as Product).nombre, "Muschas Gracias");

            ListarItems listarItems = new ListarItems( (list.SelectedItem as Product).items);

            listarItems.Title=(list.SelectedItem as Product).nombre;

            Navigation.PushAsync(listarItems);
        }
    }
}
