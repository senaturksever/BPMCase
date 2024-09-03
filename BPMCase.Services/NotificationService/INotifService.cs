using BPMCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMCase.Services.NotificationService
{
    public interface INotifService
    {
        void NotifyUsersAboutStep<T>(T step);
    }
}
