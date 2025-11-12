using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace CreditService.Infrastructure.Messaging
{
    using Microsoft.Extensions.Configuration;

    public class ServiceBusPublisher
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;

        public ServiceBusPublisher(IConfiguration config)
        {
            _client = new ServiceBusClient(config["ServiceBus:ConnectionString"]);
            _sender = _client.CreateSender(config["ServiceBus:TopicName"]);
        }

        public async Task PublishAsync(string message)
        {
            var msg = new ServiceBusMessage(message);
            await _sender.SendMessageAsync(msg);
        }
    }

}
