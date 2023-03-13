namespace UnicornShop.Application.Models
{
    public class Product : IDatabaseModel
    {
        public virtual long? Id { get; protected internal set; }
        public virtual string Name { get; protected internal set; }
        public virtual string Description { get; protected internal set; }
        public virtual ProductStatus Status { get; protected internal set; }
        public virtual int Quanitity { get; protected internal set; }
        public virtual string FileId { get; protected internal set; }
        public virtual long? CategoryId { get; protected internal set; }
        public virtual long? PriceId { get; protected internal set; }
        public virtual Category Category { get; protected internal set; }
        public virtual Price Price { get; protected internal set; }

        public void ChangePrice(
            Price price)
        {
            if (price is null)
            {
                throw new System.Exception("You can't set a null price!");
            }

            if (price.Id == PriceId)
            {
                throw new System.ArgumentException("You can't set the same price!");
            }

            PriceId = price.Id;
            Price = price;
        }

        public void Update(
            string name, 
            string description, 
            Category category)
        {
            Name = name;
            Description = description;
            Category = category;
        }
    }
}
