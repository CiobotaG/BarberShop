using BarberShop.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace BarberShop.Models
{
 public class ListHaircut
    {
 [PrimaryKey, AutoIncrement]
 public int ID { get; set; }
 [ForeignKey(typeof(Appointment))]
 public int AppointmentID { get; set; }
 public int HaircutID { get; set; }
 }
}
