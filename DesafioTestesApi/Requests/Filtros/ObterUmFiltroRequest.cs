using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Filtros
{
    public class ObterUmFiltroRequest : RequestBase
    {

        public ObterUmFiltroRequest(string filter_id)
        {
            requestService = "/api/rest/filters";
            method = Method.GET;

            parameters.Add("filter_id", filter_id);
        }
    }
}
