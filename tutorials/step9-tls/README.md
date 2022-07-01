# Tutorial for using TLS

This is to let RabbitMQ handle TLS connection.

**Warning!: To keep things simple, we are not using peer verification in this tutorial.**

## RabbitMQ server

1. Make sure that the RabbitMQ server is up and running. See [step 1 tutorial](../step1-install-server/README.md).
2. Read through [TLS Support](https://www.rabbitmq.com/ssl.html) first.
3. Check [How to: Create Temporary Certificates for Use During Development](https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-create-temporary-certificates-for-use-during-development) to create the dev certificates. **Warning!: The following certs and files are for dev/testing only and should not be used in production. Since the password for the pfx is exposed here, you should follow the steps here to create your own certs and files and use the included ones only as reference.**
   1. Use the included create-dev-certs.ps1 to create the 2 dev/testing certs.
   2. Go to Windows Certificate Store Local Computer \ Personal and export the "DevRootCA" cert without private key into a .p7b file. This file is included in .\certs folder here for reference.
   3. Go to Windows Certificate Store Local Computer \ Personal and export the "localhost" cert (issued by DevRootCA) with private key into a .pfx file. This file is included in .\certs folder here for reference. The password is P@ssw0rd.
   4. Go to Windows Certificate Store Local Computer \ Personal and export the "DevRootCA" cert with private key and then import it into Windows Certificate Store Local Computer \ Trusted Root Certification Authorities. Remove this cert from Windows Certificate Store Local Computer \ Personal.
4. Then we need to general the certs and key files needed by RabbitMQ. The openssl.exe is already included in Git installation, so it is available in Git Bash. Open GitBash and go to certs folder under this readme file's folder. Run openssl to enter openssl shell and run the following commands.
   - pkcs7 -print_certs -inform der -in .\DevRootCA.p7b -out .\DevRootCA.pem
   - pkcs12 -in .\localhost.pfx -nokeys -out .\localhost.pem -nodes
   - pkcs12 -in .\localhost.pfx -nocerts -out .\private.pem -nodes
5. Follow [How to Find Config File Location](https://www.rabbitmq.com/configure.html#verify-configuration-config-file-location) to run the following command in RabbitMQ Command Prompt to find out where is the config file path.
   - rabbitmq-diagnostics status
6. At that config file location found in previous step, update (or create) the rabbitmq.conf file.
   - Use the included rabbitmq.conf file as reference.
7. Since our RabbitMQ server is installed on Windows, restart RabbitMQ windows service to use the rabbitmq.confi file.
8. After the service is restarted, follow [How to Verify that TLS is Enabled](https://www.rabbitmq.com/ssl.html#enabling-tls-verify-configuration) to run the following command in RabbitMQ Command Prompt to find out the new listeners. Verify that port 5671 is listed for TLS.
   - rabbitmq-diagnostics listeners

## RabbitMQ .NET client

1. Install the target .NET SDK or Runtime from [Download .NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0). After installation, run "dotnet --info" to verify.
2. The codes in Receive folder and Send folder are based on the step2-hello-world. Then they are modified based on [Using TLS in the .NET Client](https://www.rabbitmq.com/ssl.html#dotnet-client). The modifications are all the lines including "factory.Ssl".
3. Use 2 Git bashes to run the following commands at Receive folder and at Send folder. After the message is received, do not exit the program yet. Use [RabbitMQ Server management UI](http://localhost:15672/#/connections) to check that the 2 connections are all via TLS.
   - dotnet run

## Reference

- Concept
  - [Queues](https://www.rabbitmq.com/queues.html)
  - [Consumer Acknowledgements and Publisher Confirms](https://www.rabbitmq.com/confirms.html)
  - [Direct Reply-to](https://www.rabbitmq.com/direct-reply-to.html)
  - [TLS Support](https://www.rabbitmq.com/ssl.html)
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
