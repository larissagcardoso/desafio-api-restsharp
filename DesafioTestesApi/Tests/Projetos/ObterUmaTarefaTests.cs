using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Helpers;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;
using DesafioTestesApi.Requests.Projetos;


namespace DesafioTestesApi.Tests.Projetos
{
    [TestFixture]
    public class ObterUmProjetoTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            List<string> dadosProjeto = SolicitacaoDBSteps.RetornaIdNomeAleatorioProjetoDB();
            string project_id = dadosProjeto[0];
            string nameProject = dadosProjeto[1];

            //Resultado esperado
            string statusCodeEsperado = "OK";

            #endregion

            ObterUmProjetoRequest obterUmProblemaRequest = new ObterUmProjetoRequest(project_id);
            IRestResponse<dynamic> response = obterUmProblemaRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {

                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(project_id, response.Data["projects"][0]["id"].ToString());
                Assert.AreEqual(nameProject, response.Data["projects"][0]["name"].ToString());

            });

        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosIdProjeto()
        {
            #region Parameters
            string project_id = "999999a";

            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            string message = "Project #999999 not found";
            string code = "700";
            string localized = "Project \"999999\" not found.";

            #endregion

            ObterUmProjetoRequest obterUmProjetoRequest = new ObterUmProjetoRequest(project_id);
            IRestResponse<dynamic> response = obterUmProjetoRequest.ExecuteRequest();

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
