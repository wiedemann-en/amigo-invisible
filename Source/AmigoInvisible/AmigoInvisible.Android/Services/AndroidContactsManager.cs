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
            partakers.Add(new Participant(0, "Artur", "+541166417726", new List<string>() { "Cris" }));
            partakers.Add(new Participant(1, "Bri", "+541165094568", new List<string>() { "Dario" }));
            partakers.Add(new Participant(2, "Caro", "+541132026956", new List<string>() { "" }));
            partakers.Add(new Participant(3, "Clau", "+541150110614", new List<string>() { "Cyn" }));
            partakers.Add(new Participant(4, "Cris", "+541141655143", new List<string>() { "Artur" }));
            partakers.Add(new Participant(5, "Cyn", "+541168596541", new List<string>() { "Clau" }));
            partakers.Add(new Participant(6, "Dario", "+541169334190", new List<string>() { "Bri" }));
            partakers.Add(new Participant(7, "Jesi", "+541159946074", new List<string>() { "" }));
            partakers.Add(new Participant(8, "Mel", "+541153259426", new List<string>() { "Nico", "Cyn" }));
            partakers.Add(new Participant(9, "Nico", "+541160564676", new List<string>() { "Mel", "Cyn" }));
            // Familia Dario
            //partakers.Add(new Participant(0, "Bri", "+541165094568", new List<string>() { "Dario" }));
            //partakers.Add(new Participant(1, "Carlos", "+541140619496", new List<string>() { "Patri" }));
            //partakers.Add(new Participant(2, "Caro", "+541169692582", new List<string>() { "Nico" }));
            //partakers.Add(new Participant(3, "Dario", "+541169334190", new List<string>() { "Bri" }));
            //partakers.Add(new Participant(4, "Nico", "+541165609639", new List<string>() { "Caro" }));
            //partakers.Add(new Participant(5, "Patri", "+541162997605", new List<string>() { "Carlos" }));
            return partakers;
        }

        //SELECCION DE CONTACTOS
        //https://developer.xamarin.com/guides/android/platform_features/intro_to_content_providers/contacts-contentprovider/
        //http://sachindotg.blogspot.com/2013/11/android-simple-multi-contacts-picker.html
        //https://redth.codes/using-the-android-contact-picker-with-xamarin/
    }
}