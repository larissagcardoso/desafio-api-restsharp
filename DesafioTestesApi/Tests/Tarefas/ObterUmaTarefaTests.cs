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
    public class ObterUmaTarefaTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            List<string> dadosProblema = SolicitacaoDBSteps.RetornaInfoProblemaDB();
            string issue_id = dadosProblema[0];

            //Resultado esperado

            string statusCodeEsperado = "OK";

            string idIssues = dadosProblema[0];
            string summary = dadosProblema[1];
            string description = dadosProblema[2];
            string idProject = dadosProblema[3];
            string nameProject = dadosProblema[4];
            string idCategory = dadosProblema[5];
            string nameCategory = dadosProblema[6]; ;
            string idReporter = dadosProblema[7];
            string nameReporter = dadosProblema[8];
            string real_nameReporter = dadosProblema[9];
            string reporterEmail = dadosProblema[10];
            string idStatus = dadosProblema[11];
            string idResolution = dadosProblema[12];
            string view_state = dadosProblema[13];
            string idPriority = dadosProblema[14];
            string idSeverity = dadosProblema[15];
            string idReproducibility = dadosProblema[16];
            string sticky = GeneralHelpers.TrataRetornoBool(dadosProblema[17]);
            string issuesCreated_at = dadosProblema[18];
            string issuesUpdated_at = dadosProblema[19];
            string historyCreated_at = dadosProblema[20];
            string idUser = dadosProblema[21];
            string userName = dadosProblema[22];
            string userRealName = dadosProblema[23];
            string userEmail = dadosProblema[24];
            string idType = dadosProblema[25];
            string message = "New Issue";

            #endregion

            ObterUmaTarefaRequest obterUmaTarefaRequest = new ObterUmaTarefaRequest(issue_id);
            IRestResponse<dynamic> response = obterUmaTarefaRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idIssues, response.Data["issues"][0]["id"].ToString());
                Assert.AreEqual(summary, response.Data["issues"][0]["summary"].ToString());
                Assert.AreEqual(description, response.Data["issues"][0]["description"].ToString());
                Assert.AreEqual(idProject, response.Data["issues"][0]["project"]["id"].ToString());
                Assert.AreEqual(nameProject, response.Data["issues"][0]["project"]["name"].ToString());
                Assert.AreEqual(idCategory, response.Data["issues"][0]["category"]["id"].ToString());
                Assert.AreEqual(nameCategory, response.Data["issues"][0]["category"]["name"].ToString());
                Assert.AreEqual(idReporter, response.Data["issues"][0]["reporter"]["id"].ToString());
                Assert.AreEqual(nameReporter, response.Data["issues"][0]["reporter"]["name"].ToString());
                Assert.AreEqual(real_nameReporter, response.Data["issues"][0]["reporter"]["real_name"].ToString());
                Assert.AreEqual(reporterEmail, response.Data["issues"][0]["reporter"]["email"].ToString());
                Assert.AreEqual(idStatus, response.Data["issues"][0]["view_state"]["id"].ToString());
                Assert.AreEqual(idResolution, response.Data["issues"][0]["resolution"]["id"].ToString());
                Assert.AreEqual(view_state, response.Data["issues"][0]["view_state"]["id"].ToString());
                Assert.AreEqual(idPriority, response.Data["issues"][0]["priority"]["id"].ToString());
                Assert.AreEqual(idSeverity, response.Data["issues"][0]["severity"]["id"].ToString());
                Assert.AreEqual(idReproducibility, response.Data["issues"][0]["reproducibility"]["id"].ToString());
                Assert.AreEqual(sticky, response.Data["issues"][0]["sticky"].ToString());
                Assert.AreEqual(issuesUpdated_at, response.Data["issues"][0]["updated_at"].ToString());
                Assert.AreEqual(idUser, response.Data["issues"][0]["history"][0]["user"]["id"].ToString());
                Assert.AreEqual(userName, response.Data["issues"][0]["history"][0]["user"]["name"].ToString());
                Assert.AreEqual(userEmail, response.Data["issues"][0]["history"][0]["user"]["email"].ToString());
                Assert.AreEqual(userRealName, response.Data["issues"][0]["history"][0]["user"]["real_name"].ToString());
                Assert.AreEqual(message, response.Data["issues"][0]["history"][0]["message"].ToString());


            });
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosIdProblema()
        {
            #region Parameters
            string issue_id = "0";

            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            string message = "Issue #0 not found";
            string code = "1100";
            string localized = "Issue 0 not found.";

            #endregion

            ObterUmaTarefaRequest obterUmaTarefaRequest = new ObterUmaTarefaRequest(issue_id);
            IRestResponse<dynamic> response = obterUmaTarefaRequest.ExecuteRequest();

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
