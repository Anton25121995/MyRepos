// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TestProject.iOS.ViewControllers.Item
{
    [Register ("ItemViewController")]
    partial class ItemViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton backbutton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cancelButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton deleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField descriptionTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch isDoneSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton pickButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton saveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField titleTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userPhotoImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (backbutton != null) {
                backbutton.Dispose ();
                backbutton = null;
            }

            if (cancelButton != null) {
                cancelButton.Dispose ();
                cancelButton = null;
            }

            if (deleteButton != null) {
                deleteButton.Dispose ();
                deleteButton = null;
            }

            if (descriptionTextField != null) {
                descriptionTextField.Dispose ();
                descriptionTextField = null;
            }

            if (isDoneSwitch != null) {
                isDoneSwitch.Dispose ();
                isDoneSwitch = null;
            }

            if (pickButton != null) {
                pickButton.Dispose ();
                pickButton = null;
            }

            if (saveButton != null) {
                saveButton.Dispose ();
                saveButton = null;
            }

            if (titleTextField != null) {
                titleTextField.Dispose ();
                titleTextField = null;
            }

            if (userPhotoImageView != null) {
                userPhotoImageView.Dispose ();
                userPhotoImageView = null;
            }
        }
    }
}