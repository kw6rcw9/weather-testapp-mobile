using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using MobileTestApp.Data;

namespace MobileTestApp
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "sqlite3.db";
        private static UsersRepository db;
        public static UsersRepository Db
        {
            get
            {
                if (db == null)
                {
                    db = new UsersRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return db;
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
