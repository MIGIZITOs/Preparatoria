using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Preparatoria.Controllers;
using Preparatoria.Models;

namespace UnitTestPreparatoria
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            //ARRANGE
            TapiasController controller = new TapiasController();
            //ACT
            var listaPersonas = controller.GetTapias();
            //ASSERT
            Assert.IsNotNull(listaPersonas);
        }
        [TestMethod]
        public void TestPost()
        {
            //ARRANGE
            TapiasController controller = new TapiasController();
            Tapia tapia = new Tapia()
            {
                TapiaID = 1,
                FriendofTapia = "Camacho",
                place = Place.Hipermaxi,
                Email = "mimacho@gmail.com",
                Birthdate = DateTime.Now
            };
            //ACT
            IHttpActionResult actionResult = controller.PostTapia(tapia);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Tapia>;
            //ASSERT
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);

        }
        [TestMethod]
        public void TestPut()
        {   //ARRANGE
            TapiasController controller = new TapiasController();
            Tapia tapia = new Tapia()
            {
                TapiaID = 1,
                FriendofTapia = "Camacho",
                place = Place.Hipermaxi,
                Email = "mimacho@gmail.com",
                Birthdate = DateTime.Now
            };
            //ACT
            IHttpActionResult actionResultPost = controller.PostTapia(tapia);
            var result = controller.PutTapia(tapia.TapiaID, tapia) as StatusCodeResult;
        }
        [TestMethod]
        public void TestDelete()
        {
            //ARRANGE
            TapiasController controller = new TapiasController();
            Tapia tapia = new Tapia()
            {
                TapiaID = 1,
                FriendofTapia = "Camacho",
                place = Place.Hipermaxi,
                Email = "mimacho@gmail.com",
                Birthdate = DateTime.Now
            };
            //ACT   
            IHttpActionResult actionResultPost = controller.PostTapia(tapia);
            IHttpActionResult actionResultDelete = controller.DeleteTapia(tapia.TapiaID);
            //ASSERT
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Tapia>));
        }
    }
}
