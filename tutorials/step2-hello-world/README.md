# Tutorial for the most basic usage

1. Make sure that the RabbitMQ server is up and running. See [step 1 tutorial](../step1-install-server/README.md).
   - Follow [How to Find Config File Location](https://www.rabbitmq.com/configure.html#verify-configuration-config-file-location) to find out where is the config file path. Check RabbitMQ configuration rabbitmq.conf that the SSL is not enabled.
2. Install the target .NET SDK or Runtime from [Download .NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0). After installation, run "dotnet --info" to verify.
3. Follow [Hello World tutorial](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html).

## Reference

- [Connecting to RabbitMQ](https://www.rabbitmq.com/dotnet-api-guide.html#connecting)
- [Using Exchanges and Queues](https://www.rabbitmq.com/dotnet-api-guide.html#exchanges-and-queues)
- [Publishing Messages](https://www.rabbitmq.com/dotnet-api-guide.html#publishing)
- [Retrieving Messages By Subscription ("push API")](https://www.rabbitmq.com/dotnet-api-guide.html#consuming)
