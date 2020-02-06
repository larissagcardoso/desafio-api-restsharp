using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Helpers;
using System.IO;
using System.Text;


namespace DesafioTestesApi.Requests.Tarefas
{
    public class CriarNotaDeUmaTarefaRequest : RequestBase
    {
        public CriarNotaDeUmaTarefaRequest(string issue_id )
        {
            requestService = "/api/rest/issues/{issue_id}/notes";
            method = Method.POST;

            parameters.Add("issue_id", issue_id);
        }

        public void SetJsonBody(string text, 
                                string nameView_state                          
                                )
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Tarefas/CriarNotaDeUmaTarefaJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$text", text);
            jsonBody = jsonBody.Replace("$nameView_state", nameView_state);
                    
        }
    }
}
