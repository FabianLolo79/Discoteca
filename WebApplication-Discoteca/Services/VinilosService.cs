using MySql.Data.MySqlClient;
using System.Data;
using WebApplication_Discoteca.Models;

namespace WebApplication_Discoteca.Services
{
    public class VinilosService
    {
        public void AltaDeVinilo(Vinilo vinilo)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO vinilos_lp (titulo_disco, nombre_artista, año, canciones, precio, estado, fechaAlta) VALUES "
                    + " (@titulo_disco, @nombre_artista, @año, @canciones, @precio, @estado, @fechaAlta);";
            command.Parameters.AddWithValue("@titulo_disco", vinilo.Titulo_disco);
            command.Parameters.AddWithValue("@nombre_artista", vinilo.Nombre_artista);
            command.Parameters.AddWithValue("@año", vinilo.Ano);
            command.Parameters.AddWithValue("@canciones", vinilo.Canciones);
            command.Parameters.AddWithValue("@precio", vinilo.Precio);
            command.Parameters.AddWithValue("@estado", vinilo.Estado);
            command.Parameters.AddWithValue("@fechaAlta", vinilo.FechaAlta);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void BorrarVinilo(long id)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM vinilos_lp WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Vinilo RecuperarVinilo(long id)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, titulo_disco, nombre_artista, año, canciones, precio, estado, fechaAlta FROM vinilos_lp WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = command.ExecuteReader();
            Vinilo vinilo = null;
            if (dr.Read())
            {
                vinilo = new Vinilo();
                vinilo.Id = dr.GetInt64("id");
                vinilo.Titulo_disco = dr.GetString("titulo_disco");
                vinilo.Nombre_artista = dr.GetString("nombre_artista");
                vinilo.Ano = dr.GetInt32("año");
                vinilo.Canciones = dr.GetString("canciones");
                vinilo.Precio = dr.GetFloat("precio");
                vinilo.Estado = dr.GetString("estado");
                vinilo.FechaAlta = dr.GetDateTime("fechaALta");
            }

            connection.Close();

            return vinilo;
        }

        public List<Vinilo> RecuperarListadoDeVinilos()
        {
            List<Vinilo> vinilos = new List<Vinilo>();
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, titulo_disco, nombre_artista, año, canciones, precio, estado, fechaAlta FROM vinilos_lp";
            MySqlDataReader dr = command.ExecuteReader();
            Vinilo vinilo = null;
            while (dr.Read())
            {
                vinilo = new Vinilo();
                vinilo.Id = dr.GetInt64("id");
                vinilo.Titulo_disco = dr.GetString("titulo_disco");
                vinilo.Nombre_artista = dr.GetString("nombre_artista");
                vinilo.Ano = dr.GetInt32("año");
                vinilo.Canciones = dr.GetString("canciones");
                vinilo.Precio = dr.GetFloat("precio");
                vinilo.Estado = dr.GetString("estado");
                vinilo.FechaAlta = dr.GetDateTime("fechaALta");
                vinilos.Add(vinilo);
            }

            connection.Close();

            return vinilos;
        }

        //sobrecarga del método para el buscador
        public List<Vinilo> RecuperarListadoDeVinilos(string textoBuscar)
        {
            List<Vinilo> vinilos = new List<Vinilo>();
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, titulo_disco, nombre_artista, año, canciones, precio, estado, fechaAlta FROM " +
                " vinilos_lp WHERE titulo_disco LIKE @textoBuscar OR nombre_artista LIKE @textoBuscar OR" +
                " año LIKE @textoBuscar OR precio LIKE @textoBuscar";
            string parametroTextoBuscar = "%" + textoBuscar + "%";
            command.Parameters.AddWithValue("@textoBuscar", parametroTextoBuscar);
            MySqlDataReader dr = command.ExecuteReader();
            Vinilo vinilo = null;
            while (dr.Read())
            {
                vinilo = new Vinilo();
                vinilo.Id = dr.GetInt64("id");
                vinilo.Titulo_disco = dr.GetString("titulo_disco");
                vinilo.Nombre_artista = dr.GetString("nombre_artista");
                vinilo.Ano = dr.GetInt32("año");
                vinilo.Canciones = dr.GetString("canciones");
                vinilo.Precio = dr.GetFloat("precio");
                vinilo.Estado = dr.GetString("estado");
                vinilo.FechaAlta = dr.GetDateTime("fechaALta");
                vinilos.Add(vinilo);
            }

            connection.Close();

            return vinilos;
        }

        public static void ActualizarVinilo(Vinilo vinilo)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE vinilos_lp SET titulo_disco = @titulo_disco, nombre_artista = @nombre_artista, año = @año, canciones = @canciones, precio = @precio, estado = @estado WHERE id = @id";
            command.Parameters.AddWithValue("@titulo_disco", vinilo.Titulo_disco);
            command.Parameters.AddWithValue("@nombre_artista", vinilo.Nombre_artista);
            command.Parameters.AddWithValue("@año", vinilo.Ano);
            command.Parameters.AddWithValue("@canciones", vinilo.Canciones);
            command.Parameters.AddWithValue("@precio", vinilo.Precio);
            command.Parameters.AddWithValue("@estado", vinilo.Estado);
            command.Parameters.AddWithValue("@id", vinilo.Id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
