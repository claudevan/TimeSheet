using System.Data.Entity.ModelConfiguration;
using TimeSheet.Modelo;

namespace TimeSheet.Entity.Map
{
    public class MarcacaoMap : EntityTypeConfiguration<Marcacao>
    {
        public MarcacaoMap()
        {
            ToTable("Marcacao");

            HasKey(x => x.Id);

            Property(x => x.UserId).IsRequired();
            Property(x => x.DataAlteracao);
            Property(x => x.Descricao).HasMaxLength(100);
            Property(x => x.DataMarcacao);
            Property(x => x.EntradaManha);
            Property(x => x.SaidaManha);
            Property(x => x.EntradaTarde);
            Property(x => x.SaidaTarde);
            Property(x => x.DataCadastro);
        }
    }
}
