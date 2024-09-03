using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMCase.Services.NotificationService
{
    public class NotifService : INotifService
    {
        public  void NotifyUsersAboutStep<T>(T step)
        {
            var childSteps = "RabbitMq olabilir";
        }
    }
}
