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

        public Viatico CrearViatico(Viatico viaticoACrear)
        {
            Viatico viaticoCreado = null;
            string sql = "INSERT INTO T_PRESUPUESTO VALUES (@Co_Solicitud, @Fe_Solicitud, @Ss_TotalSolicitado,@Fl_Autorizado, @Co_EmpAutoriza, @Fe_Autorizado, @Fl_Aprobado, @Co_EmpAprueba, @Fe_Aprobado)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Solicitud", viaticoACrear.Co_Solicitud));
                    com.Parameters.Add(new SqlParameter("@Fe_Solicitud", viaticoACrear.Fe_Solicitud));
                    com.Parameters.Add(new SqlParameter("@Ss_TotalSolicitado", viaticoACrear.Ss_TotalSolicitado));
                    com.Parameters.Add(new SqlParameter("@Fl_Autorizado", viaticoACrear.Fl_Autorizado));
                    com.Parameters.Add(new SqlParameter("@Co_EmpAutoriza", viaticoACrear.Co_EmpAutoriza));
                    com.Parameters.Add(new SqlParameter("@Fe_Autorizado", viaticoACrear.Fe_Autorizado));
                    com.Parameters.Add(new SqlParameter("@Fl_Aprobado", viaticoACrear.Fl_Aprobado));
                    com.Parameters.Add(new SqlParameter("@Co_EmpAprueba", viaticoACrear.Co_EmpAprueba));
                    com.Parameters.Add(new SqlParameter("@Fe_Aprobado", viaticoACrear.Fe_Aprobado));                    
                    com.ExecuteNonQuery();
                }
            }

            viaticoCreado = viaticoACrear;
            return viaticoCreado;
        }

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
            string sql = "SELECT * FROM T_PRESUPUESTO WHERE Co_Area=@Co_Area";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@Co_Area", codigo));
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