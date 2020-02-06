using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Usuarios;
using DesafioTestesApi.DBSteps;
using System.Collections.Generic;

namespace DesafioTestesApi.Tests.Usuarios
{
    [TestFixture]
    public class ObterInfoMeuUsuarioTests : TestBase
    {
       
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters

            List<string> dadosUsuario = SolicitacaoDBSteps.RetornaInfoMeuUsuarioDB();

            //Resultado esperado
            string statusCodeEsperado = "OK";
            string idUsuario = dadosUsuario[0];
            string userName = dadosUsuario[1];
            string realName = dadosUsuario[2];
            string email = dadosUsuario[3];
            string accessLevel = dadosUsuario[4];
            
            #endregion

            ObterInfoMeuUsuarioRequest obterInfoMeuUsuarioRequest = new ObterInfoMeuUsuarioRequest();
            IRestResponse<dynamic> response = obterInfoMeuUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idUsuario, response.Data["id"].ToString());
                Assert.AreEqual(userName, response.Data["name"].ToString());
                Assert.AreEqual(realName, response.Data["real_name"].ToString());
                Assert.AreEqual(email, response.Data["email"].ToString());
                Assert.AreEqual(accessLevel, response.Data["access_level"]["id"].ToString());
            });
        }

  

    }
}
