# Tutorial for access control using X.509 certificates

This is to let RabbitMQ handle access control by using X.509 certificates. This is assuming that TLS with peer verification is enabled by following step11-tls-peer-verification.

**Warning! The certificates and password exposed here and in the codes are for demo and testing purpose only. Do not use it.**

1. Read through [Authentication, Authorisation, Access Control](https://www.rabbitmq.com/access-control.html) first.
2. At RabbitMQ .NET client
   1. Install the target .NET SDK or Runtime from [Download .NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0). After installation, run "dotnet --info" to verify.
   2. The codes in Receive folder and Send folder are based on step11-tls-peer-verification. Search for "authentication" in codes to find out extra changes for this tutorial. The extra changes are based on the following
      - [Mechanism Configuration in .NET](https://www.rabbitmq.com/access-control.html#client-mechanism-configuration-dotnet)
      - [Connecting to RabbitMQ](https://www.rabbitmq.com/dotnet-api-guide.html#connecting)
3. At RabbitMQ server
   1. Make sure that the RabbitMQ server is up and running. See [step 1 tutorial](../step1-install-server/README.md).
   2. At RabbitMQ Command Prompt, run the following to enable the required plugin and see the list of enabled plugins. Make sure that rabbitmq_auth_mechanism_ssl is in the list.
      - rabbitmq-plugins enable rabbitmq_auth_mechanism_ssl
      - rabbitmq-plugins list -e
   3. Follow [How to Find Config File Location](https://www.rabbitmq.com/configure.html#verify-configuration-config-file-location) to find out where is the config file path.
   4. At that config file location found in previous step, update (or create) the rabbitmq.conf file.
      - Use the included rabbitmq.conf file as reference, which is based on [rabbitmq/rabbitmq-auth-mechanism-ssl](https://github.com/rabbitmq/rabbitmq-auth-mechanism-ssl).
   5. Since our RabbitMQ server is installed on Windows, restart RabbitMQ windows service to use the rabbitmq.config file.
4. At RabbitMQ .NET client
   1. Use 2 Git bashes to run the following commands at Receive folder and at Send folder. Should see error about "ACCESS_REFUSED".
      - dotnet run
5. At RabbitMQ server, create a password-less user with name localhost, matching the common name of the client certificate.
   1. At RabbitMQ Command Prompt, run the following to see the list of users.
      - rabbitmqctl list_users
   2. At RabbitMQ Command Prompt, run the following to add a new password-less user localhost. Check [Passwordless Users](https://www.rabbitmq.com/passwords.html#passwordless-users). After this, run the command above to check the user is added.
      - rabbitmqctl add_user localhost tester1234
      - rabbitmqctl clear_password localhost
   3. At RabbitMQ Command Prompt, run the following to see the current permissions.
      - rabbitmqctl list_permissions
   4. At RabbitMQ Command Prompt, run the following to grant permission for user localhost to virtual host /. After this, run the command above to check the permissions are added.
      - rabbitmqctl set_permissions -p "/" "localhost" ".*" ".*" ".*"
6. At RabbitMQ .NET client
   1. Use 2 Git bashes to run the following commands at Receive folder and at Send folder. Verify that the message is received.
      - dotnet run
7. At RabbitMQ server
   1. At RabbitMQ Command Prompt, run the following to delete the user localhost.
      - rabbitmqctl delete_user localhost

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
