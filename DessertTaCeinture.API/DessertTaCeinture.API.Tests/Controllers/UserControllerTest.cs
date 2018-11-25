using System;
using System.Web.Http.Results;
using DessertTaCeinture.API.Controllers;
using DessertTaCeinture.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DessertTaCeinture.API.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private UserController controller = new UserController();

        [TestMethod]
        public void GetShouldReturnSameType()
        {
        }

        [TestMethod]
        public void GetShouldReturnNotFoundIfNotExists()
        {
        }

        [TestMethod]
        public void GetShouldBadRequestIfNegativeId()
        {
        }

        [TestMethod]
        public void GetShouldReturnMultipleRows()
        {
        }

        [TestMethod]
        public void GetShouldReturnOkNegociatedContentResult()
        {
        }

        [TestMethod]
        public void PostShouldReturnBadRequestIfNullObject()
        {

        }

        [TestMethod]
        public void PostShouldReturnInvalidModelStateIfWrongObject()
        {
        }

        [TestMethod]
        public void PostShouldReturnBadRequestIfError()
        {
        }

        [TestMethod]
        public void PostShouldReturnOkNegociatedContentResultIfSuccess()
        {
            UserModel model = new UserModel();
                model.LastName = "Boeme";
                model.FirstName = "Joey";
                model.Gender = true;
                model.RoleId = 1;
                model.BirthDate = Convert.ToDateTime("04-12-1992");
                model.InscriptionDate = DateTime.Now;
                model.Email = "joey.boeme@computerland.be";
                model.Password = "test";

            var result = controller.Post(model);

            Assert.IsTrue(result.GetType().Equals(typeof(OkNegotiatedContentResult<UserModel>)));
        }

        [TestMethod]
        public void DeleteShouldReturnOkNegociatedContentResultIfSuccess()
        {
            var result = controller.Delete(2);

            Assert.IsTrue(result.GetType().Equals(typeof(OkNegotiatedContentResult<bool>)));
        }
    }
}
