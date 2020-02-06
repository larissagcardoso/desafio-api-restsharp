using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Tarefas
{
    public class ObterTarefasReportadaPorMimRequest : RequestBase
    {

        public ObterTarefasReportadaPorMimRequest(string filter_id)
        {
            requestService = "/api/rest/issues";
            method = Method.GET;

            parameters.Add("filter_id", filter_id);
        }
    }
}
