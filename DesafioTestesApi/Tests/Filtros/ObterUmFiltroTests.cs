using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Filtros;


namespace DesafioTestesApi.Tests.Filtros
{
    [TestFixture]
    public class ObterUmFiltroTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            string filter_id = "3";

            //Resultado esperado
            string statusCodeEsperado = "OK";
            string nameFiltro = "Teste";
            #endregion

            ObterUmFiltroRequest obterUmFiltroRequest = new ObterUmFiltroRequest(filter_id);
            IRestResponse<dynamic> response = obterUmFiltroRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(filter_id, response.Data["filters"][0]["id"].ToString());
                Assert.AreEqual(nameFiltro, response.Data["filters"][0]["name"].ToString());
            });



        }
    }
}
