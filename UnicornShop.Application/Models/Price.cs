﻿namespace UnicornShop.Application.Models
{
    public class Price : IDatabaseModel
    {
        public Price(
            decimal amount, 
            string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public virtual long? Id { get; protected internal set; }
        public virtual decimal Amount { get; protected internal set; }
        public virtual string Currency { get; protected internal set; }
        public virtual Product Product { get; protected internal set; }
    }
}
