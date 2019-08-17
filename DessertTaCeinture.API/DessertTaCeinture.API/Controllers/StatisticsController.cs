using DessertTaCeinture.DAL.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace DessertTaCeinture.API.Controllers
{
    /// <summary>
    /// Statistics controller.
    /// </summary>
    public class StatisticsController : ApiController
    {
        private StatisticsRepository repo = new StatisticsRepository();

        [HttpGet]
        [Route("api/Statistics/GenerateChart")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public Dictionary<string, int> GenerateChart(string id)
        {
            Dictionary<string, int> dico = new Dictionary<string, int>();

            switch (id)
            {
                case "chartUsers":
                    dico = repo.GetUsersCount();
                    break;
                case "chartCommentariesCount":
                    dico = repo.GetCommentariesCount();
                    break;
                case "chartRecipesByCategory":
                    dico = repo.GetRecipesByCategoryCount();
                    break;
                case "chartRecipesByOrigineCount":
                    dico = repo.GetRecipesByOriginCount();
                    break;
                case "chartRecipesVisibility":
                    dico = repo.GetRecipesCount();
                    break;
                case "chartRates":
                    dico = repo.GetRatesCount();
                    break;
            };

            return dico;
        }
    }
}
