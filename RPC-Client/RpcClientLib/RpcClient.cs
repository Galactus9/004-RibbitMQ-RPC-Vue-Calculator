using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RpcClientLib
{
    public class RpcClient : IDisposable, IRpcClient
    {
        private IConnection _connection;
        private IModel _channel;
        private string _responseQueueName;
        private string QueueName = "RpcQueue";
        private bool _isDisposed;
        private ConcurrentDictionary<string, TaskCompletionSource<string>> _activeTaskQueue = new ConcurrentDictionary<string, TaskCompletionSource<string>>();

        public RpcClient()
        {
            // Create a connection to the RabbitMQ server.
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare a response queue unique to this client instance.
            _responseQueueName = _channel.QueueDeclare().QueueName;

            // Create a consumer to receive responses from the response queue.
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;
            _channel.BasicConsume(queue: _responseQueueName, consumer: consumer, autoAck: true);
        }

        // Event handler for processing received response messages.
        private void Consumer_Received(object? sender, BasicDeliverEventArgs args)
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);


            // Retrieve the task completion source associated with the received response.
            if (_activeTaskQueue.TryRemove(args.BasicProperties.CorrelationId, out var taskCompletionSource))
            {
                // Set the result of the task completion source with the received message.
                taskCompletionSource.SetResult(message);
            }
        }

        // Send an asynchronous request to the server and return a task for receiving the response.
        public Task<string> SendAsync(object model)
        {
            // Create basic properties for the message.
            var basicProperties = _channel.CreateBasicProperties();
            basicProperties.ReplyTo = _responseQueueName;

            // Generate a unique correlation ID for the request.
            var messageId = Guid.NewGuid().ToString();
            basicProperties.CorrelationId = messageId;

            // Create a task completion source for receiving the response.
            var taskCompletionSource = new TaskCompletionSource<string>();

            // Serialize the model into a JSON message.
            var message = JsonSerializer.Serialize(model);
            var messageToSend = Encoding.UTF8.GetBytes(message);

            // Publish the message to the server with the specified routing key.
            _channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: basicProperties, body: messageToSend);

            // Add the task completion source to the active task queue.
            _activeTaskQueue.TryAdd(messageId, taskCompletionSource);

            // Return the task associated with the task completion source.
            return taskCompletionSource.Task;
        }

        // Clean up resources.
        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing)
            {
                _channel.Close();
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RpcClient()
        {
            Dispose(false);
        }
    }
}
