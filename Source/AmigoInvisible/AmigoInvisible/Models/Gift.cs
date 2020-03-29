using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoInvisible.Models
{
    public class Gift
    {
        public Gift()
        {
        }

        public Gift(string numberFrom, string nameFrom, string nameTo)
        {
            NumberFrom = numberFrom;
            NameFrom = nameFrom;
            NameTo = nameTo;
        }

        public string NumberFrom { get; set; }
        public string NameFrom { get; set; }
        public string NameTo { get; set; }

        public string Resume => $"{NameFrom.ToUpper()} le regala a -> {NameTo.ToUpper()}";
    }
}
