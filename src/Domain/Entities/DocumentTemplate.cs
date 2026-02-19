using src.Domain.Interface;
using src.Domain.ObjectValues;

namespace src.Domain.Entities;

public class DocumentTemplate : IPrototype<DocumentTemplate>
{
    
    
    public string Title { get; set; }
    public string Category { get; set; }
    public List<Section> Sections { get; set; }
    public DocumentStyle Style { get; set; }
    public List<string> RequiredFields { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
    public ApprovalWorkflow Workflow { get; set; }
    public List<string> Tags { get; set; }

    public DocumentTemplate()
    {
        Sections = new List<Section>();
        RequiredFields = new List<string>();
        Metadata = new Dictionary<string, string>();
        Tags = new List<string>();
    }


    public DocumentTemplate Clone()
    {
        return new DocumentTemplate
                {
                    Title = Title,
                    Category = Category,
                    Style = Style?.Clone(),
                    Workflow = Workflow?.Clone(),
                    Sections = Sections.Select(s => s.Clone()).ToList(),
                    RequiredFields = new List<string>(RequiredFields),
                    Tags = new List<string>(Tags),
                    Metadata = new Dictionary<string, string>(Metadata)
                };
    }
}