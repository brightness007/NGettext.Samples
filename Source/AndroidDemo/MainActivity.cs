using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using NGettext;
using System.IO;
using System.Globalization;
using System.Text;

namespace AndroidDemo
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        private TextView _TextView_DemoText;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            _TextView_DemoText = FindViewById<TextView>(Resource.Id.textView_DemoText);

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;

            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button2_Click;

            Button button3 = FindViewById<Button>(Resource.Id.button3);
            button3.Click += Button3_Click;
		}

        private void Button1_Click(object sender, EventArgs e)
        {
            UpdateDemoText(CultureInfo.CurrentCulture);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UpdateDemoText(new CultureInfo("en-US"));
        }

        private void Button3_Click(object sender, EventArgs e)
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

            _TextView_DemoText.Text = sb.ToString();
        }

        private ICatalog GetCatalog(string domain, CultureInfo cultureInfo)
        {
            string filename = string.Format("Locales/{0}.{1}.mo",
                domain, cultureInfo.ToString().Replace('-', '_'));
            try
            {
                using (Stream stream = Assets.Open(filename))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        return new Catalog(ms, cultureInfo);
                    }
                }
            }
            catch(Exception)
            {
                return new Catalog();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

