using System;

namespace TimeSheet.Modelo
{
    public sealed class Marcacao
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DataMarcacao { get; set; }
        public long? EntradaManha { get; set; }
        public long? SaidaManha { get; set; }
        public long? EntradaTarde { get; set; }
        public long? SaidaTarde { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
