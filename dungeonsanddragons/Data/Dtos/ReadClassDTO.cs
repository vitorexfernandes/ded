using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Data.Dtos
{
    public class ReadClassDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RequestHour  { get; set; } = DateTime.Now;
    }
}
