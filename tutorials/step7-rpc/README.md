# Tutorial for RPC

This is to achieve request and reply.

1. Make sure that the RabbitMQ server is up and running. See [step 1 tutorial](../step1-install-server/README.md).
   - Follow [How to Find Config File Location](https://www.rabbitmq.com/configure.html#verify-configuration-config-file-location) to find out where is the config file path. Check RabbitMQ configuration rabbitmq.conf that the SSL is not enabled.
2. Install the target .NET SDK or Runtime from [Download .NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0). After installation, run "dotnet --info" to verify.
3. Follow [Request-Reply pattern](https://www.enterpriseintegrationpatterns.com/patterns/messaging/RequestReply.html) and [Remote procedure call](https://www.rabbitmq.com/tutorials/tutorial-six-dotnet.html).

## Reference

- Concept
  - [Queues](https://www.rabbitmq.com/queues.html)
  - [Consumer Acknowledgements and Publisher Confirms](https://www.rabbitmq.com/confirms.html)
  - [Direct Reply-to](https://www.rabbitmq.com/direct-reply-to.html)
  - Producer
    - [Exchange types](https://www.rabbitmq.com/tutorials/amqp-concepts.html#exchanges)
  - Consumer
    - [Consumer Prefetch](https://www.rabbitmq.com/consumer-prefetch.html)
- API Guide
  - [Namespace RabbitMQ.Client](https://rabbitmq.github.io/rabbitmq-dotnet-client/api/RabbitMQ.Client.html)
  - [Connecting to RabbitMQ](https://www.rabbitmq.com/dotnet-api-guide.html#connecting)
  - [Using Exchanges and Queues](https://www.rabbitmq.com/dotnet-api-guide.html#exchanges-and-queues)
  - Producer
    - [Publishing Messages](https://www.rabbitmq.com/dotnet-api-guide.html#publishing)
  - Consumer
    - [Retrieving Messages By Subscription ("push API")](https://www.rabbitmq.com/dotnet-api-guide.html#consuming)
