using AVFoundation;
using CoreGraphics;
using Foundation;
using ImageIO;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views.Presenters.Attributes;
using System;
using System.IO;
using TestProject.Core.ViewModels;
using TestProject.iOS.Converters;
using TestProject.iOS.ViewControllers.Base;
using UIKit;

namespace TestProject.iOS.ViewControllers.Item
{
    [MvxModalPresentation(Animated = false)]
    public partial class ItemViewController : BaseViewController<ItemViewModel>
    {
        UIImagePickerController picker;
        UIAlertView alertError;
        UIAlertView alertOptions;

        public string ImageToString { get; set; }

        public string ImageURL { get; set; }

        public ItemViewController() : base("ItemViewController", null)
        {

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitAlertCameraError();
            InitAlertPickingPhoto();

            isDoneSwitch.ValueChanged += SetSwitch;
            pickButton.TouchUpInside += ShowOptions;

            var set = this.CreateBindingSet<ItemViewController, ItemViewModel>();

            set.Bind(backbutton).To(vm => vm.GoBackCommand);
            set.Bind(titleTextField).To(vm => vm.Item.Title);
            set.Bind(descriptionTextField).To(vm => vm.Item.Description);
            set.Bind(isDoneSwitch).For(v => v.On).To(vm => vm.Item.IsDone);
            set.Bind(cancelButton).To(vm => vm.CancelChangesCommand);
            set.Bind(saveButton).To(vm => vm.ItemChangedCommand);
            set.Bind(deleteButton).To(vm => vm.ItemDeleteCommand);
            set.Bind(userPhotoImageView).For(v => v.Image).To(vm => vm.Item.ImageName).WithConversion<FromPathToUIImageConverter>();

            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public void Finished(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceURL")] as NSUrl;
            Console.WriteLine("Url:" + referenceURL?.ToString());

            UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
            if (originalImage != null)
            {
                ViewModel.ByteArray = (originalImage.AsPNG()).ToArray();
            }
            picker.DismissModalViewController(true);
        }

        void Canceled(object sender, EventArgs e)
        {
            picker.DismissModalViewController(true);
        }

        private void ShowOptions(object sender, EventArgs e)
        {
            alertOptions.Show();
        }

        private void SetSwitch(object sender, EventArgs e)
        {
            isDoneSwitch.SetState(isDoneSwitch.On, true);
        }

        private void ChooseFromCamera()
        {
            if (IsDevice())
            {
                picker = new UIImagePickerController();
                picker.SourceType = UIImagePickerControllerSourceType.Camera;
                picker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);
                picker.FinishedPickingMedia += Finished;
                picker.Canceled += Canceled;
                NavigationController.PresentModalViewController(picker, true);
            }
            else
            {
                alertError.Show();
            }
        }

        public void ChooseFromGallery()
        {
            picker = new UIImagePickerController();
            picker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            picker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
            picker.FinishedPickingMedia += Finished;
            picker.Canceled += Canceled;
            PresentViewController(picker, animated: true, completionHandler: null);
        }

        public void InitAlertCameraError()
        {
            alertError = new UIAlertView();
            alertError.Title = "Camera error";
            alertError.Message = "You can't use camera, because you are running on simulator";
            alertError.AddButton("OK");
        }

        public void InitAlertPickingPhoto()
        {
            alertOptions = new UIAlertView();
            alertOptions.Title = "Choose from";
            alertOptions.AddButton("From gallery");
            alertOptions.AddButton("From Camera");
            alertOptions.AddButton("Cancel");
            alertOptions.Clicked += AlertOptionsClicked;
        }

        private void AlertOptionsClicked(object sender, UIButtonEventArgs e)
        {
            var index = e.ButtonIndex;
            if (index == 0)
            {
                ChooseFromGallery();
            }
            if (index == 1)
            {
                ChooseFromCamera();
            }
        }

        public bool IsDevice()
        {
            string status = ObjCRuntime.Runtime.Arch.ToString();
            return status != "SIMULATOR";
        }

        public void ConvertImageToArray(UIImage image)
        {
            var data = image.AsJPEG();
            var dataBytes = data.ToArray();
            ViewModel.ByteArray = dataBytes;
        }

    }
}