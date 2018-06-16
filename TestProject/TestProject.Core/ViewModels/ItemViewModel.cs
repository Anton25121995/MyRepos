
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;
using System;

namespace TestProject.Core.ViewModels
{

    public class ItemViewModel : MvxViewModel<Item>
    {
        #region Fields
        IMvxNavigationService _navigationService;
        static IDataBaseService _dataBaseService;
        #endregion

        #region Constructors
        public ItemViewModel(IMvxNavigationService navigationService, IDataBaseService dataBaseService)
        {
            _navigationService = navigationService;
            _dataBaseService = dataBaseService;

            ItemDeleteCommand = new MvxAsyncCommand(DeleteItem);
            ItemChangedCommand = new MvxAsyncCommand(SaveChanges);
            CancelChangesCommand = new MvxAsyncCommand(CancelChanges);
        }
        #endregion

        #region Properties
        private Item _item;
        public Item Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                RaisePropertyChanged(() => Item);
            }
        }

        private string ImagePath
        {
            get
            {
                return _item.ImageName;
            }
            set
            {
                _item.ImageName = value;
                RaisePropertyChanged(() => Item);
            }
        }

        private byte[] _byteArray;
        public byte[] ByteArray
        {
            get
            {
                return _byteArray;
            }
            set
            {
                _byteArray = value;
                ArrayToFile(_byteArray);
                RaisePropertyChanged(() => ByteArray);
            }
        }
        
        public byte[] ArrayToFile(byte[] imageData)
        {
            var a = Guid.NewGuid().ToString();
            var pictures = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            try
            {
                string filePath = Path.Combine(pictures, a.ToString());
                File.WriteAllBytes(filePath, imageData);
                Item.ImageName = filePath;
                RaisePropertyChanged(() => Item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return imageData;
        }
        #endregion

        #region Methods

        public override void Prepare(Item parameter)
        {
            Item = parameter;
        }

        private async Task DeleteItem()
        {
            _dataBaseService.DeleteItem(Item);
            _dataBaseService.UpdateTable();
            Close(this);
        }

        private async Task SaveChanges()
        {
            Item oldItem;
            try
            {
                oldItem = _dataBaseService.GetItem(Item.Id) ?? null;
                oldItem = Item;
                oldItem.ToRemove = false;
                _dataBaseService.UpdateItem(oldItem); //update existed element
            }
            catch //if element doesn't exist in Db
            {
                oldItem = Item;
                oldItem.ToRemove = false;
                _dataBaseService.InsertItem(oldItem);
            }
            Close(this);
        }

        private async Task CancelChanges()
        {
            Item oldItem;
            try
            {
                oldItem = _dataBaseService.GetItem(Item.Id) ?? null;
                oldItem.ToRemove = false;
                _dataBaseService.UpdateItem(oldItem);
                Close(this);
            }
            catch
            {
                Item.ToRemove = true;
                Close(this);
            }
        }
        #endregion

        #region Commands
        public virtual MvxCommand GoBackCommand => new MvxCommand(() =>
        {
            Close(this);
        });

        public IMvxAsyncCommand CancelChangesCommand { get; set; }
        public IMvxCommand ItemDeleteCommand { get; private set; }
        public IMvxCommand ItemChangedCommand { get; set; }
        #endregion
    }
}
