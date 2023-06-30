using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Shared.Notifications
{
    public class Notification
    {
        public string Key { get; set; }
        public string Message { get; set; }

        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
