using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informando não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o numero do contato")]
        [Phone(ErrorMessage = "O telefone informado não é válido!")]
        public string Telefone { get; set; }

    }
}
