using System;
using System.ComponentModel.DataAnnotations;

namespace Unisystem.UI.ViewModels
{
    public class UserVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencher campo Nome!")]
        [MaxLength(150, ErrorMessage = "Campo nome precisa ter no máximo 150 caracteres!")]
        [MinLength(5, ErrorMessage = "Campo nome precisa ter no mínimo 5 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencher campo Email!")]
        [MaxLength(150, ErrorMessage = "Campo Email precisa ter no máximo 150 caracteres!")]
        [MinLength(5, ErrorMessage = "Campo Email precisa ter no mínimo 5 caracteres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencher campo Telefone!")]
        [MaxLength(150, ErrorMessage = "Campo Telefone precisa ter no máximo 20 caracteres!")]
        [MinLength(8, ErrorMessage = "Campo Telefone precisa ter no mínimo 8 caracteres!")]
        public string Phone { get; set; }

        public DateTime Created { get; set; }
    }
}