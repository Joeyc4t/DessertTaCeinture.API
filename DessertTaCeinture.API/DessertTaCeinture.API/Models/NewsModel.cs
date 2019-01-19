using System;
using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class NewsModel
    {
        #region Fields
        private int _Id;
        private string _Title;
        private string _ImageUrl;
        private string _Summary;
        private string _Description;
        private DateTime _ReleaseDate;
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

        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        public string ImageUrl
        {
            get
            {
                return _ImageUrl;
            }
            set
            {
                _ImageUrl = value;
            }
        }

        public string Summary
        {
            get
            {
                return _Summary;
            }
            set
            {
                _Summary = value;
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

        public DateTime ReleaseDate
        {
            get
            {
                return _ReleaseDate;
            }
            set
            {
                _ReleaseDate = value;
            }
        }
        #endregion
    }
}