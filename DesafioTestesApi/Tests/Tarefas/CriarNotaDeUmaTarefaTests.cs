using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.DBSteps;
using DesafioTestesApi.Helpers;
using System.Collections.Generic;
using DesafioTestesApi.Requests.Tarefas;
using System.Collections;

namespace DesafioTestesApi.Tests.Tarefas
{
    [TestFixture]
    public class CriarNotaDeUmaTarefaTests : TestBase
    {


        #region Data Driven Providers
        public static IEnumerable AdicionarAnotacaoNaTarefa()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/AdicionarAnotacaoNaTarefaData.csv");
        }
        #endregion


        [Test, TestCaseSource("AdicionarAnotacaoNaTarefa")]
        [Parallelizable]
        public void DadosValidos(ArrayList testData)
        {
            #region Parameters
            List<string> issue_id = SolicitacaoDBSteps.RetornaIdProblemaDB();

            string idProblema = issue_id[0];
            string text = testData[0].ToString();
            string nameView_state = "public";
     
            //Resultado esperado
            string statusCodeEsperado = "Created";

            #endregion

            CriarNotaDeUmaTarefaRequest criarNotaDeUmaTarefaRequest = new CriarNotaDeUmaTarefaRequest(idProblema);
            criarNotaDeUmaTarefaRequest.SetJsonBody(text, nameView_state);

            IRestResponse<dynamic> response = criarNotaDeUmaTarefaRequest.ExecuteRequest();

     
            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());

        }

 
        [Test]
        [Parallelizable]
        public void DadosInvalidosTextoNota()
        {
            #region Parameters
            List<string> issue_id = SolicitacaoDBSteps.RetornaIdProblemaDB();

            string idProblema = issue_id[0];
            string text = "";
            string nameView_state = "public";
            #endregion


            CriarNotaDeUmaTarefaRequest criarNotaDeUmaTarefaRequest = new CriarNotaDeUmaTarefaRequest(idProblema);
            criarNotaDeUmaTarefaRequest.SetJsonBody(text,nameView_state);

            IRestResponse<dynamic> response = criarNotaDeUmaTarefaRequest.ExecuteRequest();

            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "Issue note not specified.";
            string code = "11";
            string localized = "A necessary field \"Note\" was empty. Please recheck your inputs.";
            #endregion


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
        public void DadosInvalidosIdProblemaZero()
        {
            #region Parameters
           
            string idProblema = "0";
            string text = "teste";
            string nameView_state = "public";
            #endregion


            CriarNotaDeUmaTarefaRequest criarNotaDeUmaTarefaRequest = new CriarNotaDeUmaTarefaRequest(idProblema);
            criarNotaDeUmaTarefaRequest.SetJsonBody(text, nameView_state);

            IRestResponse<dynamic> response = criarNotaDeUmaTarefaRequest.ExecuteRequest();

            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "'issue_id' must be >= 1";
            string code = "29";
            string localized = "Invalid value for 'issue_id'";
            #endregion


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
        public void DadosInvalidosLetraIdProblema()
        {
            #region Parameters
      
            string idProblema = "ABC";
            string text = "teste";
            string nameView_state = "public";
            #endregion


            CriarNotaDeUmaTarefaRequest criarNotaDeUmaTarefaRequest = new CriarNotaDeUmaTarefaRequest(idProblema);
            criarNotaDeUmaTarefaRequest.SetJsonBody(text, nameView_state);

            IRestResponse<dynamic> response = criarNotaDeUmaTarefaRequest.ExecuteRequest();

            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "'issue_id' must be numeric";
            string code = "29";
            string localized = "Invalid value for 'issue_id'";
            #endregion


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
        public void DadosInvalidosViewState()
        {
            #region Parameters
            List<string> issue_id = SolicitacaoDBSteps.RetornaIdProblemaDB();

            string idProblema = issue_id[0];
            string text = "teste";
            string nameView_state = string.Empty;
            #endregion


            CriarNotaDeUmaTarefaRequest criarNotaDeUmaTarefaRequest = new CriarNotaDeUmaTarefaRequest(idProblema);
            criarNotaDeUmaTarefaRequest.SetJsonBody(text, nameView_state);

            IRestResponse<dynamic> response = criarNotaDeUmaTarefaRequest.ExecuteRequest();

            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            #endregion

            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
        
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosIdProblema()
        {
            #region Parameters

            string idProblema = "9999999";
            string text = "teste";
            string nameView_state = "public";
            #endregion


            CriarNotaDeUmaTarefaRequest criarNotaDeUmaTarefaRequest = new CriarNotaDeUmaTarefaRequest(idProblema);
            criarNotaDeUmaTarefaRequest.SetJsonBody(text, nameView_state);

            IRestResponse<dynamic> response = criarNotaDeUmaTarefaRequest.ExecuteRequest();

            #region ParametersResponse
            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            string message = "Issue #9999999 not found";
            string code = "1100";
            string localized = "Issue 9999999 not found.";
            #endregion


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
