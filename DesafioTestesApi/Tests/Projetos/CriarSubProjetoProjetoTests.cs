using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Projetos;
using DesafioTestesApi.DBSteps;
using System.Collections.Generic;

namespace DesafioTestesApi.Tests.Projetos
{
    [TestFixture]
    public class CriarSubProjetoTests : TestBase
    {

        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Execucao Query Deletar SubProjetos
            SolicitacaoDBSteps.DeletaSubprojetosDB();
            #endregion

            #region Parameters
            List<string> idProjeto = SolicitacaoDBSteps.RetornaIdNomeAleatorioProjetoDB();
            string project_id = idProjeto[0];

            List<string> nameProjeto = SolicitacaoDBSteps.RetornaNomeAleatorioProjetoDB();

             string nomeProjeto = nameProjeto[0];

            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
 

            #endregion

            CriarSubProjetoRequest criarSubProjetoRequest = new CriarSubProjetoRequest(project_id);
            criarSubProjetoRequest.SetJsonBody(nomeProjeto);

            IRestResponse<dynamic> response = criarSubProjetoRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
    
            });
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosNomeProjeto()
        {

            List<string> dadosCriacao = SolicitacaoDBSteps.RetornaNomeAleatorioProjetoDB();

            #region Parameters

            List<string> idProjesto = SolicitacaoDBSteps.RetornaIdNomeAleatorioProjetoDB();
            string project_id = idProjesto[0];

            string nomeProjeto = "NomeInexistente Teste";
         
            #endregion


            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            string message = "Project 'NomeInexistente Teste' not found";
            string code = "700";
            string localized = "Project \"NomeInexistente Teste\" not found.";
            #endregion


            CriarSubProjetoRequest criarSubProjetoRequest = new CriarSubProjetoRequest(project_id);
            criarSubProjetoRequest.SetJsonBody(nomeProjeto);

            IRestResponse<dynamic> response = criarSubProjetoRequest.ExecuteRequest();

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
