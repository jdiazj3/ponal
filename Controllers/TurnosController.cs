using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngualarCrudeOperation.Models;
using System.Data;
namespace AngualarCrudeOperation.Controllers
{
    public class TurnosController : Controller
    {
        //
        // GET: /Home/
        database_Acces_Layer.db dblayer = new database_Acces_Layer.db();
        // View for Add record
        public ActionResult Index()
        {
            return View();
        }
        // View for Display record
        public ActionResult Show_data()
        {
            return View();
        }
        // View for Update record
        public ActionResult update_data(int id)
        {
            return View();
        }
        //Add record
        public JsonResult Add_record(turnos rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        // Display all records
        public JsonResult Get_data()
        {
            DataSet ds = dblayer.get_record();
            List<turnos> listrs = new List<turnos>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new turnos
                {
                    id = Convert.ToInt32(dr["ID"]),
                    consecutivo = dr["Consecutivo"].ToString(),
                    fecha = dr["Fecha"].ToString(),
                    hora = dr["hora"].ToString(),
					idOficina = Convert.ToInt32(dr["idOficina"]),
					idTipo = Convert.ToInt32(dr["idTipo"]),
                    num_documento = dr["num documento"].ToString(),
                    nombres = dr["nombres"].ToString(),
					apellidos = dr["apellidos"].ToString(),
					idEstado = Convert.ToInt32(dr["idEstado"])
					
					
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        // Display records by id
		
        public JsonResult Get_databyid(int id)
        {
            DataSet ds = dblayer.get_recordbyid(id);
            List<turnos> listrs = new List<turnos>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new turnos
                {
                    id = Convert.ToInt32(dr["ID"]),
                    consecutivo = dr["Consecutivo"].ToString(),
                    fecha = dr["Fecha"].ToString(),
                    hora = dr["hora"].ToString(),
					idOficina = Convert.ToInt32(dr["idOficina"]),
					idTipo = Convert.ToInt32(dr["idTipo"]),
                    num_documento = dr["num documento"].ToString(),
                    nombres = dr["nombres"].ToString(),
					apellidos = dr["apellidos"].ToString(),
					idEstado = Convert.ToInt32(dr["idEstado"])
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
       // Update records 
        public JsonResult update_record(turnos rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.update_record(rs);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        // Delete record
        public JsonResult delete_record(int id)
        {
            string res = string.Empty;
            try
            {
                dblayer.deletedata(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }
       

    }
}
