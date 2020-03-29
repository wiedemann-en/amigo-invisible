using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmigoInvisible.ExternalServices
{
    public interface INotificationManager
    {
        bool SendSms(string number, string nameFrom, string nameTo);
        bool SendWhatsApp(string number, string nameFrom, string nameTo);
        bool SendEmail(string email, string nameFrom, string nameTo);
    }
}
