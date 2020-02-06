using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Helpers;
using System.IO;
using System.Text;


namespace DesafioTestesApi.Requests.Projetos
{
    public class CriarUmProjetoRequest : RequestBase
    {
        public CriarUmProjetoRequest()
        {
            requestService = "/api/rest/projects/";
            method = Method.POST;
           
        }

        public void SetJsonBody(//string id, 
                                string name, 
                              //  string idStatus, 
                                string nameStatus,
                                string labelStatus,
                                string description,
                             //   string enabled,
                                string file_path, 
                           //     string Idview_state,
                                string nameView_state,
                                string labelView_state
                                )
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Projetos/CriarUmProjetoJson.json", Encoding.UTF8);
         //   jsonBody = jsonBody.Replace("$id", id);
            jsonBody = jsonBody.Replace("$name", name);
         //   jsonBody = jsonBody.Replace("$idStatus", idStatus);
            jsonBody = jsonBody.Replace("$nameStatus", nameStatus);
            jsonBody = jsonBody.Replace("$labelStatus", labelStatus);
            jsonBody = jsonBody.Replace("$description", description);
           // jsonBody = jsonBody.Replace("$enabled", enabled);
            jsonBody = jsonBody.Replace("$file_path", file_path);
           // jsonBody = jsonBody.Replace("$Idview_state", Idview_state);
            jsonBody = jsonBody.Replace("$nameView_state", nameView_state);
            jsonBody = jsonBody.Replace("$labelView_state", labelView_state);

        }
    }
}
