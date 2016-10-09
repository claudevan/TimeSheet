using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TimeSheet.ViewModels.Marcacao
{
    public class MarcacaoVM
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Usuário")]
        public int UserId { get; set; }

        [DisplayName("Data Marcação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "*")]
        public DateTime DataMarcacao { get; set; }

        [DisplayName("Entrada Manhã")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime? EntradaManha { get; set; }

        [DisplayName("Saída Manhã")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime? SaidaManha { get; set; }

        [DisplayName("Entrada Tarde")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime? EntradaTarde { get; set; }

        [DisplayName("Saída Tarde")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime? SaidaTarde { get; set; }

        [DisplayName("Descrição")]
        [DataType(DataType.MultilineText)]
        [MaxLength(100, ErrorMessage = "Maxímo 100 caracters")]
        public string Descricao { get; set; }
    }
}