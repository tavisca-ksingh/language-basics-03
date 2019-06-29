using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlans
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
            { 'c', GetLowestCarbMeals },

            { 'T', GetHighestCaloriesMeals },
            { 't', GetLowestCaloriesMeals },

            { 'F', GetHighestFatMeals },
            { 'f', GetLowestFatMeals },

            { 'P', GetHighestProteinMeals },
            { 'p', GetLowestProteinMeals },
           
        };

        private static List<Meal> GetHighestCarbMeals(List<Meal> meals)
        {
            //foreach (var c in meals)
            //{
            //    Console.WriteLine($"carbs ; {c.Carb} ;");
            //}
            var highestCarbValue = meals.Max(x => x.Carb);
            return meals.Where(x => x.Carb == highestCarbValue).ToList();
        }
        private static List<Meal> GetLowestCarbMeals(List<Meal> meals)
        {
            var lowCarbValue = meals.Min(x => x.Carb);
            return meals.Where(x => x.Carb == lowCarbValue).ToList();
        }
        private static List<Meal> GetHighestCaloriesMeals(List<Meal> meals)
        {
            var highestCalaoriesValue = meals.Max(x => x.Calaories);
            return meals.Where(x => x.Calaories == highestCalaoriesValue).ToList();
        }
        private static List<Meal> GetLowestCaloriesMeals(List<Meal> meals)
        {
            var lowCaloriesValue = meals.Min(x => x.Calaories);
            return meals.Where(x => x.Calaories == lowCaloriesValue).ToList();
        }

        private static List<Meal> GetHighestProteinMeals(List<Meal> meals)
        {
            var highestProteinValue = meals.Max(x => x.Protein);
            return meals.Where(x => x.Protein == highestProteinValue).ToList();
        }
        private static List<Meal> GetLowestProteinMeals(List<Meal> meals)
        {
            var lowProteinValue = meals.Min(x => x.Protein);
            return meals.Where(x => x.Protein == lowProteinValue).ToList();
        }

        private static List<Meal> GetHighestFatMeals(List<Meal> meals)
        {
            var highestFatValue = meals.Max(x => x.Fat);
            return meals.Where(x => x.Fat == highestFatValue).ToList();
        }
        private static List<Meal> GetLowestFatMeals(List<Meal> meals)
        {
            var lowFatValue = meals.Min(x => x.Fat);
            return meals.Where(x => x.Fat == lowFatValue).ToList();
        }
    }
}
