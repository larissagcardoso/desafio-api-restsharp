using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Tarefas;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;


namespace DesafioTestesApi.Tests.Tarefas
{
    [TestFixture]
    public class DeletarUmaNotaDeUmTarefaTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            List<string> idProblemaIdNote = SolicitacaoDBSteps.RetornaIdProjetoIdNoteDB();
            string issue_id = idProblemaIdNote[0];
            string issue_note_id = idProblemaIdNote[1];
            //Resultado esperado

            string statusCodeEsperado = "OK";
            #endregion

            DeletarUmaNotaDeUmProblemaRequest deletarUmaNotaDeUmProblemaRequest = new DeletarUmaNotaDeUmProblemaRequest(issue_note_id, issue_id);

            IRestResponse<dynamic> response = deletarUmaNotaDeUmProblemaRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
             
            });
             }

        [Test]
        [Parallelizable]
        public void DadosInvalidosIdAnotacao()
        {
            #region Parameters
            List<string> idProblema = SolicitacaoDBSteps.RetornaIdProblemaDB();

            string issue_id = idProblema[0];
            string issue_note_id = "444444444444a";

            //Resultado esperado
            string message = "Issue note #444444444444a not found";
            string code = "600";
            string localized = "Note not found.";
            string statusCodeEsperado = "NotFound";
            #endregion

            DeletarUmaNotaDeUmProblemaRequest deletarUmaNotaDeUmProblemaRequest = new DeletarUmaNotaDeUmProblemaRequest(issue_id, issue_note_id);

            IRestResponse<dynamic> response = deletarUmaNotaDeUmProblemaRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(message, response.Data["message"].ToString());
                Assert.AreEqual(code, response.Data["code"].ToString());
                Assert.AreEqual(localized, response.Data["localized"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosIdAnotacaoZero()
        {
            #region Parameters
            List<string> idProblema = SolicitacaoDBSteps.RetornaIdProblemaDB();

            string issue_id = idProblema[0];
            string issue_note_id = "0";

            //Resultado esperado
            string message = "'id' must be >= 1";
            string code = "29";
            string localized = "Invalid value for 'id'";
            string statusCodeEsperado = "BadRequest";
            #endregion

            DeletarUmaNotaDeUmProblemaRequest deletarUmaNotaDeUmProblemaRequest = new DeletarUmaNotaDeUmProblemaRequest(issue_id, issue_note_id);

            IRestResponse<dynamic> response = deletarUmaNotaDeUmProblemaRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(message, response.Data["message"].ToString());
                Assert.AreEqual(code, response.Data["code"].ToString());
                Assert.AreEqual(localized, response.Data["localized"].ToString());
            });
        }

    }
}
