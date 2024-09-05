﻿namespace RedisWithTool
{
    public class UserBasket
    {
        public UserBasket(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<Product> ProductsInBasket { get; set; } = new List<Product>();

    }
}
