using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Projetos
{
    public class ObterTodosProjetosRequest : RequestBase
    {

        public ObterTodosProjetosRequest()
        {
            requestService = "/api/rest/projects/";
            method = Method.GET;

        
        }
    }
}
