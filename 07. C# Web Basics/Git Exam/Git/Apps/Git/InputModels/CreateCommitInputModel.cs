using System;
using System.Collections.Generic;
using System.Text;

namespace Git.InputModels
{
    public class CreateCommitInputModel
    {
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public string RepositoryId { get; set; }
    }
}
