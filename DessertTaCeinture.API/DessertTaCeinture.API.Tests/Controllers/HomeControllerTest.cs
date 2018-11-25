using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DessertTaCeinture.API;
using DessertTaCeinture.API.Controllers;

namespace DessertTaCeinture.API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disposer
            HomeController controller = new HomeController();

            // Agir
            ViewResult result = controller.Index() as ViewResult;

            // Affirmer
            Assert.IsNotNull(result);
            Assert.AreEqual("DessertTaCeinture - API", result.ViewBag.Title);
        }
    }
}
