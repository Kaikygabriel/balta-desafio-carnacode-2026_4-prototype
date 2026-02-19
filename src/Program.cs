using src.Applicaton.Services;

Console.WriteLine("=== Sistema de Templates de Documentos ===\n");

var service = new DocumentService();

Console.WriteLine("Criando 5 contratos de serviço via Prototype...");
var startTime = DateTime.Now;

for (int i = 1; i <= 5; i++)
{
    var contract = service.CreateFromPrototype("ServiceContract");
    contract.Title = $"Contrato #{i} - Cliente {i}";

    // personalizações específicas
    contract.Metadata["ClienteId"] = i.ToString();
}

var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
Console.WriteLine($"Tempo total: {elapsed}ms\n");

var consulting = service.CreateFromPrototype("ConsultingContract");
service.DisplayTemplate(consulting);