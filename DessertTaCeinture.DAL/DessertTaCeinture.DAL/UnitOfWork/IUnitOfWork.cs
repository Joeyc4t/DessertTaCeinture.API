using DessertTaCeinture.DAL.Entities;
using System;
using Tools.Generic;

namespace DessertTaCeinture.DAL.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<CategoryEntity> CategoryRepository { get; }   
        IRepository<IngredientEntity> IngredientRepository { get; }  
        IRepository<OriginEntity> OriginRepository { get; }   
        IRepository<PictureEntity> PictureRepository { get; }   
        IRepository<RateEntity> RateRepository { get; }   
        IRepository<Recipe_IngredientsEntity> Recipe_IngredientsRepository { get; }
        IRepository<RecipeEntity> RecipeRepository { get; }   
        IRepository<RoleEntity> RoleRepository { get; }   
        IRepository<ThemeEntity> ThemeRepository { get; }   
        IRepository<UserEntity> UserRepository { get; }   
        IRepository<NewsEntity> NewsRepository { get; }   
        IRepository<StepEntity> StepRepository { get; }   
        IRepository<LogsEntity> LogsRepository { get; }   
    }
}
