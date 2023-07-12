using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Shared.Notifications;

namespace LevvaCoins.Domain.Shared.Entities
{
    public abstract class Entity: Notice<Notification>
    {
        public Guid Id { get; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
