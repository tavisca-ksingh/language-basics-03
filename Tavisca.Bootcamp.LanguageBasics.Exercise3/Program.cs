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
                new[] { "P", "p","C","c", "F", "f", "T", "t" }, 
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
       
            int n = protein.Length;
            var calories = new int[n];

            for(int i = 0;i <n; i++)
            {
                calories[i] =( protein[i] + carbs[i])*5 + fat[i]* 9 ;
            }
           var meals = new int[dietPlans.Length];
             for(int i=0; i<dietPlans.Length;i++)
             {
                 string dp = dietPlans[i];
                 
                if(dp.Length == 0) meals[i]=0;

                List<int> ind = new List<int>();
                for(int k=0; k<n; k++) ind.Add(k);
                    int max,min;
                foreach(var ch in dp)
                {
                    switch(ch){
                        case 'P':
                            max = MaxNum(protein,ind);
                            ind = FindAllIndices(protein,ind,max);
                           break;
                        case 'p':
                            min = MinNum(protein,ind);
                             ind = FindAllIndices(protein,ind,min);
                            break;
                         case 'F':
                            max = MaxNum(fat,ind);
                            ind = FindAllIndices(fat,ind,max);
                           break;
                        case 'f':
                            min = MinNum(fat,ind);
                             ind = FindAllIndices(fat,ind,min);
                            break;
                         case 'C':
                            max = MaxNum(carbs,ind);
                             ind = FindAllIndices(carbs,ind,max);
                           break;
                        case 'c':
                            min = MinNum(carbs,ind);
                             ind = FindAllIndices(carbs,ind,min);
                            break;
                         case 'T':
                            max = MaxNum(calories,ind);
                             ind = FindAllIndices(calories,ind,max);
                           break;
                        case 't':
                            min = MinNum(calories,ind);
                            ind = FindAllIndices(calories,ind,min);
                            break;
                        
                    }
                }
                meals[i] = ind[0];
            }           
            return meals;
        }

        public static List<int> FindAllIndices(int[] arr, List<int> indx,int elem)
        {
            List<int> indices = new List<int>();
            foreach(int i in indx){
                if(arr[i]== elem) indices.Add(i);
            }
            return indices;
        }
        public static int MaxNum(int [] arr,List<int> indx ){
                if(indx.Count == 1) return arr[indx[0]];

                int max = arr[indx[0]];
                
                for(int i=1; i<indx.Count; i++)
                {
                    if(arr[indx[i]] > max) max = arr[indx[i]];
                }
                return max;
            }
        public static int MinNum(int [] arr,List<int> indx ){
                if(indx.Count == 1) return arr[indx[0]];

                var min = arr[indx[0]];
                
                for(int i=1; i<indx.Count; i++)
                {
                    if(arr[indx[i]] < min) min = arr[indx[i]];
                }
                return min;
            }

    }
}
