using System;
using System.ComponentModel.DataAnnotations;

namespace DessertTaCeinture.API.Models
{
    public class RecipeModel
    {
        #region Fields
        private int _CategoryId;
        private DateTime _CreationDate;
        private int _CreatorId;
        private int _Id;
        private bool _IsPublic;
        private int? _OriginId;
        private string _Picture;
        private int _ThemeId;
        private string _Title;

        #endregion Fields

        #region Properties

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

        public int? OriginId
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
        public string Picture
        {
            get
            {
                return _Picture;
            }
            set
            {
                _Picture = value;
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

        #endregion Properties
    }
}