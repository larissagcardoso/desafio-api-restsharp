using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Tarefas
{
    public class ObterTodasTarefasRequest : RequestBase
    {

        public ObterTodasTarefasRequest(string page_size, string page)
        {
            requestService = "api/rest/issues";
            method = Method.GET;

         
            parameters.Add("page_size", page_size);
            parameters.Add("page", page);

        }
    }
}
