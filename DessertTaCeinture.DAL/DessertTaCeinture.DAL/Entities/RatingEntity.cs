using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Rating")]
    public class RatingEntity
    {
        #region Fields
        private int _ConcatId;
        private int _UserId;
        private int _RecipeId;
        private DateTime _RatingDate;
        private string _Commentary;
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
                _ConcatId = Convert.ToInt32((UserId.ToString()) + (RecipeId.ToString()));
            }
        }

        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
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

        public DateTime RatingDate
        {
            get
            {
                return _RatingDate;
            }
            set
            {
                _RatingDate = value;
            }
        }

        public string Commentary
        {
            get
            {
                return _Commentary;
            }
            set
            {
                _Commentary = value;
            }
        }
        #endregion
    }
}
