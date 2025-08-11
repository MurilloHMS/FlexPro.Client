using FlexPro.Client.Infrastructure.Interfaces;

namespace FlexPro.Client.Infrastructure.Services;

public static class RouteHelperService
{
    public static Task<Dictionary<string, string>> GetRoutesAsync()
    {
        var routes = new Dictionary<string, string>()
        {
            { "Veiculos","/management/vehicles" },
            {"Buscar Veiculo","/management/vehicles/search"},
            {"Revisões","/management/vehicles/maintenance"},
            {"Abastecimentos","/management/vehicles/fuelings"},
            {"Parceiros","/management/people/partners"},
            {"Prestadores de serviço","/management/people/entities"},
            {"Categorias","/management/categories"},
            {"Checklist","/sales/inquiries/checklist"},
            {"Identidade Visual","/sales/documents/branding"},
            {"Separar Pdf","/tools/pdfmanager/splitpdf"},
            {"Calcular Custo Transportadoras","/tools/calculators/shippingcost"},
            {"Boa Solução","/tools/calculators/boasolucao"},
            {"Calcular ICMS","/tools/filemanager/icmsdata"},
            {"Coletar Dados Notas Fiscais","/tools/filemanager/invoicedata"},
            {"Renomear Notas","/tools/filemanager/identifyinvoices"},
            {"Separar Dados Cartões","/tools/filemanager/carddata"},
            {"Informativo","/automations/triggers/newsletter"},
            {"Administrativo Site","/administration/website"},
            {"Administrativo Geral","/administration/general"},
            {"Chamados","/support"},
            {"Api","https://api.proautokimium.com/index.html"},
        };
        return Task.FromResult(routes);
    }
}