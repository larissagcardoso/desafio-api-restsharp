using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Helpers;
using System.IO;
using System.Text;


namespace DesafioTestesApi.Requests.Projetos
{
    public class CriarSubProjetoRequest : RequestBase
    {
        public CriarSubProjetoRequest(string project_id)
        {
            requestService = "/api/rest/projects/{project_id}/subprojects";
            method = Method.POST;

            parameters.Add("project_id", project_id);
        }

        public void SetJsonBody(string nomeProjeto )
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Projetos/CriarSubProjetoJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$nomeProjeto", nomeProjeto);

        }
    }
}
