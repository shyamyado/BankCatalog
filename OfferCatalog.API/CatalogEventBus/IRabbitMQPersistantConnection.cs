using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogEventBus
{
    public interface IRabbitMQPersistantConnection
    {
        bool TryConnect();
        void Publish(string eventMsgQueueName, object message);
    }
}
