using AmigoInvisible.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoInvisible.Logic
{
    static class ParticipantsManager
    {
        //ObservableCollection<Participant> _participants = new ObservableCollection<Participant>();
        //private ObservableCollection<Participant> _participants;
        //public ObservableCollection<Participant> Participants
        //{
        //    get { return _participants ?? (_participants = new ObservableCollection<Participant>()); }
        //    set
        //    {
        //        _participants = value;
        //        OnPropertyChanged();
        //    }
        //}

        private static List<Participant> _participants;

        static ParticipantsManager()
        {
            _participants = new List<Participant>();
        }

        public static List<Participant> Participants => _participants;

        public static bool ExistsNumber(string number)
        {
            return _participants.Any(x => x.Number == number);
        }

        public static void AddParticipant(Participant participant)
        {
            ParticipantsManager.AddParticipantPairing(participant);
            _participants.Add(participant);
        }

        public static void AddParticipant(string name, string phoneNumner, string email)
        {
            var participantToAdd = new Participant(_participants.Count + 1, name, phoneNumner, null);
            participantToAdd.Email = email;
            ParticipantsManager.AddParticipantPairing(participantToAdd);
            _participants.Add(participantToAdd);
        }

        public static void RemoveParticipant(int index)
        {
            var itemToRemove = _participants.SingleOrDefault(x => x.Index == index);
            if (itemToRemove != null)
            {
                ParticipantsManager.RemoveParticipantPairing(itemToRemove);
                _participants.Remove(itemToRemove);
                ParticipantsManager.ResetIndexs();
            }
        }

        public static Participant GetParticipant(int index)
        {
            var participant = _participants.SingleOrDefault(x => x.Index == index);
            return participant;
        }

        public static Participant GetParticipant(string number)
        {
            var participant = _participants.SingleOrDefault(x => x.Number == number);
            return participant;
        }

        private static void AddParticipantPairing(Participant participant)
        {
            foreach (var item in _participants)
            {
                var pairingToAdd = new ParticipantPairing();
                pairingToAdd.Name = participant.Name;
                pairingToAdd.Permitted = true;
                pairingToAdd.Bidirectional = true;
                item.Pairings.Add(pairingToAdd);
            }
        }

        private static void RemoveParticipantPairing(Participant participant)
        {
            foreach (var item in _participants)
            {
                var itemsToRemove = item.Pairings.Where(x => x.Name == participant.Name);
                foreach (var itemToRemove in itemsToRemove)
                    item.Pairings.Remove(itemToRemove);
            }
        }

        private static void ResetIndexs()
        {
            foreach (var participant in _participants)
                participant.Index = _participants.IndexOf(participant) + 1;
            //for (int iPos = 0; iPos < _participants.Count; iPos++)
            //    _participants[iPos].Index = iPos + 1;
        }
    }
}
