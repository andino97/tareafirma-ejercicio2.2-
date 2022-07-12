using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using tareafirma2_2.Model;
using System.IO;
using Xamarin.Forms.Xaml;

namespace tareafirma2-2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class listafirma : ContentPage
{
    public listafirma()
    {
        InitializeComponent();
    }



    protected override void OnAppearing()
    {

        base.OnAppearing();
        LoadCollectionView();
    }

    private async void LoadCollectionView()
    {
        listafirma.ItemsSource = await App.BaseDatos.GetListSignatures();
    }


    private async void listSignatures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var itemSelected = (firma)e.SelectedItem;

        var firmaObtained = await App.BaseDatos.GetSignatureByCode(itemSelected.code);

        var lista = new mostrarlista(firmaObtained);

        await Navigation.PushAsync(lista);
    }
}
}