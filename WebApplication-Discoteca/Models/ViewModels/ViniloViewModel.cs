using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Discoteca.Models.ViewModels
{
    public class ViniloViewModel
    {
        private long id;
        private string titulo_disco;
        private string nombre_artista;
        private int ano;
        private string canciones;
        private float precio;
        private string estado;
        private DateTime fechaAlta;

        [DisplayName("Id")]
        public long Id { get => id; set => id = value; }

        [DisplayName("Título")]
        [Required]
        public string Titulo_disco { get => titulo_disco; set => titulo_disco = value; }

        [DisplayName("Artista")]
        [Required]
        public string Nombre_artista { get => nombre_artista; set => nombre_artista = value; }

        [DisplayName("Año")]
        [Required]
        public int Ano { get => ano; set => ano = value; }

        [DisplayName("Canciones")]
        [Required]
        [StringLength(1000)]
        public string Canciones { get => canciones; set => canciones = value; }

        [DisplayName("Precio")]
        [Required]
        public float Precio { get => precio; set => precio = value; }

        [DisplayName("Estado")]
        [Required]
        public string Estado { get => estado; set => estado = value; }

        [DisplayName("Fecha de alta")]
        [Required]
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta=value; }
    }
}
