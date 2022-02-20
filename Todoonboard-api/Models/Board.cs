using System.ComponentModel.DataAnnotations;

namespace Todoonboard_api.Models
{
    public class Board
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        
    }
}