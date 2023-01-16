using SQLite;
using SQLiteNetExtensions.Attributes;
namespace BarberShop.Models
{
    public class Haircuts
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<ListHaircut> ListHaircuts { get; set; }
    }
}