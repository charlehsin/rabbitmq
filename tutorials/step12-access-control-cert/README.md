# [Draft] Tutorial for access control using X.509 certificates

This is to let RabbitMQ handle access control by using X.509 certificates. This is assuming that TLS with peer verification is enabled by following step11-tls-peer-verification.

**Warning! The certificates and password exposed here and in the codes are for demo and testing purpose only. Do not use it.**

1. At RabbitMQ server, make sure that the RabbitMQ server is up and running. See [step 1 tutorial](../step1-install-server/README.md).
2. Read through [Authentication, Authorisation, Access Control](https://www.rabbitmq.com/access-control.html) first.

## Reference

- Concept
  - [Queues](https://www.rabbitmq.com/queues.html)
  - [Consumer Acknowledgements and Publisher Confirms](https://www.rabbitmq.com/confirms.html)
  - [Direct Reply-to](https://www.rabbitmq.com/direct-reply-to.html)
  - [TLS Support](https://www.rabbitmq.com/ssl.html)
  - [Authentication, Authorisation, Access Control](https://www.rabbitmq.com/access-control.html)
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
