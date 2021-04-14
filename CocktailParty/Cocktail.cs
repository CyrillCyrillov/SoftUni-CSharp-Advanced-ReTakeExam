using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        

        /*

        •	Name: string
        •	Capacity: int - the maximum allowed number of ingredients in the cocktail
        •	MaxAlcoholLevel: int - the maximum allowed amount of alcohol in the cocktail


        */

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;

            ingredients = new List<Ingredient>();
            
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public List<Ingredient> Ingredients
        {
            get
            {
                return ingredients;
            }
        }

        public int CurrentAlcoholLevel
        {
            get
            {
                int currentAlcoholLevel = Ingredients.Sum(s => s.Alcohol);
                return currentAlcoholLevel;
            }
        }
        


        //•	Method Add(Ingredient ingredient) - adds the entity if there isn't an Ingredient with the same name and if there is enough space in terms of quantity and alcohol.

        public void Add(Ingredient name)
        {
            if(Ingredients.Count < Capacity && !Ingredients.Contains(name) && name.Alcohol < MaxAlcoholLevel )
            {
                Ingredients.Add(name);
            }
        }

        // •	Method Remove(string name) - removes an Ingredient from the cocktail with the given name, if such exists and returns bool if the deletion is successful.

        public bool Remove(string name)
        {
            Ingredient toRemove = Ingredients.FirstOrDefault(n => n.Name == name);
            
            if(toRemove == null)
            {
                return false;
            }

            Ingredients.Remove(toRemove);
            return true;
        }

        // •	Method FindIngredient(string name) - returns an Ingredient with the given name. If it doesn't exist, return null.

        public Ingredient FindIngredient(string name)
        {
            Ingredient finded = Ingredients.FirstOrDefault(n => n.Name == name);
            return finded;

        }

        //•	Method GetMostAlcoholicIngredient() – returns the Ingredient with most Alcohol.

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredients.OrderBy(a => a.Alcohol);

            return Ingredients.FirstOrDefault();


        }

        // •	Getter CurrentAlcoholLevel – returns the amount of alcohol currently in the cocktail

        


        public string Report()
        {
            

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();

        }

    }
}
