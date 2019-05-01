using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class Recipe_IngredientsModel
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

        [Required]
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

        [Required]
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
        
        [Required]
        [Range(0,9999)]
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

        [Required]
        [StringLength(20)]
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