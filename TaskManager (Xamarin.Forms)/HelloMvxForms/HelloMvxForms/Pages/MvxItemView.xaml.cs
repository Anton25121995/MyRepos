using HelloMvxForms.Constants;
using HelloMvxForms.Core.ViewModels;
using HelloMvxForms.Interfaces;
using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Attributes;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace HelloMvxForms.Core.Views
{
    [MvxContentPagePresentation]
    public partial class MvxItemView : MvxContentPage<MvxItemViewModel>
    {
        public MvxItemView()
        {
            InitializeComponent();
            takePhoto.Clicked += OnActionSheetSimpleClicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void OnActionSheetSimpleClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            var action = await DisplayActionSheet("Add photo from", Constant.CancelPicking, null, Constant.PickFromCamera, Constant.PickFromGallery);
            Debug.WriteLine("Action: " + action);
            if (action == Constant.PickFromCamera)
            {
                PickFromCamera();
            }
            if (action == Constant.PickFromGallery)
            {
                PickFromGallery();
            }
        }

        void OnSpeakClicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISpeechService>().Speak(titleEntry.Text + "  " + descriptionEntry.Text);
        }

        private async void PickFromCamera()
        {
            if (CrossMedia.Current.IsCameraAvailable)
            {
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

                var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

                if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
                {
                    var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Directory = "Pictures",
                    });

                    if (photo != null)
                    {
                        PhotoView.Source = ImageSource.FromFile(photo.Path);
                        ViewModel.ImagePath = photo.Path;
                    }
                }
            }
        }

        private async void PickFromGallery()
        {
            await CrossPermissions.Current.RequestPermissionsAsync(Permission.Photos);
            //await CrossPermissions.Current.RequestPermissionsAsync(Permission.MediaLibrary);

            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            var photoStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (storageStatus == PermissionStatus.Granted && photoStatus == PermissionStatus.Granted)
            {
                var photo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Small
                });

                if (photo != null)
                {
                    PhotoView.Source = ImageSource.FromFile(photo.Path);
                    ViewModel.ImagePath = photo.Path;
                }
            }
        }
    }
}
