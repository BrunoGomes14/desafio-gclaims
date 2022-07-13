
namespace api.Domain.Entity
{
    public class CharacterFilter
    {
        public int Id { get; set; }
        public string OrderBy { get; set;} = "";
        public string NameStartsWith { get; set;} = "";
        public int Limit { get; set; } = 100;
        public int OffSet { get; set; } = 0;
    }
}