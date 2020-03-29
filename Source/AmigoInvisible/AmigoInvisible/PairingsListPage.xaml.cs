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
	public partial class PairingsListPage : ContentPage
	{
		public PairingsListPage(int participantIndex)
		{
			InitializeComponent();

            BtnBack.Clicked += BtnBack_Clicked;

            var participant = ParticipantsManager.GetParticipant(participantIndex);
            LblParticipant.Text = participant.Name;
            LvPairings.ItemsSource = participant.Pairings;
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }
    }
}