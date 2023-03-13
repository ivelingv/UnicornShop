namespace UnicornShop.Application.Models
{
    /// <summary>
    /// Get ShoppingCart Item.Product.Name
    /// </summary>
    public class ShoppingCartItem
    {
        public virtual long? Id { get; protected internal set; }
        public virtual long? ProductId { get; protected internal set; }
        public virtual long? PriceId { get; protected internal set; }
        public virtual long? ShoppingCartId { get; protected internal set; }      
        public virtual Product Product { get; protected internal set; }
        public virtual Price Price { get; protected internal set; }
        public virtual ShoppingCart ShoppingCart { get; protected internal set; }
    }
}
