using AmigoInvisible.ExternalServices;
using AmigoInvisible.Logic;
using AmigoInvisible.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AmigoInvisible
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnSetParticipants.Clicked += BtnSetParticipants_Clicked;
            BtnDoSimulation.Clicked += BtnDoSimulation_Clicked;
            BtnDoRaffle.Clicked += BtnDoRaffle_Clicked;
            BtnNotificationTest.Clicked += BtnNotificationTest_Clicked;
        }

        private void BtnDoSimulation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SimulationPage(), false);
        }

        private void BtnDoRaffle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RafflePage(), false);
        }

        private void BtnSetParticipants_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ParticipantsListPage(), false);
        }

        private void BtnNotificationTest_Clicked(object sender, EventArgs e)
        {
            var smsManager = DependencyService.Get<INotificationManager>();
            smsManager.SendWhatsApp("+541160564676", "Nico", "Nico");
            smsManager.SendEmail("n.wiedemann@hotmail.com", "Nico", "Nico");
        }
    }
}
