using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTTarifarioServices.Dominio;
using System.Data.SqlClient;

namespace RESTTarifarioServices.Persistencia
{
    public class TarifarioDAO
    {
        public Tarifario crear(Tarifario nuevoTarifario)
        {
            Tarifario tarifarioCreado = null;

            string sql = "INSERT INTO T_TARIFARIO VALUES (@Co_Tarifa, @Co_TipoViatico, @Co_Ubigeo, @Ss_Costo, Co_EmpActualiza)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Tarifa", nuevoTarifario.Co_Tarifa));
                    com.Parameters.Add(new SqlParameter("@Co_TipoViatico", nuevoTarifario.Co_TipoViatico));
                    com.Parameters.Add(new SqlParameter("@Co_Ubigeo", nuevoTarifario.Co_Ubigeo));
                    com.Parameters.Add(new SqlParameter("@Ss_Costo", nuevoTarifario.Ss_Costo));
                    com.Parameters.Add(new SqlParameter("@Co_EmpActualiza", nuevoTarifario.Co_EmpActualiza));
                    com.ExecuteNonQuery();
                }
            }

            tarifarioCreado = Obtener(nuevoTarifario.Co_Tarifa.ToString());
            return tarifarioCreado;
        }

        private Tarifario Obtener(string codigo)
        {
            Tarifario tarifarioEncontrado = null;
            string sql = "SELECT * FROM T_TARIFARIO WHERE Co_Tarifa=@Co_Tarifa";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Tarifa", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            tarifarioEncontrado = new Tarifario()
                            {
                                Co_Tarifa = int.Parse(resultado["Co_Tarifa"].ToString()),
                                Co_TipoViatico = int.Parse(resultado["Co_TipoViatico"].ToString()),
                                Co_Ubigeo = int.Parse(resultado["Co_Ubigeo"].ToString()),
                                Ss_Costo = Decimal.Parse(resultado["Ss_Costo"].ToString()),
                                Co_EmpActualiza = int.Parse(resultado["Co_EmpActualiza"].ToString())
                            };
                        }
                    }
                }
            }
            return tarifarioEncontrado;
        }

        public Tarifario Modificar(Tarifario tarifarioAModificar)
        {
            Tarifario tarifarioModificado = null;
            string sql = "UPDATE T_TARIFARIO SET Co_TipoViatico = @Co_TipoViatico, Ss_Costo = @Ss_Costo, Co_Ubigeo = @Co_Ubigeo, Co_EmpActualiza = @Co_EmpActualiza WHERE Co_Tarifa = @Co_Tarifa";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_TipoViatico", tarifarioAModificar.Co_TipoViatico));
                    com.Parameters.Add(new SqlParameter("@Co_Ubigeo", tarifarioAModificar.Co_Ubigeo));
                    com.Parameters.Add(new SqlParameter("@Ss_Costo", tarifarioAModificar.Ss_Costo));
                    com.Parameters.Add(new SqlParameter("@Co_EmpActualiza", tarifarioAModificar.Co_EmpActualiza));
                    com.ExecuteNonQuery();
                }
            }
            tarifarioModificado = Obtener(tarifarioAModificar.Co_Tarifa.ToString());
            return tarifarioModificado;
        }

        public void Eliminar(Tarifario presupuestoAEliminar)
        {
            string sql = "DELETE FROM T_TARIFARIO WHERE Co_Tarifa=@Co_Tarifa";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Tarifa", presupuestoAEliminar.Co_Tarifa));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Tarifario> ListarTodos()
        {
            List<Tarifario> tarifarios = new List<Tarifario>();
            Tarifario tarifario = null;
            string sql = "SELECT * FROM T_TARIFARIO";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            tarifario = new Tarifario()
                            {
                                Co_Tarifa = int.Parse(resultado["Co_Tarifa"].ToString()),
                                Co_TipoViatico = int.Parse(resultado["Co_TipoViatico"].ToString()),
                                Co_Ubigeo = int.Parse(resultado["Co_Ubigeo"].ToString()),
                                Ss_Costo = Decimal.Parse(resultado["Ss_Costo"].ToString()),
                                Co_EmpActualiza = int.Parse(resultado["Co_EmpActualiza"].ToString())
                            };
                            tarifarios.Add(tarifario);
                        }
                    }
                }
            }
            return tarifarios;
        }
    }
}