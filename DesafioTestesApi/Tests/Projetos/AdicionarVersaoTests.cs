using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Projetos;
using DesafioTestesApi.DBSteps;
using DesafioTestesApi.Helpers;
using System.Collections.Generic;

namespace DesafioTestesApi.Tests.Projetos
{
    [TestFixture]
    public class AdicionarVersaoTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters

            List<string> idProjesto = SolicitacaoDBSteps.RetornaIdNomeAleatorioProjetoDB();
            string project_id = idProjesto[0];

            string nomeProjeto = "V."+GeneralHelpers.GeraNumeroAutomatico(2);
                    
            //Resultado esperado
            string statusCodeEsperado = "NoContent";
            #endregion

            AdicionarVersaoRequest adicionarVersaoRequest = new AdicionarVersaoRequest(project_id);
            adicionarVersaoRequest.SetJsonBody(nomeProjeto);

            IRestResponse<dynamic> response = adicionarVersaoRequest.ExecuteRequest();

             Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            
        
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosNomeProjetoVazio()
        {

           #region Parameters
            List<string> idProjesto = SolicitacaoDBSteps.RetornaIdNomeAleatorioProjetoDB();
            string project_id = idProjesto[0];
            string nomeProjeto = string.Empty;
         
            #endregion


            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "Invalid version name";
            string code = "11";
            string localized = "A necessary field \"name\" was empty. Please recheck your inputs.";
            #endregion


            AdicionarVersaoRequest adicionarVersaoRequest = new AdicionarVersaoRequest(project_id);
            adicionarVersaoRequest.SetJsonBody(nomeProjeto);

            IRestResponse<dynamic> response = adicionarVersaoRequest.ExecuteRequest();

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
        public void DadosInvalidosIdProjetoLetra()
        {

            #region Parameters
            string project_id = "aaaaa";
            string nomeProjeto = "V." + GeneralHelpers.GeraNumeroAutomatico(2);

            #endregion


            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "'project_id' must be numeric";
            string code = "29";
            string localized = "Invalid value for 'project_id'";
            #endregion


            AdicionarVersaoRequest adicionarVersaoRequest = new AdicionarVersaoRequest(project_id);
            adicionarVersaoRequest.SetJsonBody(nomeProjeto);

            IRestResponse<dynamic> response = adicionarVersaoRequest.ExecuteRequest();

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
