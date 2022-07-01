using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

class Receive
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        // Enable TLS without peer verification
        factory.Ssl.Enabled = true;
        factory.Ssl.ServerName = "localhost";

        // Check the authentication mechanism
        foreach (var auth in factory.AuthMechanisms)
        {
            Console.WriteLine($" Auth mechanism: {auth.Name}");
        }

        // Check some default authentication properties.
        Console.WriteLine($" Default username: {factory.UserName}");
        Console.WriteLine($" Default password: {factory.Password}");
        Console.WriteLine($" Default virtual host: {factory.VirtualHost}");

        // Set the new authentication username and password to use.
        // Warning! The username and password exposed here are for demo and testing purpose only. Do not use it.
        Console.WriteLine($" Setting new username and password...");
        factory.UserName = "tester1";
        factory.Password = "tester1234";

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "hello",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);
        };
        channel.BasicConsume(
            queue: "hello",
            autoAck: true,
            consumer: consumer);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
