using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Helpers;
using System.IO;
using System.Text;


namespace DesafioTestesApi.Requests.Tarefas
{
    public class AtualizarUmaTarefaRequest : RequestBase
    {
        public AtualizarUmaTarefaRequest(string issue_id)
        {
            requestService = "/api/rest/issues/{issue_id}";
            method = Method.PATCH;
            parameters.Add("issue_id", issue_id);
        }

        public void SetJsonBody(string summary, 
                                string priorityName 
                                )
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Tarefas/AtualizarUmaTarefaJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$summary", summary);
            jsonBody = jsonBody.Replace("$priorityName", priorityName);
           
        }
    }
}
