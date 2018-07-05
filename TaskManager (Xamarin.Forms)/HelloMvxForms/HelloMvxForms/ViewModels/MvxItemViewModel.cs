using HelloMvxForms.Interfaces;
using HelloMvxForms.Models;
using HelloMvxForms.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloMvxForms.Core.ViewModels
{
    public class MvxItemViewModel : MvxViewModel<Item>
    {
        #region Fields
        IMvxNavigationService _navigationService;
        static IDataBaseService<Item> _itemService;
        IAlertService _alertService;
        #endregion

        #region Constructors
        public MvxItemViewModel(IMvxNavigationService navigationService, IDataBaseService<Item> itemService, IAlertService alertService)
        {
            _navigationService = navigationService;
            _itemService = itemService;
            _alertService = alertService;

            ItemDeleteCommand = new MvxAsyncCommand(DeleteItem);
            ItemChangedCommand = new MvxAsyncCommand(SaveChanges);
            CancelChangesCommand = new MvxAsyncCommand(CancelChanges);
            SpeakCommand = new MvxCommand(Speak);
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

        public string ImagePath
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
            _itemService.DeleteInstance(Item);
            _itemService.UpdateTable();
            Close(this);
        }

        private async Task SaveChanges()
        {
            Item oldItem;
            oldItem = _itemService.GetInstance(Item.Id) ?? null;
            if (oldItem == null)
            {
                if (Item.Title == null && Item.Description == null)
                {
                    _alertService.ShowMessage("Error", "You can't create task with empty title & description, please input title");
                    return;
                }
                oldItem = Item;
                _itemService.InsertInstance(oldItem);
                Close(this);
                return;
            }
            if (oldItem != null)
            {
                oldItem = Item;
                _itemService.UpdateInstance(oldItem); //update existed element
                Close(this);
                return;
            }
        }

        private async Task CancelChanges()
        {
            Item oldItem;
            try
            {
                oldItem = _itemService.GetInstance(Item.Id) ?? null;
                oldItem.ToRemove = false;
                _itemService.UpdateInstance(oldItem);
                Close(this);
            }
            catch
            {
                Item.ToRemove = true;
                Close(this);
            }
            
        }

        private void Speak()
        {
            DependencyService.Get<ISpeechService>().Speak(Item.Title + "  " + Item.Description);
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
        public IMvxCommand SpeakCommand { get; set; }

        #endregion
    }
}
