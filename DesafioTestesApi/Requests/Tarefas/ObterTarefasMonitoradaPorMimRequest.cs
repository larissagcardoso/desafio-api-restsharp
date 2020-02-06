using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Tarefas
{
    public class ObterTarefasMonitoradaPorMimRequest : RequestBase
    {

        public ObterTarefasMonitoradaPorMimRequest(string filter_id)
        {
            requestService = "/api/rest/issues";
            method = Method.GET;

            parameters.Add("filter_id", filter_id);
        }
    }
}
