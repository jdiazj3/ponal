using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AngualarCrudeOperation.Models;

namespace AngualarCrudeOperation.database_Acces_Layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        // Add Record
        public void Add_record(register rs)
        {
            SqlCommand com = new SqlCommand("Sp_register", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email", rs.Email);
            com.Parameters.AddWithValue("@Password", rs.Password);
            com.Parameters.AddWithValue("@Name", rs.Name);
            com.Parameters.AddWithValue("@Address", rs.Address);
            com.Parameters.AddWithValue("@City", rs.City);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
		
		public void Add_recordTurno(turnos rs)
        {
            SqlCommand com = new SqlCommand("Sp_turnos", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@id", rs.id); autoincrement
            com.Parameters.AddWithValue("@consecutivo", rs.consecutivo);
            com.Parameters.AddWithValue("@fecha", rs.Fecha);
            com.Parameters.AddWithValue("@hora", rs.hora);
            com.Parameters.AddWithValue("@idOficina", rs.idOficina);
			com.Parameters.AddWithValue("@idTipo", rs.idTipo);
			com.Parameters.AddWithValue("@nombres", rs.nombres);
			com.Parameters.AddWithValue("@apellidos", rs.apellidos);
			com.Parameters.AddWithValue("@idEstado", rs.idEstado);
					
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        //Display all record
        public DataSet get_record()
        {
            SqlCommand com = new SqlCommand("Sp_register_get", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
		
		public DataSet get_recordTurno()
        {
            SqlCommand com = new SqlCommand("Sp_turnos_get", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        // Update all record
        public void update_record(register rs)
        {
            SqlCommand com = new SqlCommand("Sp_register_Update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email", rs.Email);
            com.Parameters.AddWithValue("@Password", rs.Password);
            com.Parameters.AddWithValue("@Name", rs.Name);
            com.Parameters.AddWithValue("@Address", rs.Address);
            com.Parameters.AddWithValue("@City", rs.City);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
		
		// Update all record turnos
        public void update_recordTurnos(turnos rs)
        {
            SqlCommand com = new SqlCommand("Sp_register_Update", con);
            com.CommandType = CommandType.StoredProcedure;
			//com.Parameters.AddWithValue("@id", rs.id);
            com.Parameters.AddWithValue("@consecutivo", rs.consecutivo);
            com.Parameters.AddWithValue("@fecha", rs.Fecha);
            com.Parameters.AddWithValue("@hora", rs.hora);
            com.Parameters.AddWithValue("@idOficina", rs.idOficina);
			com.Parameters.AddWithValue("@idTipo", rs.idTipo);
			com.Parameters.AddWithValue("@nombres", rs.nombres);
			com.Parameters.AddWithValue("@apellidos", rs.apellidos);
			com.Parameters.AddWithValue("@idEstado", rs.idEstado);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        // Get Record by id
        public DataSet get_recordbyid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_byid", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Sr_no", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
		
		public DataSet get_recordTurnobyid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_Turnos_byid", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        // Delete record
		
		 public void deletedata(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Sr_no", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        } 
        public void deletedataTurno(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_Turnos_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}