using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Tarefas
{
    public class ObterUmaTarefaRequest : RequestBase
    {

        public ObterUmaTarefaRequest(string issue_id)
        {
            requestService = "/api/rest/issues/{issue_id}";
            method = Method.GET;

            parameters.Add("issue_id", issue_id);
        }
    }
}
