using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Tarefas;


namespace DesafioTestesApi.Tests.Tarefas
{
    [TestFixture]
    public class ObterTarefasReportadaPorMimTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            string filter_id = "reported";

            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            ObterTarefasReportadaPorMimRequest obterTarefasReportadaPorMimRequest = new ObterTarefasReportadaPorMimRequest(filter_id);
            IRestResponse<dynamic> response = obterTarefasReportadaPorMimRequest.ExecuteRequest();


            
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosFiltroReport()
        {
            #region Parameters
            string filter_id = "desafio1";

            //Resultado esperado
            string statusCodeEsperado = "OK";
            string status_code = "404";
            string fault_string = "Unknown filter 'desafio1'";
            #endregion

            ObterTarefasReportadaPorMimRequest obterTarefasReportadaPorMimRequest = new ObterTarefasReportadaPorMimRequest(filter_id);
            IRestResponse<dynamic> response = obterTarefasReportadaPorMimRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(status_code, response.Data["issues"]["status_code"].ToString());
                Assert.AreEqual(fault_string, response.Data["issues"]["fault_string"].ToString());

            });
        }

    }
}
