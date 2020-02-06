using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Projetos;


namespace DesafioTestesApi.Tests.Linguagem
{
    [TestFixture]
    public class ObterUmaStringLocalizadaTests : TestBase
    {
       
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            string string_desc = "all_projects";

            //Resultado esperado
            string statusCodeEsperado = "OK";
            string name = "all_projects";
            string localized = "All Projects";
            string language = "english";
            #endregion

            ObterUmaStringLocalizadaRequest obterUmaStringLocalizadaRequest = new ObterUmaStringLocalizadaRequest(string_desc);
            IRestResponse<dynamic> response = obterUmaStringLocalizadaRequest.ExecuteRequest();


            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(name, response.Data["strings"][0]["name"].ToString());
                Assert.AreEqual(localized, response.Data["strings"][0]["localized"].ToString());
                Assert.AreEqual(language, response.Data["language"].ToString());
            });

        }

    }
}
