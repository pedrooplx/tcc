namespace TCC.Application.Models.Organizacao
{
    public class ObterOrganizacaoPorIdResponse
    {
        public long Id { get; set; }
        public string RazaoSocial { get; set; }
        public int Cnpj { get; set; }
        public string Area { get; set; }
    }
}
