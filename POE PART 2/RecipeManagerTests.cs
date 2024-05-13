using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RecipeManagerTests
{
    [TestClass]
    public class RecipeManagerTests
    {
        [TestMethod]
        public void TestEnterRecipeDetails_CaloriesBelowThreshold()
        {
            // Arrange
            RecipeManager recipeManager = new RecipeManager();
            int initialRecipeCount = recipeManager.Recipes.Count;

            // Act
            // Add ingredients with total calories below 300 
            RecipeBook recipe = new RecipeBook();
            recipe.AddIngredient("Ingredient 1", 100, "grams", 1, 100); // Add an ingredient with 100 calories
            recipeManager.Recipes.Add(recipe); // Add the recipe to the recipe manager
            recipeManager.EnterRecipeDetails();

            // Assert
            Assert.AreEqual(initialRecipeCount + 1, recipeManager.Recipes.Count, "Recipe not added correctly.");
        }

        [TestMethod]
        public void TestEnterRecipeDetails_CaloriesAboveThreshold()
        {
            // Arrange
            RecipeManager recipeManager = new RecipeManager();
            bool notificationReceived = false;
            recipeManager.RecipeCaloriesExceeded += (sender, e) => notificationReceived = true;

            // Act
            // Add ingredients with total calories exceeding 300
            RecipeBook recipe = new RecipeBook();
            recipe.AddIngredient("Ingredient 1", 150, "grams", 1, 150); // Add an ingredient with 150 calories
            recipe.AddIngredient("Ingredient 2", 200, "grams", 1, 200); // Add another ingredient with 200 calories
            recipeManager.Recipes.Add(recipe); // Add the recipe to the recipe manager
            recipeManager.EnterRecipeDetails();

            // Assert
            Assert.IsTrue(notificationReceived, "Calorie notification event not raised.");
        }
    }
}