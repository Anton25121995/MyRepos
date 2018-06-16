// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TestProject.iOS.Cells
{
    [Register ("TableViewCell")]
    partial class TableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView descriptionTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch isDoneSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView opaqueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView titleTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userImagePhotoView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (descriptionTextView != null) {
                descriptionTextView.Dispose ();
                descriptionTextView = null;
            }

            if (isDoneSwitch != null) {
                isDoneSwitch.Dispose ();
                isDoneSwitch = null;
            }

            if (opaqueLabel != null) {
                opaqueLabel.Dispose ();
                opaqueLabel = null;
            }

            if (titleTextView != null) {
                titleTextView.Dispose ();
                titleTextView = null;
            }

            if (userImagePhotoView != null) {
                userImagePhotoView.Dispose ();
                userImagePhotoView = null;
            }
        }
    }
}