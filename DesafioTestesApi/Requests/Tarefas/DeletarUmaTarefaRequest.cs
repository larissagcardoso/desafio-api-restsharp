using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Tarefas

{
    public class DeletarUmaTarefaRequest : RequestBase
    {

        public DeletarUmaTarefaRequest(string issue_id)
        {
            requestService = "/api/rest/issues/{issue_id}";
            method = Method.DELETE;

            parameters.Add("issue_id", issue_id);
        }
    }
}
