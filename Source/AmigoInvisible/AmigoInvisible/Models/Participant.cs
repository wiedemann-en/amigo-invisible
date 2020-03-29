using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoInvisible.Models
{
    public class Participant
    {
        public Participant()
        {
            //BannedPairings = new List<string>();
            Pairings = new List<ParticipantPairing>();
        }

        public Participant(int index, string name, string number, List<string> bannedPairings)
        {
            Index = index;
            Name = name;
            Number = number;
            //BannedPairings = bannedPairings ?? new List<string>();
            Pairings = new List<ParticipantPairing>();

            if (bannedPairings != null)
            {
                Pairings = bannedPairings.Select(x => new ParticipantPairing()
                {
                    Bidirectional = true,
                    Name = x,
                    Permitted = false
                }).ToList();
            }
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        //public List<string> BannedPairings { get; set; }
        public List<ParticipantPairing> Pairings { get; set; }

        public string Resume => $"{Name}: {Number}";
    }
}
