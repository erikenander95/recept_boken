namespace recept_boken.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public QuantityType QuantityType { get; set; }
    }
    public enum QuantityType
    {
        liter,
        deciliter,
        mililiter,
        centiliter,
        gram,
        kg
    };
}