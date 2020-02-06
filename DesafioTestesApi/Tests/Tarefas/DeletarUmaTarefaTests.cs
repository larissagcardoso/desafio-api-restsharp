using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Tarefas;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;


namespace DesafioTestesApi.Tests.Tarefas
{
    [TestFixture]
    public class DeletarUmaTarefaTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            List<string> idProblema = SolicitacaoDBSteps.RetornaIdProblemaDB();
            string issue_id = idProblema[0];

            //Resultado esperado
            string statusCodeEsperado = "NoContent";
            #endregion

            DeletarUmaTarefaRequest deletarUmaTarefaRequest = new DeletarUmaTarefaRequest(issue_id);

            IRestResponse<dynamic> response = deletarUmaTarefaRequest.ExecuteRequest();

            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            }

        }

        [Test]
        [Parallelizable]
        public void DadosInvalidos()
        {
            #region Parameters
            string issue_id = "A90000";

            //Resultado esperado
            string message = "Issue #0 not found";
            string code = "1100";
            string localized = "Issue 0 not found.";
            string statusCodeEsperado = "NotFound";
            #endregion

            DeletarUmaTarefaRequest deletarUmaTarefaRequest = new DeletarUmaTarefaRequest(issue_id);

            IRestResponse<dynamic> response = deletarUmaTarefaRequest.ExecuteRequest();

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
