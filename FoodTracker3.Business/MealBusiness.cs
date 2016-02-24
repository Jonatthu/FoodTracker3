using FoodTracker3.Data.Repositories;
using FoodTracker3.Data.UnitOfWork;
using FoodTracker3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Business
{
    public class MealBusiness
    {
        private readonly MealUnitOfWork MealUnitOfWork;

        public MealBusiness(MealUnitOfWork MealUnitOfWork)
        {
            this.MealUnitOfWork = MealUnitOfWork;
        }

        public void AddNew(Meal model)
        {
            this.MealUnitOfWork.MealRepository.Insert(model);
            this.MealUnitOfWork.SaveChanges();
        }

        public Meal GetMeal(int Id)
        {
            var model = this.MealUnitOfWork.MealRepository.GetById(Id);
            return model;
        }

        public void RemoveMeal(int Id)
        {
            var model = this.MealUnitOfWork.MealRepository.GetById(Id);
            model.Active = false;
            this.MealUnitOfWork.MealRepository.Update(model);
            this.MealUnitOfWork.SaveChanges();
        }

    }
}
