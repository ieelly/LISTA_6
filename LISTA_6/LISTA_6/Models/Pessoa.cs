using LISTA_6.Validations;
using System.ComponentModel.DataAnnotations;

namespace LISTA_6.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Obrigatório")]
        public string Nome { get; set; }
        [CPFValidation(ErrorMessage = "Erro idade")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public double Peso { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public double Altura { get; set; }

        public double IMC
        {
            get
            {
                if (Altura > 0 && Peso > 0)
                {
                    return Math.Round(Peso / (Altura * Altura), 2);
                }
                return 0;
            }
        }
    }
}
