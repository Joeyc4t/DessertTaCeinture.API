using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Recipe_Step")]
    public class Recipe_StepEntity
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
