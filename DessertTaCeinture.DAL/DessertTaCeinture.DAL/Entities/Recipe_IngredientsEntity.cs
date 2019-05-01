using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Recipe_Ingredients")]
    public class Recipe_IngredientsEntity
    {
        #region Fields
        private int _Id;
        private int _RecipeId;
        private int _IngredientId;
        private int _Quantity;
        private string _Unit;
        #endregion

        #region Properties
        [Key]
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public int RecipeId
        {
            get
            {
                return _RecipeId;
            }
            set
            {
                _RecipeId = value;
            }
        }

        public int IngredientId
        {
            get
            {
                return _IngredientId;
            }
            set
            {
                _IngredientId = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }

        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
            }
        }
        #endregion
    }
}
