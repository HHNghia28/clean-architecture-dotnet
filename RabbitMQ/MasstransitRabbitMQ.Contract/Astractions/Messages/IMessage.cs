using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasstransitRabbitMQ.Contract.Astractions.Messages
{
    public interface IMessage
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
