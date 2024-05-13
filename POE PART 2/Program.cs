using System;

internal class Program
{
    static void Main(string[] args)
    {
        // Create an instance of RecipeManager to manage recipes
        RecipeManager recipeManager = new RecipeManager();

        int choice;
        do
        {
            // Display menu options
            DisplayMenu();

            // Prompt user for choice
            Console.Write("Enter your choice: ");

            // Validate input
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            // Perform actions based on user choice 
            switch (choice)
            {
                case 1:
                    recipeManager.EnterRecipeDetails();
                    break;
                case 2:
                    recipeManager.DisplayRecipes();
                    break;
                case 3:
                    Console.Write("Enter scaling factor: ");
                    double factor = double.Parse(Console.ReadLine());
                    recipeManager.ScaleRecipe(factor);
                    break;
                case 4:
                    recipeManager.ResetQuantities();
                    break;
                case 5:
                    recipeManager.ClearRecipe();
                    break;
                case 9:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        } while (choice != 9);
    }

    // Method to display the menu options
    static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Enter recipe details");
        Console.WriteLine("2. Display recipe");
        Console.WriteLine("3. Scale recipe");
        Console.WriteLine("4. Reset quantities");
        Console.WriteLine("5. Clear recipe");
        Console.WriteLine("9. Exit");
    }

    // Method to exit the program
    static void Exit()
    {
        Console.WriteLine("Exiting program...");
        Environment.Exit(0);
    }
}