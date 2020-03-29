using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmigoInvisible.Models;
using AmigoInvisible.ExternalServices;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AmigoInvisible.Droid.Services
{
    public class AndroidContactsManager : IContactsManager
    {
        public ICollection<Participant> GetContacts()
        {
            var partakers = new List<Participant>();
            partakers.Add(new Participant(0, "Name-001", "+541122223333", new List<string>() { "Name-002" }));
            partakers.Add(new Participant(1, "Name-002", "+541122223333", new List<string>() { "Name-001" }));
            partakers.Add(new Participant(2, "Name-003", "+541122223333", new List<string>() { "Name-004" }));
            partakers.Add(new Participant(3, "Name-004", "+541122223333", new List<string>() { "Name-003" }));
            return partakers;
        }

        //SELECCION DE CONTACTOS
        //https://developer.xamarin.com/guides/android/platform_features/intro_to_content_providers/contacts-contentprovider/
        //http://sachindotg.blogspot.com/2013/11/android-simple-multi-contacts-picker.html
        //https://redth.codes/using-the-android-contact-picker-with-xamarin/
    }
}