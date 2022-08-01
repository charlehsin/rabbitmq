# Tutorial for running RabbitMQ server as a Docker container

This is to run RabbitMQ server as a Docker container.

1. Read through [Downloading and Installing RabbitMQ](https://www.rabbitmq.com/download.html) and [RabbitMQ at Docker Hub](https://registry.hub.docker.com/_/rabbitmq).
2. Make sure that your Docker is installed. Some useful Docker commands.
   - Start Docker
      - wsl -u root sudo service docker start
   - List containers
      - wsl -u root docker container ls
   - List images
      - wsl -u root docker image ls
   - Stop a container
      - wsl -u root docker container stop [container id]
   - Remove an image
      - wsl -u root docker image rm [image id]
   - Run RabbitMQ server image
      - wsl -u root docker run -it --rm --name rabbitmq -p 5673:5672 -p 15673:15672 rabbitmq:3.10-management
3. Make sure that the RabbitMQ server is up and running. See [step 1 tutorial](../step1-install-server/README.md). However, the Management UI port for our container is 15673 instead of 15672, based on our Docker command.
4. Check the client codes at Receive folder and Send folder. They are the basic hello world example from step2-hello-world with modification to connecting to port 5673 instead of the default 5672, based on our Docker command.

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
