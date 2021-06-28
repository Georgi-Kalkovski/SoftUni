namespace MyPetProject.Data.Models
{
    using MyPetProject.Data.Common.Models;

    public class Setting : Common.Models.BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
