using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace board_service.Messaging;
using RabbitMQ.Client;
using Microsoft;
using System.Text;
using System;

public class Send
{
    public static void SendMessage(string messageName, string messageContent)
    {
        var factory = new ConnectionFactory() {Uri = new Uri("amqp://guest:guest@localhost:5672")};
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "board",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        var message = new {
            name = messageName,
            content = messageContent
        };
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

        channel.BasicPublish(exchange: "",
            routingKey: "board",
            basicProperties: null,
            body: body);
        Console.WriteLine(" [x] Sent {0}", message);
    }
}