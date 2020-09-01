using System.ComponentModel.DataAnnotations;
namespace RedisWebAPIDemo.Models
{
    public class CountryMaster
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
    }
}
