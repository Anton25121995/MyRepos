using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using TestProject.Core.Models;
using TestProject.Core.ViewModels;
using TestProject.iOS.Converters;
using UIKit;

namespace TestProject.iOS.Cells
{
    public partial class TableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("TableViewCell");
        public static readonly UINib Nib = UINib.FromName("TableViewCell", NSBundle.MainBundle);


        public TableViewCell(IntPtr handle) : base(handle)
        {

        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            var set = this.CreateBindingSet<TableViewCell, Item>();
            set.Bind(titleTextView).For(v => v.Text).To(m => m.Title);
            set.Bind(descriptionTextView).For(v => v.Text).To(m => m.Description);
            set.Bind(userImagePhotoView).For(v => v.Image).To(m => m.ImageName).WithConversion<FromPathToUIImageConverter>();
            set.Bind(isDoneSwitch).For(v => v.On).To(m => m.IsDone);
            set.Apply();
        }
    }
}
