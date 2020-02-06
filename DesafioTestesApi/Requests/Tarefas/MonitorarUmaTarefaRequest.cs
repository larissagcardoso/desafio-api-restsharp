using RestSharp;
using DesafioTestesApi.Bases;


namespace DesafioTestesApi.Requests.Tarefas
{
    public class MonitorarUmaTarefaRequest : RequestBase
    {
        public MonitorarUmaTarefaRequest(string issue_id)
        {
            requestService = "/api/rest/issues/{issue_id}/monitors";
            method = Method.POST;

            parameters.Add("issue_id",issue_id);
        }


    }

    }
