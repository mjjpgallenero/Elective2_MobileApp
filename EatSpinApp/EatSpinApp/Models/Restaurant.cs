using SQLite;

namespace EatSpinApp.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement, Column("_restaurantId")]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}