public class RecipeBook
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public RecipeBook() 
    {
        Ingredients = new List<Ingredient>();
    }
     
    public void AddIngredient(string name, double quantity, string measurement, int steps, double calories)
    {
        Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Measurement = measurement, Steps = steps });
    }

    public void ScaleIngredients(double factor)
    {
        foreach (Ingredient ingredient in Ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    public void ResetQuantities()
    {
        // Reset quantities to original values
        // This could involve reloading the quantities from a saved state
    }

    public override string ToString()
    {
        return $"Recipe: {Name}";
    }
}

public class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Measurement { get; set; }
    public int Steps { get; set; }
    public double Calories { get; internal set; }

    public override string ToString()
    {
        return $"{Name} - {Quantity} {Measurement}";
    }
}