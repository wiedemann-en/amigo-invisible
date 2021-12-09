using AmigoInvisible.ExternalServices;
using AmigoInvisible.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AmigoInvisible.Logic
{
    internal class RaffleManager
    {
        private readonly IContactsManager _contactsManager;
        private readonly INotificationManager _smsManager;

        public RaffleManager()
        {
            _contactsManager = DependencyService.Get<IContactsManager>();
            _smsManager = DependencyService.Get<INotificationManager>();
        }

        public List<Gift> SimulateRaffle()
        {
            var gifts = Raffle();
            return gifts;
        }

        public List<Gift> DoRaffleAndSendSms()
        {
            //var gifts = Raffle();
            var gifts = RaffleHardcode();
            foreach (var item in gifts)
            {
                _smsManager.SendSms(item.NumberFrom, item.NameFrom, item.NameTo);
            }
            return gifts;
        }

        private List<Gift> Raffle()
        {
            List<Participant> participants = _contactsManager.GetContacts().ToList();
            var allParticpantsName = participants.Select(x => x.Name).ToList();
            //var allBannedPairings = participants.Where(x => x.DoesNotGiveTo.Count > 0).ToDictionary(k => k.Name, v => v.DoesNotGiveTo[0]);
            var allBannedPairings = participants
                .Where(x => x.Pairings.Count > 0)
                .SelectMany(x => x.Pairings
                    .Where(pairing => pairing.Permitted == false)
                    .Select(banned => new KeyValuePair<string, string>(x.Name, banned.Name)))
                .ToList();

            var result = SecretSantaGenerator.Generate(allParticpantsName, allBannedPairings);

            var gifts = new List<Gift>();
            if (result.Count == participants.Count)
            {
                foreach (var item in result)
                {
                    var participant = participants.Single(x => x.Name == item.Key);
                    gifts.Add(new Gift(participant.Number, participant.Name, item.Value));
                }
            }

            return gifts;
        }

        private List<Gift> RaffleHardcode()
        {
            var gifts = new List<Gift>()
            {
                new Gift("+541166417726", "Artur", "Clau"),
                new Gift("+541165094568", "Bri", "Cris"),
                new Gift("+541132026956", "Caro", "Cyn"),
                new Gift("+541150110614", "Clau", "Mel"),
                new Gift("+541141655143", "Cris", "Jesi"),
                new Gift("+541168596541", "Cyn", "Dario"),
                new Gift("+541169334190", "Dario", "Nico"),
                new Gift("+541159946074", "Jesi", "Caro"),
                new Gift("+541153259426", "Mel", "Artur"),
                new Gift("+541160564676", "Nico", "Bri")
            };
            return gifts;
        }
    }
}
