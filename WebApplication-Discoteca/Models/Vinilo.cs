namespace WebApplication_Discoteca.Models
{
    public class Vinilo
    {
        private long id;
        private string titulo_disco;
        private string nombre_artista;
        private int ano;
        private string canciones;
        private float precio;
        private string estado;
        private DateTime fechaAlta;

        public long Id { get => id; set => id = value; }
        public string Titulo_disco { get => titulo_disco; set => titulo_disco = value; }
        public string Nombre_artista { get => nombre_artista; set => nombre_artista = value; }
        public int Ano { get => ano; set => ano = value; }
        public string Canciones { get => canciones; set => canciones = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Estado { get => estado; set => estado = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta=value; }
    }
}
