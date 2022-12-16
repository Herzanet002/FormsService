﻿using FormsService.DAL.Entities.Base;
using System.Text.Json.Serialization;

namespace FormsService.DAL.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }

        public int DishPrice { get; set; }

        public int DishCategoryId { get; set; }

        public DishCategory? Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }

        [JsonIgnore]
        public virtual ICollection<DishOrder>? DishOrders { get; set; }
    }
}