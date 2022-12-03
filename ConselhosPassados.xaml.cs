using AppConselheiro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppConselheiro.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConselhosPassados : ContentPage
    {
        ObservableCollection<Conselho> conselhos = new ObservableCollection<Conselho>();
        public ConselhosPassados()
        {
            InitializeComponent();
            lista_conselhos.ItemsSource = conselhos;
        }

        protected override void OnAppearing()
        {
            if (conselhos.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Conselho> temp = await App.Database.GetAllConselhos();

                    foreach (Conselho item in temp)
                    {
                        conselhos.Add(item);
                    }
                });

                lista_conselhos.ItemsSource = conselhos;
            }
            atualizando.IsRefreshing = false;
        }
    }
}