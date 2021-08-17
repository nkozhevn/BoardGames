using System;
using System.ComponentModel.DataAnnotations;

namespace BoardGames.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name of the game")]
        public string Name { get; set; }
        [Range(0, 10, ErrorMessage = "Rating should be in range of 10")]
        [Required(ErrorMessage = "Enter rating of the game")]
        public int Rating { get; set; }
    }
}
