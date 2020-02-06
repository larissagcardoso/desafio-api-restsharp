using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Usuarios;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;


namespace DesafioTestesApi.Tests.Usuarios
{
    [TestFixture]
    public class DeletarUmUsuaruioTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()

        {
         
            #region Parameters
            List<string> idUsuario = SolicitacaoDBSteps.RetornaIdUsuarioDB();

            string usuario_id = idUsuario[0];

            //Resultado esperado
            string statusCodeEsperado = "NoContent";
            #endregion

      

            DeletarUmUsuarioRequest deletarUmUsuarioRequest = new DeletarUmUsuarioRequest(usuario_id);
            IRestResponse<dynamic> response = deletarUmUsuarioRequest.ExecuteRequest();

            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            }

        }

        [Test]
        [Parallelizable]
        public void DadosInvalidos()
        {
            #region Parameters
            string usuario_id = "oooaa#";

            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "Invalid user id";
            string code = "29";
            string  localized= "Invalid value for 'id'";

            #endregion
            DeletarUmUsuarioRequest deletarUmUsuarioRequest = new DeletarUmUsuarioRequest(usuario_id);
            IRestResponse<dynamic> response = deletarUmUsuarioRequest.ExecuteRequest();

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
