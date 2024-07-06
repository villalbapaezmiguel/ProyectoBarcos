using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Parcial.WindowsForm.Entidades;

namespace Parcial.WindowsForm.Conexion
{
    public class DataBarcos
    {
        static string conxionString;
        static SqlCommand command;
        static SqlConnection connection;
        static int id;
        public static void ModificarDB(Barco barcos)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE barcos SET costo = @costo ,estadoReparado = @estadoRepado, nombre = @nombre,operacion = @operacion , tripulacion = @tripulacion WHERE id = {barcos.Id}";
                command.Parameters.AddWithValue("@costo", barcos.Costo);
                command.Parameters.AddWithValue("@estadoReparado", barcos.EstadoReparado);
                command.Parameters.AddWithValue("@nombre", barcos.Nombre);
                command.Parameters.AddWithValue("@operacion", barcos.Operacion);
                command.Parameters.AddWithValue("@tripulacion", barcos.Tripulacion);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar la tabla barcos");
            }
            finally
            {
                connection.Close();
            }
        }


        public static void AgregarDB(Barco barcos)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO  barcos (costo,estadoReparado,nombre,operacion,tripulacion ) VALUES (@costo,@estadoRepado,@nombre,@operacion,@tripulacion)";
                command.Parameters.AddWithValue("@costo", barcos.Costo);
                command.Parameters.AddWithValue("@estadoReparado", barcos.EstadoReparado);
                command.Parameters.AddWithValue("@nombre", barcos.Nombre);
                command.Parameters.AddWithValue("@operacion", barcos.Operacion);
                command.Parameters.AddWithValue("@tripulacion", barcos.Tripulacion);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar la tabla barcos");
            }
            finally
            {
                connection.Close();
            }
        }

        public static void EliminarDB(int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM barcos WHRE ID_USUARIO = @id ";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la tabla VOLQUETE");
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Barco> LeerDB()
        {
            List<Barco> listaBarcos = new List<Barco>();
            Taller taller = new Taller();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "SELECT * FROM barcos ";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Barco aux = new Marina();

                    aux.Id = int.Parse(reader["id"].ToString());
                    aux.Costo = float.Parse(reader["costo"].ToString());
                    //aux.EstadoReparado =

                    //taller.IngresarBarco(aux);
                    aux.Id = int.Parse(reader["id"].ToString());
                    aux.Costo = float.Parse(reader["costo"].ToString());
                    aux.EstadoReparado = bool.Parse(reader["estadoReparado"].ToString());
                    aux.Nombre = reader["nombre"].ToString();
                    aux.Operacion = Enum.TryParse(reader["operacion"].ToString(), out EOperacion operacion) ? operacion : EOperacion.Default;
                    aux.Tripulacion = int.Parse(reader["tripulacion"].ToString());
                    listaBarcos.Add(aux);
                }

                return listaBarcos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al leer la tabla VOLQUETE ");
            }
            finally
            {
                connection.Close();
            }

        }


    }
}
