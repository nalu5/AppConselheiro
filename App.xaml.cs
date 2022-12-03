using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppConselheiro.Helper;
using System.IO;

namespace AppConselheiro
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper database;
        public static SQLiteDatabaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteDatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
