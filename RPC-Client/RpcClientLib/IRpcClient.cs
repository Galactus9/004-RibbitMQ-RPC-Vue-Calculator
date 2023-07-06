using RabbitMQ.Client.Events;

namespace RpcClientLib
{
    public interface IRpcClient
    {
        public Task<string> SendAsync(object model);

    }
}