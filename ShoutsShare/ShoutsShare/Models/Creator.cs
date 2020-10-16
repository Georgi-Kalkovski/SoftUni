using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;

namespace ShoutsShare.Models
{
    public class Creator
    {
        public Creator()
        {
            this.Contents = new HashSet<Content>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Counter => Contents.Sum(c => c.Counter);
        public string Info { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedUrl { get; set; }
        public string YouTubeUrl { get; set; }
        public string TwitchUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string InstagramkUrl { get; set; }
        public string RedditkUrl { get; set; }
        public string TikTokUrl { get; set; }
        public string SnapchatUrl { get; set; }

        public ICollection<Content> Contents { get; set; }

        public List<Creator> Friends { get; set; }

        public Country Country { get; set; }

        public State State { get; set; }

        public City City { get; set; }
    }
}