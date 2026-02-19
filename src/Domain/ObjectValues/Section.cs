using src.Domain.Interface;

namespace src.Domain.ObjectValues;

public class Section : IPrototype<Section>
{
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsEditable { get; set; }
    public List<string> Placeholders { get; set; }

    public Section()
    {
        Placeholders = new List<string>();
    }

    public Section Clone()
    {
        return new Section
        {
            Name = Name,
            Content = Content,
            IsEditable = IsEditable,
            Placeholders = new List<string>(Placeholders)
        };
    }
}