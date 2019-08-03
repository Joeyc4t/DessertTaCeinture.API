using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.Repositories;
using Tools.Generic;

namespace DessertTaCeinture.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private IRepository<CategoryEntity> _CategoryRepository;
        private IRepository<IngredientEntity> _IngredientRepository;
        private IRepository<OriginEntity> _OriginRepository;
        private IRepository<PictureEntity> _PictureRepository;
        private IRepository<RateEntity> _RateRepository;
        private IRepository<Recipe_IngredientsEntity> _Recipe_IngredientsRepository;
        private IRepository<RecipeEntity> _RecipeRepository;
        private IRepository<RoleEntity> _RoleRepository;
        private IRepository<ThemeEntity> _ThemeRepository;
        private IRepository<UserEntity> _UserRepository;
        private IRepository<NewsEntity> _NewsRepository;
        private IRepository<StepEntity> _StepRepository;
        private IRepository<LogsEntity> _LogsRepository;
        #endregion

        #region Properties
        public IRepository<CategoryEntity> CategoryRepository
        {
            get
            {
                if (this._CategoryRepository == null) { this._CategoryRepository = new CategoryRepository(); }
                return this._CategoryRepository;
            }
        }

        public IRepository<IngredientEntity> IngredientRepository
        {
            get
            {
                if (this._IngredientRepository == null) { this._IngredientRepository = new IngredientRepository(); }
                return this._IngredientRepository;
            }
        }

        public IRepository<OriginEntity> OriginRepository
        {
            get
            {
                if (this._OriginRepository == null) { this._OriginRepository = new OriginRepository(); }
                return this._OriginRepository;
            }
        }

        public IRepository<PictureEntity> PictureRepository
        {
            get
            {
                if (this._PictureRepository == null) { this._PictureRepository = new PictureRepository(); }
                return this._PictureRepository;
            }
        }

        public IRepository<RateEntity> RateRepository
        {
            get
            {
                if (this._RateRepository == null) { this._RateRepository = new RateRepository(); }
                return this._RateRepository;
            }
        }

        public IRepository<Recipe_IngredientsEntity> Recipe_IngredientsRepository
        {
            get
            {
                if (this._Recipe_IngredientsRepository == null) { this._Recipe_IngredientsRepository = new Recipe_IngredientsRepository(); }
                return this._Recipe_IngredientsRepository;
            }
        }

        public IRepository<RecipeEntity> RecipeRepository
        {
            get
            {
                if (this._RecipeRepository == null) { this._RecipeRepository = new RecipeRepository(); }
                return this._RecipeRepository;
            }
        }
        
        public IRepository<RoleEntity> RoleRepository
        {
            get
            {
                if (this._RoleRepository == null) { this._RoleRepository = new RoleRepository(); }
                return this._RoleRepository;
            }
        }

        public IRepository<ThemeEntity> ThemeRepository
        {
            get
            {
                if (this._ThemeRepository == null) { this._ThemeRepository = new ThemeRepository(); }
                return this._ThemeRepository;
            }
        }

        public IRepository<UserEntity> UserRepository
        {
            get
            {
                if (this._UserRepository == null) { this._UserRepository = new UserRepository(); }
                return this._UserRepository;
            }
        }

        public IRepository<NewsEntity> NewsRepository
        {
            get
            {
                if (this._NewsRepository == null) { this._NewsRepository = new NewsRepository(); }
                return this._NewsRepository;
            }
        }

        public IRepository<StepEntity> StepRepository
        {
            get
            {
                if (this._StepRepository == null) { this._StepRepository = new StepRepository(); }
                return this._StepRepository;
            }
        }

        public IRepository<LogsEntity> LogsRepository
        {
            get
            {
                if (this._LogsRepository == null) { this._LogsRepository = new LogsRepository(); }
                return this._LogsRepository;
            }
        }
        #endregion

        #region Methods
        public void Dispose()
        {
        }
        #endregion
    }
}
