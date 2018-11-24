﻿using DessertTaCeinture.DAL.Enumerations;
using System;

namespace DessertTaCeinture.API.Models
{
    public class Recipe_IngredientsModel
    {
        #region Fields
        private int _ConcatId;
        private int _RecipeId;
        private int _IngredientId;
        private int _Quantity;
        private EUnits _Unit;
        #endregion

        #region Properties
        public int ConcatId
        {
            get
            {
                return _ConcatId;
            }
            set
            {
                _ConcatId = Convert.ToInt32((RecipeId.ToString()) + (IngredientId.ToString()));
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

        public int IngredientId
        {
            get
            {
                return _IngredientId;
            }
            set
            {
                _IngredientId = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }

        public EUnits Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
            }
        }
        #endregion
    }
}