using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppConselheiro.Model;
using AppConselheiro.Services;
using Xamarin.Essentials;
using AppConselheiro.View;

namespace AppConselheiro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            lbl_conselho.Text = "Clique no botão para um novo conselho";
            this.BindingContext = new Conselho();
        }

        private async void btn_novoConselho_Clicked(object sender, EventArgs e)
        {
            try
            {
                btn_novoConselho.Text = "Carregando";
                btn_novoConselho.IsEnabled = false;

                Conselho novoConselho = await DataService.getConselho();

                while (await App.Database.GetConselhoById(novoConselho.Id) != null)
                {
                    novoConselho = await DataService.getConselho();
                }

                await App.Database.InsertConselho(novoConselho);

                lbl_conselho.Text = novoConselho.Texto;
                btn_novoConselho.Text = "Novo conselho";
                btn_novoConselho.IsEnabled = true;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error 404", ex.Message, "Ok");
            }
        }

        private async void btn_CopiarFrase_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(lbl_conselho.Text);
        }

        private void btnLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConselhosPassados());
        }
    }
}
