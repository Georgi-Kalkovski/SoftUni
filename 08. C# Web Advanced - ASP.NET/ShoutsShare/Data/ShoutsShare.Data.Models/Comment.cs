namespace ShoutsShare.Data.Models
{
    using ShoutsShare.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int MovieId { get; set; }

        public virtual Video Video { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ContentWorldUser User { get; set; }
    }
}
