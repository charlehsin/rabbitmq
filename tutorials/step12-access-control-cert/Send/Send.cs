using RabbitMQ.Client;
using System.Text;

class Send
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

        // Set to use External authentication mechanism.
        factory.AuthMechanisms = new [] { new ExternalMechanismFactory() };
        foreach (var auth in factory.AuthMechanisms)
        {
            Console.WriteLine($" New auth mechanism: {auth.Name}");
        }
        Console.WriteLine($" Default virtual host: {factory.VirtualHost}");

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "hello",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        string message = "Hello World!";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: "",
            routingKey: "hello",
            basicProperties: null,
            body: body);
        Console.WriteLine(" [x] Sent {0}", message);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}