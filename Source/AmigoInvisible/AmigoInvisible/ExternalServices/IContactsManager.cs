using AmigoInvisible.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmigoInvisible.ExternalServices
{
    public interface IContactsManager
    {
        ICollection<Participant> GetContacts();
    }
}
