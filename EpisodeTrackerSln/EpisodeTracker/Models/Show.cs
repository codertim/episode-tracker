using System.ComponentModel.DataAnnotations;

namespace EpisodeTracker.Models
{
    public class Show
    {
        public int ShowId { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        public string LastEpisodeSeen { get; set; }
    }
}
