using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MisCursosXamarin
{

    public partial class DetailProduct : ContentPage
    {

        public DetailProduct(JObject data)
        {
            InitializeComponent();
            
            var product = new Product()
            {
                nombre = data["nombre"].ToString(),
                codigo = data["codigo"].ToString(),
                precioMillar = data["precioMillar"].ToString(),
                precioCiento = data["precioCiento"].ToString(),
                imagen = data["imagen"].ToString(),
                colores = data["colores"].Select(s => (string)s).ToArray()
            };

            IMG.Source = product.imagen;

        }
    }
}