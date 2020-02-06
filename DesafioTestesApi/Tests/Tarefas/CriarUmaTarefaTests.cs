using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Tarefas;
using DesafioTestesApi.DBSteps;
using DesafioTestesApi.Helpers;
using System.Collections.Generic;

namespace DesafioTestesApi.Tests.Tarefas
{
    [TestFixture]
    public class CriarUmaTarefaTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosInvalidos()
        {
            #region Parameters
            string summary = "This is a test issue";
            string description = "Testando";
            string categoryName = "Testess";
            string projectName = "Projeto Mantis_algo";
            string nomePriority = "normal";


            //Resultado esperado
            string status = "BadRequest";
            string message = "Project not specified";
            string code = "11";
            string localized = "A necessary field \"project\" was empty. Please recheck your inputs.";

            #endregion

            CriarUmaTarefaRequest criarUmaTarefaRequest = new CriarUmaTarefaRequest();
            criarUmaTarefaRequest.SetJsonBody(summary, description, categoryName, projectName, nomePriority);

            IRestResponse<dynamic> response = criarUmaTarefaRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(status, response.StatusCode.ToString());
                Assert.AreEqual(message, response.Data["message"].ToString());
                Assert.AreEqual(code, response.Data["code"].ToString());
                Assert.AreEqual(localized, response.Data["localized"].ToString());
            });
        }

      
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {

            List<string> nomeProjeto = SolicitacaoDBSteps.RetornaNomeAleatorioProjetoDB();
           

            #region Parameters
            string summary = "TestesAutomatizadosApi";
            string description = "Descricao do Projeto.";
            string categoryName = "Bug";
            string projectName = nomeProjeto[0];
            string nomePriority = "normal";
            #endregion

            CriarUmaTarefaRequest criarUmaTarefaRequest = new CriarUmaTarefaRequest();
            criarUmaTarefaRequest.SetJsonBody(summary, description, categoryName, projectName, nomePriority);

            IRestResponse<dynamic> response = criarUmaTarefaRequest.ExecuteRequest();
          

            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion         

             List<string> dadosProblema = SolicitacaoDBSteps.RetornaInfoTarefaCriadaDB();
                       
            string idIssues = dadosProblema[0];
            string summaryA = dadosProblema[1];
            string descriptionA = dadosProblema[2];
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
        

            Assert.Multiple(() => {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idIssues, response.Data["issue"]["id"].ToString());
                Assert.AreEqual(summaryA, response.Data["issue"]["summary"].ToString());
                Assert.AreEqual(descriptionA, response.Data["issue"]["description"].ToString());
                Assert.AreEqual(idProject, response.Data["issue"]["project"]["id"].ToString());
                Assert.AreEqual(nameProject, response.Data["issue"]["project"]["name"].ToString());
                Assert.AreEqual(idCategory, response.Data["issue"]["category"]["id"].ToString());
                Assert.AreEqual(nameCategory, response.Data["issue"]["category"]["name"].ToString());
                Assert.AreEqual(idReporter, response.Data["issue"]["reporter"]["id"].ToString());
                Assert.AreEqual(nameReporter, response.Data["issue"]["reporter"]["name"].ToString());
                Assert.AreEqual(real_nameReporter, response.Data["issue"]["reporter"]["real_name"].ToString());
                Assert.AreEqual(reporterEmail, response.Data["issue"]["reporter"]["email"].ToString());
                Assert.AreEqual(idStatus, response.Data["issue"]["view_state"]["id"].ToString());
                Assert.AreEqual(idResolution, response.Data["issue"]["resolution"]["id"].ToString());

            });

        }
    }



}
