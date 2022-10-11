using FinAPP.Repository;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using FinAPP.Models;
using static NuGet.Packaging.PackagingConstants;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinAPP.Controllers
{
    public class AcfcController : Controller
    {
        private readonly ConnectionConfig _connectionConfig;

        

        public AcfcController( ConnectionConfig connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }


        public IActionResult Index()
        {

            DapperBase db = new(_connectionConfig.FinAppDB);
            using var connection = db.OpenConnection();


            string strSQL;
            strSQL = "SELECT * FROM Acfc ";
            var recordInfo = connection.Query<AcfcModel>(strSQL);



            return View(recordInfo);
        }

        [HttpPost]
        public IActionResult GetData(string version)
        {
            DapperBase db = new(_connectionConfig.FinAppDB);
            using var connection = db.OpenConnection();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Version", version);
            string strSQL;
            strSQL = "SELECT * FROM Acfc WHERE Version=@Version";
            var recordInfo = connection.Query<AcfcModel>(strSQL, parameters);
            return PartialView("_FinAppPartialView", recordInfo);
        }

       
    }
}
