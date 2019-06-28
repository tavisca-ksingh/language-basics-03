using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise3
{
    public class MealSelector
    {
        public MealSelector(List<Meal> meals)
        {
            _meals = meals;
        }
        private List<Meal> _meals;
        public Meal GetPreferredMeal(string dietPlan)
        {
            //set initial value to all menu items
            var preferredMeals = _meals;
            foreach (var dietPlanCode in dietPlan)
            {
                //filter progressively as per diet plan
                preferredMeals = Filter[dietPlanCode](preferredMeals);
                if (preferredMeals.Count == 1)
                    break;
            }
            return preferredMeals.First();
        }

        Dictionary<char, Func<List<Meal>, List<Meal>>> Filter = new Dictionary<char, Func<List<Meal>, List<Meal>>>()
        {
            { 'C', GetHighestCarbMeals },
            //todo
        };

        private static List<Meal> GetHighestCarbMeals(List<Meal> meals)
        {
            var highestCarbValue = meals.Max(x => x.Carb);
            return meals.Where(x => x.Carb == highestCarbValue).ToList();
        }
    }
}
