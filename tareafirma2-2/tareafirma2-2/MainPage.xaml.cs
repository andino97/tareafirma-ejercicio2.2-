using SignaturePad.Forms;
using SignaturesApp.Model;
using SignaturesApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SignaturesApp
{
    public partial class MainPage : ContentPage
    {
        string valueBase64;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Stream image = await PadView.GetImageStreamAsync(SignatureImageFormat.Png);
            // var image = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            valueBase64 = Convert.ToBase64String(data);


            if(String.IsNullOrWhiteSpace(name.Text) || String.IsNullOrWhiteSpace(description.Text))
            {
                await DisplayAlert("ERROR", "SE DEBEN DE LLENAR LOS DATOS DE NOMBRE Y DESCRIPCION PARA GUARDAR", "ACEPTAR");
            }

            var signatureToSave = new Signatures
            {
                imageCode = valueBase64,
                name = name.Text,
                description = description.Text
            };

            var result = await App.BaseDatos.saveSignature(signatureToSave);

            if(result != 1)
            {
                await DisplayAlert("ERROR", "OCURRIO UN ERROR, INTENTE DE NUEVO", "ACEPTAR");
            }

            await DisplayAlert("AVISO", "GUARDADO CORRECTAMENTE", "ACEPTAR");
        }
            
        private async void ViewSignaturesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignaturesList());
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            PadView.Clear();
        }
    }
}
