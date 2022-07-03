using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiHttpVerbs.Entities;

namespace FirstWebApiProject.Controllers
{
    
        [ApiController]
        [Route("[controller]/[Action]")]
        public class EmployeeEducationController : Controller
        {
            private ILogger<EmployeeEducationController> _logger;

            public EmployeeEducationController(ILogger<EmployeeEducationController> logger)
            {
                _logger = logger;
            }
        public static List<EmployeeEducation> employeeEducations = new List<EmployeeEducation>();

        #region pass-parameters-using-uri
        [HttpPost]
        
        public ActionResult AddEmployeeEduFromUri([System.Web.Http.FromUri] int Id, [System.Web.Http.FromUri] string CourseName, [System.Web.Http.FromUri] string UniName, [System.Web.Http.FromUri] int MarksPercentage, [System.Web.Http.FromUri] int EmpId)
        {
            employeeEducations.Add(new EmployeeEducation { Id = Id, CourseName = CourseName, UniName = UniName, MarksPercentage = MarksPercentage, EmpId = EmpId });
            var serializedOp = JsonConvert.SerializeObject(employeeEducations[employeeEducations.Count - 1]);
            
            return Ok($"{serializedOp} added in the employeeEduList");
        }
        [HttpGet]
        public ActionResult GetEduListOfAEmployeeFromUri([System.Web.Http.FromUri] int EmpId)
        {

            var empEduList = employeeEducations.Where(e => e.Id == EmpId).ToList();
            if (empEduList.Count > 0)
            {
                var serializedOp = JsonConvert.SerializeObject(empEduList);
                return Ok($"{serializedOp}");
            }
            else
            {
                return Ok($"EmpID: {EmpId} does not have any education details.");
            }


        }
        [HttpPut]
        public ActionResult UpdatedEmployeeEduDetails([System.Web.Http.FromUri] int Id, [System.Web.Http.FromUri] string CourseName, [System.Web.Http.FromUri] string UniName, [System.Web.Http.FromUri] int MarksPercentage, [System.Web.Http.FromUri] int EmpId)
        {
            var emp = employeeEducations.Where(emp => emp.Id == Id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.CourseName = CourseName;
                emp.UniName = UniName;
                emp.MarksPercentage = MarksPercentage;
                emp.EmpId = EmpId;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }


        }
        [HttpPatch]
        public ActionResult UpdateOnlyMarksPercentagefieldField([System.Web.Http.FromUri] int Id, [System.Web.Http.FromUri] int updatedMarksPercentage)
        {
            var emp = employeeEducations.Where(emp => emp.Id == Id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.MarksPercentage = updatedMarksPercentage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }
        }
        [HttpDelete]
        public ActionResult DateteAEmployee([System.Web.Http.FromUri] int EmpEduId)
        {
            var deleteEmployee = employeeEducations.Where(obj => obj.Id == EmpEduId).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employeeEducations.Remove(deleteEmployee);

                return Ok($"EmpId: {EmpEduId} removed from employee edu list.");
            }
            else
            {
                return Ok($"EmpId: {EmpEduId} not found");
            }

        }
        #endregion

        #region pass-params-in-body

        [HttpPost]
        public ActionResult AddEmployeeEduFromBody([System.Web.Http.FromBody] EmployeeEducation employeeEducation)
        {
            employeeEducations.Add(new EmployeeEducation { Id = employeeEducation.Id, CourseName = employeeEducation.CourseName, UniName = employeeEducation.UniName, MarksPercentage = employeeEducation.MarksPercentage, EmpId = employeeEducation.EmpId });
            var serializedOp = JsonConvert.SerializeObject(employeeEducations[employeeEducations.Count - 1]);
            return Ok($"{serializedOp} added in the employeeEduList");
        }
        [HttpGet]
        public ActionResult GetEduListOfAEmployeeInfoFromBody([System.Web.Http.FromBody] int EmpId)
        {

            var empEduList = employeeEducations.Where(e => e.Id == EmpId).ToList();
            var serializedOp = JsonConvert.SerializeObject(empEduList);
            return Ok($"{serializedOp}");

        }
        [HttpPut]
        public ActionResult UpdatedEmployeeEduDetailsFromBody([System.Web.Http.FromBody] EmployeeEducation employeeEducation)
        {
            var emp = employeeEducations.Where(emp => emp.Id == employeeEducation.Id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.CourseName = employeeEducation.CourseName;
                emp.UniName = employeeEducation.UniName;
                emp.MarksPercentage = employeeEducation.MarksPercentage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }


        }
        [HttpPatch]
        public ActionResult UpdateOnlyMarksPercantageFieldFromBody([System.Web.Http.FromBody] int Id, [System.Web.Http.FromBody] int updatedPercantage)
        {
            var emp = employeeEducations.Where(emp => emp.Id == Id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.MarksPercentage = updatedPercantage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }
        }

        [HttpDelete]
        public ActionResult DateteAEmployeeFromBody([System.Web.Http.FromBody] int Id)
        {
            var deleteEmployee = employeeEducations.Where(obj => obj.Id == Id).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employeeEducations.Remove(deleteEmployee);

                return Ok($"EmpId: {Id} removed from employee edu list.");
            }
            else
            {
                return Ok($"EmpId: {Id} not found");
            }

        }
        #endregion
    }
}









