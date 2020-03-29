using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmigoInvisible.ExternalServices;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using Plugin.Messaging;
using Uri = Android.Net.Uri;

namespace AmigoInvisible.Droid.Services
{
    public class AndroidNotificationManager : INotificationManager
    {
        public bool SendEmail(string email, string nameFrom, string nameTo)
        {
            var result = true;
            try
            {
                //var emailIntent = new Intent(Intent.ActionSend);
                //emailIntent.PutExtra(Intent.ExtraEmail, email);
                ////if (cc != null)
                ////    emailIntent.PutExtra(Intent.ExtraCc, cc.ToArray());
                //emailIntent.PutExtra(Intent.ExtraSubject, "Test Xamarin");
                //emailIntent.PutExtra(Intent.ExtraText, "Test");
                //emailIntent.PutExtra(Intent.ExtraHtmlText, true);
                //emailIntent.SetType("message/rfc822");

                //var currentContext = Android.App.Application.Context;
                //currentContext.StartActivity(emailIntent);

                //Xam.Plugins.Messaging.
                var emailTask = CrossMessaging.Current.EmailMessenger;
                if (emailTask.CanSendEmail)
                {
                    // Send simple e-mail to single receiver without attachments, CC, or BCC.
                    emailTask.SendEmail("n.wiedemann@hotmail.com", "Xamarin Messaging Plugin", "Hello from your friends at Xamarin!");

                    // Send a more complex email with the EmailMessageBuilder fluent interface.
                    //var emailBuilder = new EmailMessageBuilder()
                    //  .To("plugins@xamarin.com")
                    //  .Cc("plugins.cc@xamarin.com")
                    //  .Bcc(new[] { "plugins.bcc@xamarin.com", "plugins.bcc2@xamarin.com" })
                    //  .Subject("Xamarin Messaging Plugin")
                    //  .Body("Hello from your friends at Xamarin!")
                    //  .Build();

                    //emailTask.SendEmail(emailBuilder);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool SendSms(string number, string nameFrom, string nameTo)
        {
            var result = true;
            try
            {
                SmsManager sms = SmsManager.Default;
                PendingIntent sentPI;
                String SENT = "SMS_SENT";

                sentPI = PendingIntent.GetBroadcast(Application.Context, 0, new Intent(SENT), 0);

                var message = $"Eh amigo! Te toca gastar unos $$$ en {nameTo.ToUpper()}!";
                sms.SendTextMessage(number, null, message, sentPI, null);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool SendWhatsApp(string number, string nameFrom, string nameTo)
        {
            var result = true;
            try
            {
                var currentContext = Android.App.Application.Context;

                //Intent sendIntent = new Intent(Intent.ActionSendto, Uri.Parse("smsto:" + "" + number + "?body=Sarasa" + ""));
                //sendIntent.SetPackage("com.whatsapp");
                //currentContext.StartActivity(sendIntent);

                try
                {
                    Intent myIntent = new Intent("android.intent.action.MAIN");
                    myIntent.SetComponent(new ComponentName("com.whatsapp", "com.whatsapp.Conversation"));
                    myIntent.PutExtra("abcsdadasd", PhoneNumberUtils.StripSeparators("+54 9 11 60564676") + "@s.whatsapp.net");
                    currentContext.StartActivity(myIntent);
                }
                catch (Exception ex)
                {
                    result = false;
                }

                try
                {
                    String text = "This is a test";// Replace with your message.
                    Intent intent = new Intent();
                    intent.SetAction(Intent.ActionSend);
                    intent.PutExtra(Intent.ExtraText, "This is my text to send.");
                    intent.SetType("text/plain");
                    intent.SetData(Uri.Parse("http://api.whatsapp.com/send?phone=" + number + "&text=" + text));
                    currentContext.StartActivity(intent);
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        //EMAIL
        //https://www.nuget.org/packages/Xam.Plugins.Messaging/
        //https://blog.xamarin.com/cross-platform-messaging-for-ios-android-and-windows/
        //https://docs.microsoft.com/en-us/xamarin/essentials/email?tabs=android
        //https://forums.xamarin.com/discussion/19756/send-email-from-shared-code-in-xamarin-forms

        //WHATSAPP
        //https://www.twilio.com/blog/send-a-whatsapp-message-with-c-in-30-seconds
        //https://mobikul.com/sending-message-application-whatsapp-number/
    }
}