using RestSharp;
using DesafioTestesApi.Bases;

namespace DesafioTestesApi.Requests.Tarefas

{
    public class DeletarUmaNotaDeUmProblemaRequest : RequestBase
    {

        public DeletarUmaNotaDeUmProblemaRequest(string issue_id, string issue_note_id)
        {
            requestService = "/api/rest/issues/{issue_id}/notes/{issue_note_id}";
            method = Method.DELETE;

            parameters.Add("issue_id", issue_id);
            parameters.Add("issue_note_id", issue_note_id);
        }
    }
}
