using src.Domain.Entities;
using src.Domain.ObjectValues;

namespace src.Applicaton.Services;

public class DocumentService
{
    private readonly Dictionary<string, DocumentTemplate> _prototypes = new();

    public DocumentService()
    {
        // cria UMA vez (caro)
        _prototypes["ServiceContract"] = BuildServiceContractPrototype();
        _prototypes["ConsultingContract"] = BuildConsultingContractPrototype();
    }
      private DocumentTemplate BuildServiceContractPrototype()
    {
        Console.WriteLine("Inicializando protótipo: Contrato de Serviço (caro)...");
        Thread.Sleep(100);

        var template = new DocumentTemplate
        {
            Title = "Contrato de Prestação de Serviços",
            Category = "Contratos",
            Style = new DocumentStyle
            {
                FontFamily = "Arial",
                FontSize = 12,
                HeaderColor = "#003366",
                LogoUrl = "https://company.com/logo.png",
                PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
            },
            Workflow = new ApprovalWorkflow
            {
                RequiredApprovals = 2,
                TimeoutDays = 5,
                Approvers = new List<string> { "gerente@empresa.com", "juridico@empresa.com" }
            },
            RequiredFields = new List<string> { "NomeCliente", "CPF", "Endereco" },
            Tags = new List<string> { "contrato", "servicos" },
            Metadata = new Dictionary<string, string>
            {
                ["Versao"] = "1.0",
                ["Departamento"] = "Comercial",
                ["UltimaRevisao"] = DateTime.Now.ToString()
            }
        };

        template.Sections.Add(new Section { Name = "Cláusula 1 - Objeto", Content = "O presente contrato tem por objeto...", IsEditable = true });
        template.Sections.Add(new Section { Name = "Cláusula 2 - Prazo", Content = "O prazo de vigência será de...", IsEditable = true });
        template.Sections.Add(new Section { Name = "Cláusula 3 - Valor", Content = "O valor total do contrato é de...", IsEditable = true });

        return template;
    }

    private DocumentTemplate BuildConsultingContractPrototype()
    {
        Console.WriteLine("Inicializando protótipo: Contrato de Consultoria (caro)...");
        Thread.Sleep(100);

        // Reaproveita grande parte do serviço: clone + pequenos ajustes
        var baseContract = _prototypes.ContainsKey("ServiceContract")
            ? _prototypes["ServiceContract"].Clone()
            : BuildServiceContractPrototype();

        baseContract.Title = "Contrato de Consultoria";
        baseContract.Tags = new List<string> { "contrato", "consultoria" };

        // muda só o que diferencia
        baseContract.Sections[0].Content = "O presente contrato de consultoria tem por objeto...";
        // pode remover ou adicionar seções específicas se quiser:
        baseContract.Sections.RemoveAll(s => s.Name.Contains("Valor"));

        baseContract.Metadata["Departamento"] = "Comercial";
        return baseContract;
    }

    // “Fábrica” via Prototype: rápido
    public DocumentTemplate CreateFromPrototype(string key)
    {
        if (!_prototypes.TryGetValue(key, out var proto))
            throw new ArgumentException($"Protótipo '{key}' não existe.");

        return proto.Clone();
    }

    public void DisplayTemplate(DocumentTemplate template)
    {
        Console.WriteLine($"\n=== {template.Title} ===");
        Console.WriteLine($"Categoria: {template.Category}");
        Console.WriteLine($"Seções: {template.Sections.Count}");
        Console.WriteLine($"Campos obrigatórios: {string.Join(", ", template.RequiredFields)}");
        Console.WriteLine($"Aprovadores: {string.Join(", ", template.Workflow.Approvers)}");
    }
}