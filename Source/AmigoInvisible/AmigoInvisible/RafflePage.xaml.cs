using AmigoInvisible.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmigoInvisible
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RafflePage : ContentPage
	{
		public RafflePage ()
		{
			InitializeComponent();

            RefreshData();

            BtnDoRaffle.Clicked += BtnDoRaffle_Clicked;
            BtnBack.Clicked += BtnBack_Clicked;

            LvParticipants.IsVisible = true;
            BtnDoRaffle.IsVisible = true;
            SlRaffleResult.IsVisible = false;
        }

        private void BtnDoRaffle_Clicked(object sender, EventArgs e)
        {
            var raffleManager = new RaffleManager();
            var result = raffleManager.DoRaffleAndSendSms();

            LvParticipants.IsVisible = false;
            BtnDoRaffle.IsVisible = false;
            SlRaffleResult.IsVisible = true;
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