using System;
using System.Linq;
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
            var result = controller.Get().FirstOrDefault();

            Assert.AreEqual(result.GetType(), typeof(UserModel));
        }

        [TestMethod]
        public void GetShouldReturnNotFoundIfNotExists()
        {
            var result = controller.Get(132550);

            Assert.IsTrue(result.GetType().Equals(typeof(NotFoundResult)));
        }

        [TestMethod]
        public void GetShouldBadRequestIfNegativeId()
        {
            var result = controller.Get(-3);

            Assert.IsTrue(result.GetType().Equals(typeof(BadRequestResult)));
        }

        [TestMethod]
        public void GetShouldReturnMultipleRows()
        {
            IQueryable<UserModel> result = controller.Get();

            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetShouldReturnOkNegociatedContentResult()
        {
            var result = controller.Get(3);

            Assert.IsTrue(result.GetType().Equals(typeof(OkNegotiatedContentResult<UserModel>)));
        }

        [TestMethod]
        public void PostShouldReturnBadRequestIfNullObject()
        {
            var result = controller.Post(null);

            Assert.IsTrue(result.GetType().Equals(typeof(BadRequestErrorMessageResult)));
        }

        [TestMethod]
        public void PostShouldReturnInvalidModelStateIfWrongObject()
        {
            UserModel model = new UserModel();

            var result = controller.Post(model);

            Assert.IsTrue(result.GetType().Equals(typeof(InvalidModelStateResult)));
        }

        [TestMethod]
        public void PostShouldReturnOkNegociatedContentResultIfSuccess()
        {
            UserModel model = new UserModel();
                model.LastName = "Boeme";
                model.FirstName = "Joey";
                model.Gender = true;
                model.Email = "joey.boeme@live.fr";
                model.Password = "test";

            var result = controller.Post(model);

            Assert.IsTrue(result.GetType().Equals(typeof(OkNegotiatedContentResult<UserModel>)));
        }

        [TestMethod]
        public void DeleteShouldReturnOkNegociatedContentResultIfSuccess()
        {
            var result = controller.Delete(3);

            Assert.IsTrue(result.GetType().Equals(typeof(OkNegotiatedContentResult<bool>)));
        }
    }
}
