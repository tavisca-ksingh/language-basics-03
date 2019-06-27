using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
     static void Main(string[] args)
        {
            Test(
                 new[] { 3, 4 },
                 new[] { 2, 8 },
                 new[] { 5, 2 },
                 new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                 new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                 new[] { 3, 4, 1, 5 },
                 new[] { 2, 8, 5, 1 },
                 new[] { 5, 2, 4, 4 },
                 new[] { "tFc", "tF", "Ftc" },
                 new[] { 3, 2, 0 });
            Test(
                 new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                 new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                 new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                 new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                 new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });


        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int mealsCount = protein.Length;
            var calories = new int[mealsCount];

            for (int i = 0; i < mealsCount; i++)
            {
                calories[i] = (protein[i] + carbs[i]) * 5 + fat[i] * 9;
            }
            var meals = new int[dietPlans.Length];
            for (int i = 0; i < dietPlans.Length; i++)
            {
                string dietPlan = dietPlans[i];

                if (dietPlan.Length == 0) meals[i] = 0;

                var MealsIndex = GetMealsDetails(protein, carbs, fat, calories, dietPlan);

                meals[i] = MealsIndex[0];

            }
            return meals;
        }

        public static List<int> GetMealsDetails(int[] protein, int[] carbs, int[] fat, int[] calories, string deitplan)
        {
            List<int> indices = new List<int>();

            for (int k = 0; k < protein.Length; k++) indices.Add(k);

            foreach (var ch in deitplan)
            {
                switch (ch)
                {
                    case 'P':
                        indices = MaxNum(protein, indices);
                        break;
                    case 'p':
                        indices = MinNum(protein, indices);
                        break;
                    case 'F':
                        indices = MaxNum(fat, indices);
                        break;
                    case 'f':
                        indices = MinNum(fat, indices);
                        break;
                    case 'C':
                        indices = MaxNum(carbs, indices);
                        break;
                    case 'c':
                        indices = MinNum(carbs, indices);
                        break;
                    case 'T':
                        indices = MaxNum(calories, indices);
                        break;
                    case 't':
                        indices = MinNum(calories, indices);
                        break;

                }
            }
            return indices;
        }


        public static List<int> MaxNum(int[] arr, List<int> indx)
        {

            List<int> Temp1 = new List<int>();

            int max = arr[indx[0]];
            for (int i = 1; i < indx.Count; i++)
                if (arr[indx[i]] > max) max = arr[indx[i]];

            for (int i = 0; i < indx.Count; i++)
                if (arr[indx[i]] == max) Temp1.Add(indx[i]);

            return Temp1;
        }
        public static List<int> MinNum(int[] arr, List<int> indx)
        {
            List<int> Temp1 = new List<int>();
            int min = arr[indx[0]];
            for (int i = 1; i < indx.Count; i++)
                if (arr[indx[i]] < min) min = arr[indx[i]];

            for (int i = 0; i < indx.Count; i++)
                if (arr[indx[i]] == min) Temp1.Add(indx[i]);

            return Temp1;
        }

    }
}
