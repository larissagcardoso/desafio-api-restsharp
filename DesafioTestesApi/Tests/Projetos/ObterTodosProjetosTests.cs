using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Projetos;
using Newtonsoft.Json.Linq;
using DesafioTestesApi.Helpers;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;

namespace DesafioTestesApi.Tests.Projetos
{
    [TestFixture]
    public class ObterTodosOsProjetosTests : TestBase
    {

        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters

            //Resultado esperado
            List<string> dadosProjetos = SolicitacaoDBSteps.RetornaProjetosDB();

            string statusCodeEsperado = "OK";
   
            #endregion

            ObterTodosProjetosRequest obterTodosProjetosRequest = new ObterTodosProjetosRequest();
            IRestResponse<dynamic> response = obterTodosProjetosRequest.ExecuteRequest();
            JObject resultadoEsperado = JObject.Parse(response.Data.ToString());


            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
             foreach (JToken IdProjeto in resultadoEsperado.SelectTokens("*.id"))
            {
                string id = IdProjeto.ToString();
                Assert.IsTrue(GeneralHelpers.VerificaSeStringEstaContidaNaLista(dadosProjetos, id));
            }

        }
    }
 }
