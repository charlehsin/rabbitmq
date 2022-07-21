using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

class Receive
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        // Enable TLS with peer verification
        // Warning!: The following certs and files are for dev/testing only and should not be used in production.
        // Since the password for the pfx is exposed here, you should follow the steps here to create your own certs and files and use the included ones only as reference.
        factory.Ssl.Enabled = true;
        factory.Ssl.ServerName = "localhost";
        factory.Ssl.CertPath = "../certs/localhost.pfx";
        factory.Ssl.CertPassphrase = "P@ssw0rd";

        // Check the authentication mechanism
        foreach (var auth in factory.AuthMechanisms)
        {
            Console.WriteLine($" Original auth mechanism: {auth.Name}");
        }
        Console.WriteLine($" Default virtual host: {factory.VirtualHost}");

        // Set to use External authentication mechanism.
        factory.AuthMechanisms = new [] { new ExternalMechanismFactory() };
        foreach (var auth in factory.AuthMechanisms)
        {
            Console.WriteLine($" New auth mechanism: {auth.Name}");
        }

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
