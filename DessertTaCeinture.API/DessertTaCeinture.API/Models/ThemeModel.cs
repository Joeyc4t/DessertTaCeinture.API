﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DessertTaCeinture.API.Models
{
    public class ThemeModel
    {
        #region Fields
        private int _Id;
        private string _Name;
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

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        #endregion
    }
}