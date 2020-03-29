using AmigoInvisible.Logic;
using AmigoInvisible.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmigoInvisible
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParticipantsListPage : ContentPage
	{
        public ParticipantsListPage()
        {
            InitializeComponent();

            BtnAddParticipant.Clicked += BtnAddParticipant_Clicked;
            BtnBack.Clicked += BtnBack_Clicked;

            //LvParticipants.RefreshCommand = new Command(() => {
            //    RefreshData();
            //    LvParticipants.IsRefreshing = false;
            //});
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LvParticipants.ItemsSource = ParticipantsManager.Participants;
        }

        public void DeleteParticipant(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string index = button.CommandParameter.ToString();
            ParticipantsManager.RemoveParticipant(int.Parse(index));
            RefreshData();
        }

        private void PairingsParticipant(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string index = button.CommandParameter.ToString();
            Navigation.PushAsync(new PairingsListPage(int.Parse(index)), false);
        }

        //Only Numbers
        //https://stackoverflow.com/questions/44475667/is-it-possible-specify-xamarin-forms-entry-numeric-keyboard-without-comma-or-dec

        private void BtnAddParticipant_Clicked(object sender, EventArgs e)
        {
            var contactName = TxtContactName.Text?.Trim();
            var contactEmail = TxtContactEmail.Text?.Trim();
            var contactNumber = TxtContactNumber.Text?.Trim();
            contactNumber = contactNumber?.Replace(" ", string.Empty);

            //Dejamos solo números
            var digitsOnly = new Regex(@"[^\d]");
            contactNumber = digitsOnly.Replace(contactNumber, string.Empty);

            if (string.IsNullOrEmpty(contactNumber))
                return;

            if (ParticipantsManager.ExistsNumber(contactNumber))
                return;

            if (!contactNumber.StartsWith("+54"))
                contactNumber = "+54" + contactNumber;

            ParticipantsManager.AddParticipant(contactName, contactNumber, contactEmail);

            TxtContactName.Text = string.Empty;
            TxtContactNumber.Text = string.Empty;
            TxtContactEmail.Text = string.Empty;

            RefreshData();
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }

        private void RefreshData()
        {
            LvParticipants.ItemsSource = null;
            LvParticipants.ItemsSource = ParticipantsManager.Participants;
        }
    }
}