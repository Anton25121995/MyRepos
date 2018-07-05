using HelloMvxForms.Interfaces;
using HelloMvxForms.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloMvxForms.Core.ViewModels
{
    public class MvxTableViewModel : MvxViewModel<User>
    {
        #region Constructors

        IAlertService _alertService;
        IDataBaseService<Item> _itemService;
        IDataBaseService<User> _userService;
        IMvxNavigationService _navigationService;

        public MvxTableViewModel(IMvxNavigationService navigationService,
            IDataBaseService<Item> itemService,
            IDataBaseService<User> userService,
            IAlertService alertService)
        {
            _alertService = alertService;
            _itemService = itemService;
            _userService = userService;
            _navigationService = navigationService;

            ItemSelectedCommand = new MvxAsyncCommand<Item>(ItemSelected);
            RefreshTableCommand = new MvxAsyncCommand(RefreshTable);
            CreateNewItemCommand = new MvxAsyncCommand(CreateNewItem);
            SpeakAllItemsCommand = new MvxCommand(SpeakAllItems);
            SearchItemCommand = new MvxAsyncCommand(SearchItem);
        }

        #endregion

        #region Lifecycle

        public override void Prepare(User parameter)
        {
            base.Prepare();
            CurrentUser = parameter;
        }

        public override void ViewAppearing()
        {
            _allItems = new MvxObservableCollection<Item>(_itemService.GetInstances(CurrentUser.Id).ToList());
            Items = _allItems;
            IsEnabled = true;

            //var itemsForDeleting = Items.Where(x => (inputItems.FirstOrDefault().ToRemove == true)).ToList();
            //Items.RemoveItems(itemsForDeleting);
            //Items.Clear();
            //Items.AddRange(itemsToList);
        }
        #endregion

        #region Properties

        private User _currentUser;
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                RaisePropertyChanged(() => CurrentUser);
            }
        }

        private MvxObservableCollection<Item> _allItems;

        private MvxObservableCollection<Item> _items;
        public MvxObservableCollection<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        private bool _refreshing;
        public bool Refreshing
        {
            get
            {
                return _refreshing;
            }
            set
            {
                _refreshing = value;
                RaisePropertyChanged(() => Refreshing);
            }
        }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                RaisePropertyChanged(() => SearchText);
                SearchItem();
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }

        #endregion

        #region Methods
        private async Task ItemSelected(Item selectedItem)
        {
            await _navigationService.Navigate<MvxItemViewModel, Item>(selectedItem);
        }

        private async Task RefreshTable()
        {
            //await Task.Delay(new TimeSpan(0, 0, 2));
            _itemService.UpdateTable();
            IsBusy = false;
        }

        private async Task SearchItem()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Items = _allItems;
                return;
            }
            else
            {
                Items = new MvxObservableCollection<Item>(_allItems.Where(i => i.Title.Contains(SearchText)));
            }
        }

        private async Task CreateNewItem()
        {
            var newItem = new Item { UserId = CurrentUser.Id };
            await _navigationService.Navigate<MvxItemViewModel, Item>(newItem);
        }

        private void SpeakAllItems()
        {
            var speakService = DependencyService.Get<ISpeechService>();
            foreach (var x in Items)
            {
                speakService.Speak(x.Title + " ");
            }
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand SearchItemCommand { get; private set; }

        public IMvxCommand GoBackCommand
        {
            get
            {
                return new MvxCommand<Item>((Item item) =>
                {
                    Close(this);
                    //_navigationService.Navigate<LoginViewModel>();
                });
            }
        }

        public IMvxCommand DeleteSelectedItemCommand
        {
            get
            {
                return new MvxCommand<Item>((Item item) =>
                {
                    _alertService.ShowOkCancelMessage("Warning", "You really want to delete this?",
                        () =>
                        {
                            _itemService.DeleteInstance(item);
                            _alertService.ShowSingle("Item was deleted");
                            ViewAppearing();
                        }, null);

                    ViewAppearing();
                });
            }
        }

        public IMvxCommand<Item> ItemSelectedCommand { get; private set; }

        public IMvxCommand RefreshTableCommand { get; private set; }

        public IMvxAsyncCommand CreateNewItemCommand { get; private set; }

        public IMvxCommand SpeakAllItemsCommand { get; private set; }

        #endregion
    }
}
