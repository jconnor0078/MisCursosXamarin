using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MisCursosXamarin
{

    public partial class ListarItems : ContentPage
    {
        public ListarItems(JArray arrData)
        {
            InitializeComponent();

            Debug.WriteLine("DATA:   " + arrData);

            var data = new List<Product>();
            for (int i = 0; i < arrData.Count; i++)
            {
                //string cant = "Cantidad" + ((JArray)arrData[i]["items"]).Count;
                var arraycolor =  ((JArray)arrData[i]["colores"]);
                Product tmp = new Product
                {
                    nombre = arrData[i]["nombre"].ToString(),
                    codigo = arrData[i]["codigo"].ToString(),
                    precioMillar = arrData[i]["precioMillar"].ToString(),
                    precioCiento = arrData[i]["precioCiento"].ToString(),
                    imagen = "http://area51.pe/sol/" + arrData[i]["imagen"],
                    colores = arraycolor.Select(s => (string) s).ToArray()

                };
                data.Add(tmp);
            }
            list.ItemsSource = data;

            list.ItemSelected += List_ItemSelected;
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;

            if (e.SelectedItem == null) return;

            //DisplayAlert("Próximamente", (list.SelectedItem as Product).nombre, "Muschas Gracias");

            Product tmpObj = new Product()
            {
                nombre = (list.SelectedItem as Product).nombre,
                codigo = (list.SelectedItem as Product).codigo,
                precioMillar = (list.SelectedItem as Product).precioMillar,
                precioCiento = (list.SelectedItem as Product).precioCiento,
                imagen = (list.SelectedItem as Product).imagen,
                colores = (list.SelectedItem as Product).colores
            };
            var item = JObject.FromObject(tmpObj);

            DetailProduct ItemSelected = new DetailProduct(item);

            ItemSelected.Title = item["nombre"].ToString();

            Navigation.PushAsync(ItemSelected);
        }
    }
}