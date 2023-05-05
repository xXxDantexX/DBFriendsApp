using System;
using System.Collections.Generic;
using DBFriendsApp.Models;
using DBFriendsApp;
using Xamarin.Forms;
using DBFriendsApp.ViewModels;

namespace DBFriendsApp.Views
{
    public partial class DBFriendPage : ContentPage
    {
        public DBFriendPage()
        {
            InitializeComponent();
           
        }

        private void SaveFriend(System.Object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                App.Database.SaveItem(friend);
            }
            this.Navigation.PopAsync();
        }

        private void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        public FriendViewModel ViewModel { get; private set; }
        
    }
}
