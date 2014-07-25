using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTServices.Dominio;
using System.Data.SqlClient;

namespace RESTServices.Persistencia
{
    public class PresupuestoDAO
    {
        public Presupuesto Crear(Presupuesto presupuestoACrear)
        {
            Presupuesto presupuestoCreado = null;
            string sql = "INSERT INTO T_PRESUPUESTO VALUES (@Co_Presupuesto, @Co_Area, @Ss_MontoAsignado, @Ss_MontoDisponible)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Presupuesto", presupuestoACrear.Co_Presupuesto));
                    com.Parameters.Add(new SqlParameter("@Co_Area", presupuestoACrear.Co_Area));
                    com.Parameters.Add(new SqlParameter("@Ss_MontoAsignado", presupuestoACrear.Ss_MontoAsignado));
                    com.Parameters.Add(new SqlParameter("@Ss_MontoDisponible", presupuestoACrear.Ss_MontoDisponible));
                    com.ExecuteNonQuery();
                }
            }
            
            presupuestoCreado = Obtener(presupuestoACrear.Co_Presupuesto.ToString());
            return presupuestoCreado;
        }

        public Presupuesto Modificar(Presupuesto presupuestoAModificar)
        {
            Presupuesto presupuestoModificado = null;
            string sql = "UPDATE T_PRESUPUESTO SET Co_Area = @Co_Area, Ss_MontoAsignado = @Ss_MontoAsignado, Ss_MontoDisponible = @Ss_MontoDisponible WHERE Co_Presupuesto = @Co_Presupuesto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Area", presupuestoAModificar.Co_Area));
                    com.Parameters.Add(new SqlParameter("@Ss_MontoAsignado", presupuestoAModificar.Ss_MontoAsignado));
                    com.Parameters.Add(new SqlParameter("@Ss_MontoDisponible", presupuestoAModificar.Ss_MontoDisponible));
                    com.Parameters.Add(new SqlParameter("@Co_Presupuesto", presupuestoAModificar.Co_Presupuesto));
                    com.ExecuteNonQuery();
                }
            }
            presupuestoModificado = Obtener(presupuestoAModificar.Co_Presupuesto.ToString());
            return presupuestoModificado;
        }

        public Presupuesto Obtener(String codigo)
        {
            Presupuesto presupuestoEncontrado = null;
            string sql = "SELECT * FROM T_PRESUPUESTO WHERE Co_Presupuesto=@Co_Presupuesto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Presupuesto", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            presupuestoEncontrado = new Presupuesto()
                            {
                                Co_Presupuesto = int.Parse(resultado["Co_Presupuesto"].ToString()),
                                Co_Area = int.Parse(resultado["Co_Area"].ToString()),
                                Ss_MontoAsignado = Double.Parse(resultado["Ss_MontoAsignado"].ToString()),
                                Ss_MontoDisponible = Double.Parse(resultado["Ss_MontoDisponible"].ToString())
                            };
                        }
                    }
                }
            }
            return presupuestoEncontrado;
        }

        public void Eliminar(Presupuesto presupuestoAEliminar)
        {
            string sql = "DELETE FROM T_PRESUPUESTO WHERE Co_Presupuesto=@Co_Presupuesto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Presupuesto", presupuestoAEliminar.Co_Presupuesto));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Presupuesto> ListarTodos()
        {
            List<Presupuesto> presupuestosEncontrados = new List<Presupuesto>();
            Presupuesto presupuestoEncontrado = null;
            string sql = "SELECT * FROM T_PRESUPUESTO";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            presupuestoEncontrado = new Presupuesto()
                            {
                                Co_Presupuesto = int.Parse(resultado["Co_Presupuesto"].ToString()),
                                Co_Area = int.Parse(resultado["Co_Area"].ToString()),
                                Ss_MontoAsignado = Double.Parse(resultado["Ss_MontoAsignado"].ToString()),
                                Ss_MontoDisponible = Double.Parse(resultado["Ss_MontoDisponible"].ToString())
                            };
                            presupuestosEncontrados.Add(presupuestoEncontrado);
                        }
                    }
                }
            }
            return presupuestosEncontrados;
        }

    }

}