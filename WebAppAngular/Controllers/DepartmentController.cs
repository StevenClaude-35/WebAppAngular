﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppAngular.Models;

namespace WebAppAngular.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select DepartmentId,DepartmentName from dbo.Department";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeData"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
                using(var da=new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Department dep)
        {
            try
            {
                string query = @"insert into dbo.Department values('" + dep.DepartmentName + @"')";

                DataTable table = new DataTable();
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeData"].ConnectionString))
                    using(var cmd=new SqlCommand(query,con))
                    using(var da=new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successully!";
            }
            catch (Exception)
            {

                return "Failed Added";
            }
        }
        public string Put(Department dep)
        {
            try
            {
                string query = @"update dbo.Department set DepartmentName='" + dep.DepartmentName + @"' where DepartmentId=" + dep.DepartmentId + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeData"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Update Successully!";
            }
            catch (Exception)
            {

                return "Failed Update";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Department where DepartmentId=" + id + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeData"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "deleted Successully!";
            }
            catch (Exception)
            {

                return "Failed Deleted";
            }
        }
    }
}
