namespace Spoon.Demo.Domain.Entities;

public partial class Size
{
    public int SizeId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public virtual ICollection<Gender> Genders { get; set;}
}
