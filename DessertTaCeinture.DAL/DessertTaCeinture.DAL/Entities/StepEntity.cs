using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Step")]
    public class StepEntity
    {
        #region Fields
        private int _Id;
        private int _StepOrder;
        private string _Description;
        private int _RecipeId;
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

        public int StepOrder
        {
            get
            {
                return _StepOrder;
            }
            set
            {
                _StepOrder = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
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
        #endregion
    }
}
