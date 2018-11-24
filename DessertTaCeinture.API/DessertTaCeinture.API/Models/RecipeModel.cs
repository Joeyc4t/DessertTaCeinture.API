using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DessertTaCeinture.API.Models
{
    public class RecipeModel
    {
        #region Fields
        private int _Id;
        private string _Title;
        private DateTime _CreationDate;
        private int _OriginId;
        private int _CreatorId;
        private int _CategoryId;
        private int _PictureId;
        private int _ThemeId;
        private bool _IsPublic;
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
        [StringLength(75)]
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

        [Required]
        public DateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                _CreationDate = value;
            }
        }
                
        public int OriginId
        {
            get
            {
                return _OriginId;
            }
            set
            {
                _OriginId = value;
            }
        }

        [Required]
        public int CreatorId
        {
            get
            {
                return _CreatorId;
            }
            set
            {
                _CreatorId = value;
            }
        }

        [Required]
        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                _CategoryId = value;
            }
        }

        [Required]
        public int PictureId
        {
            get
            {
                return _PictureId;
            }
            set
            {
                _PictureId = value;
            }
        }

        [Required]
        public int ThemeId
        {
            get
            {
                return _ThemeId;
            }
            set
            {
                _ThemeId = value;
            }
        }

        [Required]
        public bool IsPublic
        {
            get
            {
                return _IsPublic;
            }
            set
            {
                _IsPublic = value;
            }
        }
        #endregion
    }
}