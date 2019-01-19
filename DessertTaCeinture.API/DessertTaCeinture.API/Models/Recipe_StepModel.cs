using System;
using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class Recipe_StepModel
    {
        #region Fields
        private int _ConcatId;
        private int _RecipeId;
        private int _StepId;
        #endregion

        #region Properties
        [Key]
        public int ConcatId
        {
            get
            {
                return _ConcatId;
            }
            set
            {
                _ConcatId = Convert.ToInt32((RecipeId.ToString()) + (StepId.ToString()));
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
        public int StepId
        {
            get
            {
                return _StepId;
            }
            set
            {
                _StepId = value;
            }
        }
        #endregion
    }
}