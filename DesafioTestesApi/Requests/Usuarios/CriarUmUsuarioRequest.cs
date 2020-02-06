using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Helpers;
using System.IO;
using System.Text;


namespace DesafioTestesApi.Requests.Usuarios
{
    public class CriarUmUsuarioRequest : RequestBase
    {
        public CriarUmUsuarioRequest()
        {
            requestService = "/api/rest/users/";
            method = Method.POST;
           
        }

        public void SetJsonBody(string username, 
                                string password, 
                                string real_name, 
                                string email,
                                string nameLevel,
                                string enabled,
                                string protectedLevel)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Usuarios/CriarUmUsuarioJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$username", username);
            jsonBody = jsonBody.Replace("$password", password);
            jsonBody = jsonBody.Replace("$real_name", real_name);
            jsonBody = jsonBody.Replace("$email", email);
            jsonBody = jsonBody.Replace("$nameLevel", nameLevel);
            jsonBody = jsonBody.Replace("$enabled", enabled);
            jsonBody = jsonBody.Replace("$projectName", protectedLevel);

        }
    }
}
