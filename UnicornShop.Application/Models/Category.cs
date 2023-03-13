using System.Collections.Generic;

namespace UnicornShop.Application.Models
{
    public class Category : IDatabaseModel
    {
        public virtual long? Id { get; protected internal set; }
        public virtual string Name { get; protected internal set; }
        public virtual IList<Product> Products { get; protected internal set; }
    }
}
