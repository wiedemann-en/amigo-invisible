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
	public partial class SimulationPage : ContentPage
	{
		public SimulationPage ()
		{
			InitializeComponent();

            RefreshData();

            BtnDoSimulation.Clicked += BtnAddParticipant_Clicked;
            BtnBack.Clicked += BtnBack_Clicked;
        }

        private void BtnAddParticipant_Clicked(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }

        private void RefreshData()
        {
            var raffleManager = new RaffleManager();
            LvSimulation.ItemsSource = null;
            LvSimulation.ItemsSource = raffleManager.SimulateRaffle();
        }
    }
}