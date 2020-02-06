using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Usuarios
{
    public class ObterInfoMeuUsuarioRequest : RequestBase
    {

        public ObterInfoMeuUsuarioRequest()
        {
            requestService = "/api/rest/users/me";
            method = Method.GET;

        
        }
    }
}
