using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Models
{
    [Bind(Exclude = "FormularioId")]
    public class Formulario
    {
        [ScaffoldColumn(false)]
        public int FormularioId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Por favor ingrese un nombre")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "No se permiten números")]
        [Display(Name = "Nombre *")]
        public string Nombre { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Por favor ingrese un email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El email no es válido")]
        [Display(Name = "Email *")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Por favor ingrese un teléfono. Máximo de dígitos 10")]
        [MaxLength(10, ErrorMessage = "No se permiten mas de 10 dígitos")]
        [RegularExpression("([0-9]+)", ErrorMessage = "No se permiten letras")]
        [Display(Name = "Teléfono *")]
        public string Telefono { get; set; }

        public int No { get; set; }
    }

    public class FormularioDbcontext : DbContext
    {
        public DbSet<Formulario> formularios { get; set; }
    }
}