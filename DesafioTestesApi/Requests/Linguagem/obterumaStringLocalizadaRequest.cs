using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Projetos
{
    public class ObterUmaStringLocalizadaRequest : RequestBase
    {

        public ObterUmaStringLocalizadaRequest(string string_desc)
        {
            requestService = "/api/rest/lang";
            method = Method.GET;

            parameters.Add("string", string_desc);
        }
    }
}
