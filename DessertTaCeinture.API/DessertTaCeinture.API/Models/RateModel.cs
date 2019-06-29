using System;
using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class RateModel
    {
        #region Fields
        private int _Id;
        private int _RateOnFive;
        private int _UserId;
        private int _RecipeId;
        private DateTime _Date;
        private string _Commentary;
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

        public int RateOnFive
        {
            get
            {
                return _RateOnFive;
            }
            set
            {
                _RateOnFive = value;
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

        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
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