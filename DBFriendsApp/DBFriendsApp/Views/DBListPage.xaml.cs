using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBFriendsApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DBFriendsApp.Views;
using DBFriendsApp;

namespace DBFriendsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.SelectedItem;
            DBFriendPage friendPage = new DBFriendPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }

        private async void CreateFriend(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            DBFriendPage friendPage = new DBFriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }


    }
}
