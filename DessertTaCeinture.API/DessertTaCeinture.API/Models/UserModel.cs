﻿using System;

namespace DessertTaCeinture.API.Models
{
    public class UserModel
    {
        #region Fields
        private int _Id;
        private string _Password;
        private string _Salt;
        private string _LastName;
        private string _FirstName;
        private DateTime _BirthDate;
        private bool? _Gender;
        private DateTime _InscriptionDate;
        private bool _IsActive;
        private int _RoleId;
        #endregion

        #region Properties
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

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        public string Salt
        {
            get
            {
                return _Salt;
            }
            set
            {
                _Salt = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
            }
        }

        public bool? Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        public DateTime InscriptionDate
        {
            get
            {
                return _InscriptionDate;
            }
            set
            {
                _InscriptionDate = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }

        public int RoleId
        {
            get
            {
                return _RoleId;
            }
            set
            {
                _RoleId = value;
            }
        }
        #endregion
    }
}