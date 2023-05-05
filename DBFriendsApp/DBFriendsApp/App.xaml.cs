using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Text;
using DBFriendsApp.Models;
using DBFriendsApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DBFriendsApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "friends.db";
        public static FriendRepository database;
        public static FriendRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new FriendRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App CurrentApp { get; private set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DBListPage());
        }
        protected override void OnStart()
        {
            CurrentApp = this;
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
