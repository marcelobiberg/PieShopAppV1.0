using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieApp.Models
{
    public class Feedback
    {
        [BindNever]
        public int FeedbackId { get; set; }

        [Required(ErrorMessage ="Nome é obrigatório!")]
        [MaxLength(100, ErrorMessage ="Máximo 100 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Formato de e-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mensagem é obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        public string Message { get; set; }

        public bool ContactMe { get; set; }
    }
}
