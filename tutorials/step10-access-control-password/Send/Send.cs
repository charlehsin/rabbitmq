using RabbitMQ.Client;
using System.Text;

class Send
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