using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DBFriendsApp.ViewModels;
using DBFriendsApp.Views;
using Xamarin.Forms;

namespace DBFriendsApp.ViewModels
{
    public class FriendsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FriendViewModel> Friends { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateFriendCommand { get; private set; }
        public ICommand DeleteFriendCommand { get; private set; }
        public ICommand SaveFriendCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        FriendViewModel selectedFriend;

        public INavigation Navigation { get; set; }

        public FriendsListViewModel()
        {
            Friends = new ObservableCollection<FriendViewModel>();
            CreateFriendCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);

        }

        public FriendViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != value)
                {
                    FriendViewModel tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel = this }));
        }


        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null && friend.IsValid && !Friends.Contains(friend))
            {
                Friends.Add(friend);
            }
            Back();
        }

        private void DeleteFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null)
            {
                Friends.Remove(friend);
            }
            Back();
        }


    }
}

