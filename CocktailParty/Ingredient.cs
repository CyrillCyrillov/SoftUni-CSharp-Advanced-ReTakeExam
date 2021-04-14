using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        /*
        •	Name: string
        •	Alcohol: int
        •	Quantity: int

        */

        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }


        public string Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Ingredient: {Name}");
            result.AppendLine($"Quantity: {Quantity}");
            result.AppendLine($"Alcohol: {Alcohol}");

            return result.ToString();
        }
    }
}
