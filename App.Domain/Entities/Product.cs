using App.Shared.Entity;

namespace App.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, decimal price, decimal quantityOnHand, string image)
        {
            Title = title;
            Price = price;
            QuantityOnHand = quantityOnHand;
            Image = image;
        }

        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }
        public string Image { get; private set; }


        public void DecreaseQuantity(decimal quantity) => QuantityOnHand -= quantity;
        
    }
}