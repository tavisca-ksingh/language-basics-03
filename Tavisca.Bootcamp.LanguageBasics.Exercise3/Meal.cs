using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlans
{
    public class Meal
    {
        public Meal(int id, int protein, int carb, int fat)
        {
            Id = id;
            Protein = protein;
            Carb = carb;
            Fat = fat;
            Calaories = (protein + carb) * 5 + fat * 9;        
        }

        public int Id { get; }
        public int Protein { get; }
        public int Carb { get; }
        public int Fat { get; }
        public int Calaories { get; }
    }
}
