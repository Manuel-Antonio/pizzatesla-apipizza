using System.ComponentModel.DataAnnotations;
using System;
namespace ApiPizza.Models
{
    public class Product
    {
        [Key]
        public int PizzaID { get; set; }
        public int CategoriaID { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Ingredientes { get; set; }
        public string? TiempoPreparacion { get; set; }
        public string? Imagen { get; set; }

    }
}
