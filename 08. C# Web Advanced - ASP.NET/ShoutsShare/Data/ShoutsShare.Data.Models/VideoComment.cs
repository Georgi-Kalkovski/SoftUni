using ShoutsShare.Data.Common.Models;

namespace ShoutsShare.Data.Models
{
    public class VideoComment : BaseDeletableModel<int>
    {
        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        public int? ParentId { get; set; }

        public virtual VideoComment Parent { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ContentWorldUser User { get; set; }
    }
}