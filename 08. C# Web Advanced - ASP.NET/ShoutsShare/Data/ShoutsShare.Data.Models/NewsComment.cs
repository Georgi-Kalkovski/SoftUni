using ShoutsShare.Data.Common.Models;

namespace ShoutsShare.Data.Models
{
    public class NewsComment : BaseDeletableModel<int>
    {
        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public int? ParentId { get; set; }

        public virtual NewsComment Parent { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ContentWorldUser User { get; set; }
    }
}