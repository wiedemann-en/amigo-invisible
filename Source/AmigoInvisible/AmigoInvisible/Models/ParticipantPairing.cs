using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoInvisible.Models
{
    public class ParticipantPairing
    {
        public string Name { get; set; }
        public bool Permitted { get; set; }
        public bool Bidirectional { get; set; }
    }
}
