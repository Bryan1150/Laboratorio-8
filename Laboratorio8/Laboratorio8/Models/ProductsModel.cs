using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laboratorio8.Models
{
    public class ProductsModel
    {
        public int idProducto{ get; set; }

        [Display(Name = "Cantidad: ")]
        [Required(ErrorMessage = "Es necesario que ingrese la cantidad")]
        public int cantidad { get; set; }

        [Display(Name = "Nombre: ")]
        [Required(ErrorMessage = "Es necesario que ingrese el nombre de la pregunta")]
        public string nombre { get; set; }

        [Display(Name = "Ingrese el precio:")]
        [Required(ErrorMessage = "Es necesario que ingrese el precio")]
        public string precio { get; set; }

    }
}