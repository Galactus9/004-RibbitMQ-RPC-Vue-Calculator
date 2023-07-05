using DbContext;

namespace RPC_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICosmosContext dbContext = new CosmosContext();
            var test = new RpcServer(dbContext);
            Console.ReadKey();
        }
    }
}