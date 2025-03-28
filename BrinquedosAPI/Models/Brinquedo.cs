namespace BrinquedosAPI.Models
{
    public class Brinquedo
    {
        public int Id_brinquedo { get; set; }
        public string Nome_brinquedo { get; set; }
        public string Tipo_brinquedo { get; set; }
        public string Classificacao { get; set; }
        public string Tamanho { get; set; }
        public decimal Preco { get; set; }
    }
}
