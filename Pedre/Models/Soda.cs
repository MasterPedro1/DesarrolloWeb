using System.ComponentModel.DataAnnotations;

namespace Pedre.Models
{
    public class Soda
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Realese { get; set; }
        public string? Name { get; set; }
        public string? Flavor { get; set; }
        public decimal Price { get; set; }
    }
}