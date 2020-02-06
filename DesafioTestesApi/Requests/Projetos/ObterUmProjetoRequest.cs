using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Projetos
{
    public class ObterUmProjetoRequest : RequestBase
    {

        public ObterUmProjetoRequest(string project_id)
        {
            requestService = "/api/rest/projects/{project_id}";
            method = Method.GET;

            parameters.Add("project_id", project_id);
        }
    }
}
