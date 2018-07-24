// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iPhoneDemo
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView _UITextView_DemoText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton button1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton button2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton button3 { get; set; }

        [Action ("Button1_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Button1_TouchUpInside (UIKit.UIButton sender);

        [Action ("Button2_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Button2_TouchUpInside (UIKit.UIButton sender);

        [Action ("Button3_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Button3_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_UITextView_DemoText != null) {
                _UITextView_DemoText.Dispose ();
                _UITextView_DemoText = null;
            }

            if (button1 != null) {
                button1.Dispose ();
                button1 = null;
            }

            if (button2 != null) {
                button2.Dispose ();
                button2 = null;
            }

            if (button3 != null) {
                button3.Dispose ();
                button3 = null;
            }
        }
    }
}