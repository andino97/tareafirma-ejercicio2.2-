using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tareafirma2_2.Model;

namespace tareafirma2-2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class mostrarlista : ContentPage
{
    public mostrarlista()
    {
        InitializeComponent();
        name.Text = firma.name;
        description.Text = firma.description;
        imageSignature.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(firma.imageCode)));
    }
}
}