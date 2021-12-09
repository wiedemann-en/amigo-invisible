using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android.Content;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AmigoInvisible.Models;

namespace AmigoInvisible.Droid
{
    [Activity(Label = "Amigo Invisible", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            await TryToGetPermissions();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnDestroy()
        {
            try
            {
                base.OnDestroy();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region Runtime Permissions
        const int RequestLocationId = 0;
        readonly string[] PermissionsGroupLocation =
        {
            //TODO add more permissions
            Manifest.Permission.SendSms,
            Manifest.Permission.ReadContacts,
            Manifest.Permission.ReadPhoneState,
        };

        private async Task TryToGetPermissions()
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                await GetPermissionsAsync();
                return;
            }
        }

        private async Task GetPermissionsAsync()
        {
            const string permission = Manifest.Permission.AccessFineLocation;
            var checkPermission = ActivityCompat.CheckSelfPermission(Application.Context, permission);
            if (checkPermission == Permission.Granted)
            {
                //TODO change the message to show the permissions name
                Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();
                return;
            }

            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, permission))
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetPositiveButton("Request Permissions", (senderAlert, args) =>
                {
                    ActivityCompat.RequestPermissions(this, PermissionsGroupLocation, RequestLocationId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();

                return;
            }

            ActivityCompat.RequestPermissions(this, PermissionsGroupLocation, RequestLocationId);
        }

        public void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == RequestLocationId)
            {
                if (grantResults[0] == (int)Android.Content.PM.Permission.Granted)
                {
                    Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();
                }
                else
                {
                    //Permission Denied :(
                    Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();
                }
            }
            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #endregion
    }
}