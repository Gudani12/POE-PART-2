using System;
using System.Collections.Generic;

internal class RecipeManager
{
    public List<RecipeBook> Recipes { get; internal set; }

    // Define the delegate for calorie notification
    public delegate void RecipeCaloriesExceededHandler(object sender, EventArgs e);

    // Define the event for calorie notification
    public event RecipeCaloriesExceededHandler RecipeCaloriesExceeded;

    public RecipeManager()
    {
        Recipes = new List<RecipeBook>();
    }

    public void EnterRecipeDetails()
    {
        Console.WriteLine("Enter recipe details:");

        RecipeBook recipe = new RecipeBook();

        Console.Write("Enter recipe name: ");
        recipe.Name = Console.ReadLine();

        Console.Write("Enter the number of ingredients: ");
        int ingredientCount = int.Parse(Console.ReadLine());

        double totalCalories = 0;

        for (int i = 0; i < ingredientCount; i++)
        {
            Console.Write($"Enter ingredient {i + 1} name: ");
            string ingredientName = Console.ReadLine();

            Console.Write($"Enter quantity for {ingredientName}: ");
            double quantity = double.Parse(Console.ReadLine());

            Console.Write($"Enter measurement for {ingredientName}: ");
            string measurement = Console.ReadLine();

            Console.Write($"Enter steps for {ingredientName}: ");
            int steps = int.Parse(Console.ReadLine());

            Console.Write($"Enter calories for {ingredientName}: ");
            double calories = double.Parse(Console.ReadLine());

            totalCalories += calories;
            CheckerCalories(totalCalories);
            recipe.AddIngredient(ingredientName, quantity, measurement, steps, calories);
        }

        Recipes.Add(recipe);

        Console.WriteLine("Recipe added successfully.");

        // Check if total calories exceed 300 and notify if necessary
        if (totalCalories > 300)
        {
            OnRecipeCaloriesExceeded();
        }
    }

    private void CheckerCalories(double calories)
    {
        if (calories >= 300)
        {
            Console.WriteLine("Warning! Total calories exceed 300.");
        }
    }

    // Method to invoke the event for calorie notification
    protected virtual void OnRecipeCaloriesExceeded()
    {
        RecipeCaloriesExceeded?.Invoke(this, EventArgs.Empty);
    }

    // Method to display all recipes
    public void DisplayRecipes()
    {
        Console.WriteLine("Recipes:");
        foreach (RecipeBook recipe in Recipes)
        {
            Console.WriteLine(recipe);
        }
    }

    // Method to scale all recipes by a factor
    public void ScaleRecipe(double factor)
    {
        foreach (RecipeBook recipe in Recipes)
        {
            recipe.ScaleIngredients(factor);
        }
    }

    // Method to reset quantities of all recipes
    public void ResetQuantities()
    {
        foreach (RecipeBook recipe in Recipes)
        {
            recipe.ResetQuantities();
        }
    }

    // Method to clear all recipes
    public void ClearRecipe()
    {
        Recipes.Clear();
        Console.WriteLine("Recipes cleared.");
    }
}