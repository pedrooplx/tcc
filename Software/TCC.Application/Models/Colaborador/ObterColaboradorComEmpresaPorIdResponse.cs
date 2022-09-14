namespace TCC.Application.Models.Colaborador
{
    public class ObterColaboradorComEmpresaPorIdResponse
    {
        public long Id { get; set; }
        public int Funcional { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Organizacao { get; set; }
    }
}
