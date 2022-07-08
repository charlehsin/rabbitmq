# Tutorial for access control using username and password

This is to let RabbitMQ handle access control by using username and password. This is assuming that TLS is enabled by following step9-tls.

**Warning! The username and password exposed here and in the codes are for demo and testing purpose only. Do not use it.**

1. At RabbitMQ server, make sure that the RabbitMQ server is up and running. See [step 1 tutorial](../step1-install-server/README.md).
   - Follow [How to Find Config File Location](https://www.rabbitmq.com/configure.html#verify-configuration-config-file-location) to find out where is the config file path. Check RabbitMQ configuration rabbitmq.conf that the SSL is enabled but peer verification is disabled.
2. Read through [Authentication, Authorisation, Access Control](https://www.rabbitmq.com/access-control.html) first.
3. At RabbitMQ .NET client
   1. Install the target .NET SDK or Runtime from [Download .NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0). After installation, run "dotnet --info" to verify.
   2. The codes in Receive folder and Send folder are based on step9-tls. Search for "authentication" in codes to find out extra changes for this tutorial. The extra changes are based on the following
      - [Mechanism Configuration in .NET](https://www.rabbitmq.com/access-control.html#client-mechanism-configuration-dotnet)
      - [Connecting to RabbitMQ](https://www.rabbitmq.com/dotnet-api-guide.html#connecting)
   3. Use 1 Git bash to run the following commands at Receive folder. It still show error about ACCESS_REFUSED since we did not set up the user on the server side yet.
      - dotnet run
4. At RabbitMQ server
   1. At RabbitMQ Command Prompt, run the following to see the list of users.
      - rabbitmqctl list_users
   2. At RabbitMQ Command Prompt, run the following to add a new user tester1 with the specified password. After this, run the command above to check the user is added.
      - rabbitmqctl add_user tester1 tester1234
   3. At RabbitMQ Command Prompt, run the following to see the current permissions.
      - rabbitmqctl list_permissions
   4. At RabbitMQ Command Prompt, run the following to grant permission for user tester1 to virtual host /. After this, run the command above to check the permissions are added.
      - rabbitmqctl set_permissions -p "/" "tester1" ".*" ".*" ".*"
5. At RabbitMQ .NET client
   1. Use 2 Git bashes to run the following commands at Receive folder and at Send folder. Verify that the message is received.
      - dotnet run
6. At RabbitMQ server
   1. At RabbitMQ Command Prompt, run the following to remove the permission of user tester1 from virtual hots /.
      - rabbitmqctl clear_permissions -p "/" "tester1"
5. At RabbitMQ .NET client
   1. Use 1 Git bash to run the following commands at Receive folder. It still show error about NOT_ALLOWED since the user does not have permission on the server side.
      - dotnet run
   2. At RabbitMQ Command Prompt, run the following to delete the user tester1.
      - rabbitmqctl delete_user tester1

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
