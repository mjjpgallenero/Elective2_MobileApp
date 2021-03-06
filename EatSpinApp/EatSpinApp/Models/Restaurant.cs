﻿using SQLite;
using System.Collections.Generic;

namespace EatSpinApp.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement, Column("RestaurantId")]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantType { get; set; }
        public string CuisineType { get; set; }
        public string ContactNumber { get; set; }

    }
}