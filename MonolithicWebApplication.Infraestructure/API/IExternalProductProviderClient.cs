using MonolithicWebApplication.Infraestructure.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonolithicWebApplication.Infraestructure.API
{
    public interface IExternalProductProviderClient
    {
        Task<List<ExternalProduct>> GetProducts();
    }
}
