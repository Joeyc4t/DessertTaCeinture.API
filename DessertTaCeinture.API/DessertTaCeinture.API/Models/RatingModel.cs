using System;
using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class RatingModel
    {
        #region Fields
        private int _ConcatId;
        private int _UserId;
        private int _RecipeId;
        private int _RateId;
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

        [Required]
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
        public int RateId
        {
            get
            {
                return _RateId;
            }
            set
            {
                _RateId = value;
            }
        }

        [Required]
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