using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views.Attributes;
using TestProject.Core.ViewModels;

namespace TestProject.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), 2131296402, true)]
    [Register("App1.Android.Fragments.ItemViewLayout")]
    public class ItemFragment : BaseFragment<ItemViewModel>
    {
        protected override int FragmentId => 2130968618;
        Button createButton;
        CheckBox checkbox;
        private ImageButton image;
        private int _galleryRequestCode = 2;
        private int _takeRequestCode = 1;
        //private ImageView imageOnTable;

        private Button addPhotoButton;
        private MvxImageView photoView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            addPhotoButton = (Button)view.FindViewById(2131296395);
            photoView = (MvxImageView)view.FindViewById(2131296394);

            addPhotoButton.Click += onAddPhotoClicked;
            return view;
        }

        public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            int width = 300;
            int height = 300;
            if (requestCode == _takeRequestCode && resultCode == Result.Ok)
            {
                Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                bitmap = Bitmap.CreateScaledBitmap(bitmap, width, height, true);
                //photoView.SetImageBitmap(bitmap);

                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                    ViewModel.ByteArray = stream.ToArray();
                }

            }
            else if (requestCode == _galleryRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    try
                    {
                        Bitmap bitmap = MediaStore.Images.Media.GetBitmap(Activity.ContentResolver, data.Data);
                        bitmap = Bitmap.CreateScaledBitmap(bitmap, width, height, true);
                        //photoView.SetImageBitmap(bitmap);
                        using (MemoryStream stream = new MemoryStream())
                        {
                            bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                            ViewModel.ByteArray = stream.ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                    return;
                }
            }
        }

        void onAddPhotoClicked(object sender, EventArgs e)
        {
            var popup = new PopupMenu(Activity, addPhotoButton);
            popup.Menu.Add("Camera");
            popup.Menu.Add("Gallery");
            popup.Menu.Add("Cancel");
            popup.MenuItemClick += onMenuItemClicked;
            popup.Show();
        }

        void onMenuItemClicked(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            var label = e.Item.TitleFormatted.ToString();
            if (label == "Camera")
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, _takeRequestCode);
            }
            else if (label == "Gallery")
            {
                var intent = new Intent(Intent.ActionPick);
                intent.SetType("image/*");
                intent.PutExtra(Intent.ExtraAllowMultiple, true);
                intent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(intent, _galleryRequestCode);
            }
        }
    }
}