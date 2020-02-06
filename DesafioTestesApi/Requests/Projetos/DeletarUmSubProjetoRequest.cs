using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Projetos
{
    public class DeletarUmSubProjetoRequest : RequestBase
    {

        public DeletarUmSubProjetoRequest(string project_id)
        {
            requestService = "/api/rest/projects/{project_id}";
            method = Method.DELETE;

            parameters.Add("project_id", project_id);
        }
    }
}
