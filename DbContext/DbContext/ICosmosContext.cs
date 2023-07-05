

using Microsoft.Azure.Cosmos;

namespace DbContext
{
    public interface ICosmosContext
    {
        Container userContainer { get; }
        Container logContainer { get; }
    }
}