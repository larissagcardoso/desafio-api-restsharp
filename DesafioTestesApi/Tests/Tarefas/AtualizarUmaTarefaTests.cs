using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Helpers;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;
using DesafioTestesApi.Requests.Tarefas;


namespace DesafioTestesApi.Tests.Tarefas
{
    [TestFixture]
    public class AtualizarUmProblemaTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            List<string> issue_id = SolicitacaoDBSteps.RetornaIdProblemaDB();

            string idProblema = issue_id[0];
            string summary = "Desafio Testes API"+GeneralHelpers.GeraStringAutomatica(2);
            string categoryName = "Testes API"+GeneralHelpers.GeraStringAutomatica(5);

            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            AtualizarUmaTarefaRequest atualizarUmaTarefaRequest = new AtualizarUmaTarefaRequest(idProblema);
            atualizarUmaTarefaRequest.SetJsonBody(summary,categoryName);
            IRestResponse<dynamic> response = atualizarUmaTarefaRequest.ExecuteRequest();


            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());

        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosProblema()
        {
            #region Parameters
            List<string> issue_id = SolicitacaoDBSteps.RetornaIdProblemaDB();

            string idProblema = issue_id[0];
            string summary = "";
            string categoryName = "Testes API" + GeneralHelpers.GeraStringAutomatica(5);

            //Resultado esperado
            string statusCodeEsperado = "InternalServerError";
            #endregion

            AtualizarUmaTarefaRequest atualizarUmaTarefaRequest = new AtualizarUmaTarefaRequest(idProblema);
            atualizarUmaTarefaRequest.SetJsonBody(summary, categoryName);
            IRestResponse<dynamic> response = atualizarUmaTarefaRequest.ExecuteRequest();


            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());

        }


        [Test]
        [Parallelizable]
        public void IdInvalidoProblema()
        {
            #region Parameters
            string idProblema = "99999a";
            string summary = "Desafio Testes API" + GeneralHelpers.GeraStringAutomatica(2);
            string categoryName = "Testes API" + GeneralHelpers.GeraStringAutomatica(5);

            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            string message = "Issue #99999 not found";
            string code = "1100";
            string localized = "Issue 99999 not found.";

            #endregion

            AtualizarUmaTarefaRequest atualizarUmaTarefaRequest = new AtualizarUmaTarefaRequest(idProblema);
            atualizarUmaTarefaRequest.SetJsonBody(summary, categoryName);
            IRestResponse<dynamic> response = atualizarUmaTarefaRequest.ExecuteRequest();

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