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
    public class CriarUmProjetoTests : TestBase
    {
        [Test]
      [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            string id = "1";
            string name = "Projeto Testes Automacao " +GeneralHelpers.GeraNumeroAutomatico(3);
            string idStatus = "10";
            string nameStatus = "development";
            string labelStatus = "development";
            string description = "Desafio Teste de API";
            string file_path = "/tmp/";
            string nameView_state = "public";
            string labelView_state = "public";


            //Resultado esperado
            string statusCodeEsperado = "Created";
 

            #endregion

            CriarUmProjetoRequest criarUmProjetoRequest = new CriarUmProjetoRequest();
            criarUmProjetoRequest.SetJsonBody( name, nameStatus,labelStatus,description,file_path,nameView_state,labelView_state);

            IRestResponse<dynamic> response = criarUmProjetoRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(name, response.Data["project"]["name"].ToString());
                Assert.AreEqual(description, response.Data["project"]["description"].ToString());
                StringAssert.IsMatch("(\\d+)", response.Data["project"]["id"].ToString());
       
            });
        }

     
        [Test]
        [Parallelizable]
        public void DadosInvalidos()
        {

            List<string> dadosCriacao = SolicitacaoDBSteps.RetornaNomeAleatorioProjetoDB();

            #region Parameters
 
            string name = dadosCriacao[0];
            string nameStatus = "development";
            string labelStatus = "development";
            string description = "Desafio Teste de API";
            string file_path = "/tmp/";
            string nameView_state = "public";
            string labelView_state = "public";
            #endregion

            CriarUmProjetoRequest criarUmProjetoRequest = new CriarUmProjetoRequest();
            criarUmProjetoRequest.SetJsonBody(name, nameStatus, labelStatus, description, file_path, nameView_state, labelView_state);

            IRestResponse<dynamic> response = criarUmProjetoRequest.ExecuteRequest();

            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "InternalServerError";

            #endregion


            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());

            });

        }
    }



}
