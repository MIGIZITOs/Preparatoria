using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Preparatoria.Models
{ 
    public enum Place
    {
        Hipermaxi,
        Fidalga,
        ICNorte,
        UPSA,
        Warnes
    }
    public class Tapia
    {
        [Key]
        public int TapiaID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, MinimumLength = 2)]
        public string FriendofTapia { get; set; }
        [Required]
        public Place place { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese solo correo")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

    }
}