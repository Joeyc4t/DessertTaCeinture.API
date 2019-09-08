using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DessertTaCeinture.DAL.Entities
{
    [Table("Recipe")]
    public class RecipeEntity
    {
        #region Fields
        private int _CategoryId;
        private DateTime _CreationDate;
        private int _CreatorId;
        private int _Id;
        private bool _IsPublic;
        private bool? _IsValid;
        private int _OriginId;
        private string _Picture;
        private int _ThemeId;
        private string _Title;

        #endregion Fields

        #region Properties

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

        public bool? IsValid
        {
            get
            {
                return _IsValid;
            }
            set
            {
                _IsValid = value;
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