using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Tarefas;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;

namespace DesafioTestesApi.Tests.Tarefas
{
    [TestFixture]
    public class MonitorarUmaTarefaTests : TestBase
    {

        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters   
            List<string> idProblema = SolicitacaoDBSteps.RetornaIdProblemaDB();
            string issue_id = idProblema[0];

            //Resultado esperado
            string statusCodeEsperado = "Created";

            #endregion

            MonitorarUmaTarefaRequest monitorarUmaTarefaRequest = new MonitorarUmaTarefaRequest(issue_id);
            IRestResponse<dynamic> response = monitorarUmaTarefaRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());

            });
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosProblema()
        {
            #region Parameters   
           string issue_id = "0";

            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "'issue_id' must be >= 1";
            string code = "29";
            string localized = "Invalid value for 'issue_id'";

            #endregion

            MonitorarUmaTarefaRequest monitorarUmaTarefaRequest = new MonitorarUmaTarefaRequest(issue_id);
            IRestResponse<dynamic> response = monitorarUmaTarefaRequest.ExecuteRequest();

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
        public void DadosInvalidosIdProblema()
        {
            #region Parameters
            string issue_id = "99999";

            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            string message = "Issue #99999 not found";
            string code = "1100";
            string localized = "Issue 99999 not found.";

            #endregion

            MonitorarUmaTarefaRequest monitorarUmaTarefaRequest = new MonitorarUmaTarefaRequest(issue_id);
            IRestResponse<dynamic> response = monitorarUmaTarefaRequest.ExecuteRequest();

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
        public void DadosInvalidosIdProblemaLetra()
        {
            #region Parameters
            string issue_id = "aaa";

            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "'issue_id' must be numeric";
            string code = "29";
            string localized = "Invalid value for 'issue_id'";

            #endregion

            MonitorarUmaTarefaRequest monitorarUmaTarefaRequest = new MonitorarUmaTarefaRequest(issue_id);
            IRestResponse<dynamic> response = monitorarUmaTarefaRequest.ExecuteRequest();

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
