using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;
using System.Linq;

namespace TestProject.Core.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        #region Constructors
        public TableViewModel(IMvxNavigationService navigationService, IDataBaseService dataBaseService) : base(navigationService, dataBaseService)
        {
            _dataBaseService = dataBaseService;
            _navigationService = navigationService;

            _items = new MvxObservableCollection<Item>();
            _items.Clear();

            _items.AddRange(dataBaseService.GetAllItems().ToList());

            ItemSelectedCommand = new MvxAsyncCommand<Item>(ItemSelected);
            RefreshTableCommand = new MvxAsyncCommand(RefreshTable);
            CreateNewItemCommand = new MvxAsyncCommand(CreateNewItem);
        }
        #endregion

        #region Lifecycle
        public override void ViewAppearing()
        {
            var inputItems = _dataBaseService.GetAllItems().ToList();
            
                //var items = Items.Where(x => (inputItems.FirstOrDefault().ToRemove == true)).ToList();
                //Items.RemoveItems(items);
                Items.Clear();
                Items.AddRange(inputItems);
            
        }
        #endregion

        #region Properties
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
        #endregion

        #region Methods
        private async Task ItemSelected(Item selectedItem)
        {
            await _navigationService.Navigate<ItemViewModel, Item>(selectedItem);
        }

        private async Task RefreshTable()
        {
            await Task.Delay(new TimeSpan(0, 0, 2));
            _dataBaseService.UpdateTable();
            IsBusy = false;
        }

        private async Task CreateNewItem()
        {
            var newItem = new Item();
            await _navigationService.Navigate<ItemViewModel, Item>(newItem);
        }
        #endregion

        #region Commands
        public IMvxCommand<Item> ItemSelectedCommand { get; private set; }

        public IMvxCommand RefreshTableCommand { get; private set; }

        public IMvxAsyncCommand CreateNewItemCommand { get; private set; }
        #endregion

    }
}
