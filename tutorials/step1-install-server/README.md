# Tutorial for installing RabbitMQ server in Windows

1. Check the following to install.
   - [Downloading and Installing RabbitMQ](https://www.rabbitmq.com/download.html)
   - [Installing on Windows](https://www.rabbitmq.com/install-windows.html)
   - [Youtube video](https://www.youtube.com/watch?v=V9DWKbalbWQ)
2. Open "RabbitMQ Command Prompt (sbin dir)" to do the following.
   - rabbitmqctl.bat help
   - rabbitmqctl.bat status
   - rabbitmq-diagnostics.bat help
   - rabbitmq-plugins.bat help
   - rabbitmq-plugins enable rabbitmq_management
3. Open a web browser and navigate to [Management UI](http://localhost:15672/). The default username/password is guest/guest.

## Reference

- [Management Plugin](https://www.rabbitmq.com/management.html)
