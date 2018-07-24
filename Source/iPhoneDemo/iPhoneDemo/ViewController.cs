using NGettext;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using UIKit;

namespace iPhoneDemo
{
    public partial class ViewController : UIViewController
    {
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        partial void Button1_TouchUpInside(UIButton sender)
        {
            UpdateDemoText(CultureInfo.CurrentCulture);
        }

        partial void Button2_TouchUpInside(UIButton sender)
        {
            UpdateDemoText(new CultureInfo("en-US"));
        }

        partial void Button3_TouchUpInside(UIButton sender)
        {
            UpdateDemoText(new CultureInfo("zh-CN"));
        }

        private void UpdateDemoText(CultureInfo cultureInfo)
        {
            ICatalog catalog = GetCatalog("Demo", cultureInfo);
            DemoMessages msg = new DemoMessages(catalog);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(msg.HELLO_WORLD());
            sb.AppendLine(msg.APPLE_COUNT_MESAGE(1));
            sb.AppendLine(msg.APPLE_COUNT_MESAGE(2));
            sb.AppendLine(msg.TREE_COUNT_MESAGE(1));    // Not Translated, Fallback to English
            sb.AppendLine(msg.TREE_COUNT_MESAGE(2));    // Not Translated, Fallback to English

            InvokeOnMainThread(() => {
                _UITextView_DemoText.Text = sb.ToString();
            });
        }

        private ICatalog GetCatalog(string domain, CultureInfo cultureInfo)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string filename = string.Format("iPhoneDemo.Resources.Locales.{0}.{1}.mo",
                domain, cultureInfo.ToString().Replace('-', '_'));
            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(filename))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        return new Catalog(ms, cultureInfo);
                    }
                }
            }
            catch (Exception)
            {
                return new Catalog();
            }
        }
    }
}