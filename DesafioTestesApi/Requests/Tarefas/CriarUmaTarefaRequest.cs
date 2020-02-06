using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Helpers;
using System.IO;
using System.Text;


namespace DesafioTestesApi.Requests.Tarefas
{
    public class CriarUmaTarefaRequest : RequestBase
    {
        public CriarUmaTarefaRequest()
        {
            requestService = "/api/rest/issues/";
            method = Method.POST;
           
        }

        public void SetJsonBody(string summary, 
                                string description, 
                                string categoryName, 
                                string projectName,
                                string nomePriority
                                )
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Tarefas/CriarUmaTarefaJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$summary", summary);
            jsonBody = jsonBody.Replace("$description", description);
            jsonBody = jsonBody.Replace("$categoryName", categoryName);
            jsonBody = jsonBody.Replace("$projectName", projectName);
            jsonBody = jsonBody.Replace("$nomePriority", nomePriority);
           
        }
    }
}
