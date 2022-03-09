using jQuery_AJAX_MVC;
using jQuery_AJAX_WebAPI_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace jQuery_AJAX_WebAPI_MVC.Controllers
{
    public class AjaxAPIController : ApiController
    {
        static EmpRepository repository = new EmpRepository();

        [System.Web.Http.Route("api/AjaxAPI/AjaxMethod")]
        [System.Web.Http.HttpPost]
        public string AjaxMethod(CarModel carModel)
        {
            List<CarModel> car = new List<CarModel>();

            //int RegistratonNo = int.Parse(formCollection["RegistratonNo"]);
            //string Reg_Date = formCollection["Reg_Date"];
            //string ModelNo = formCollection["ModelNo"];
            //string OwnerName = formCollection["OwnerName"];

            //CarModel carModel = new CarModel();
            //carModel.RegistratonNo = RegistratonNo;
            //carModel.Reg_Date = Reg_Date;
            //carModel.ModelNo = ModelNo;
            //carModel.OwnerName = OwnerName;

            car.Add(carModel);

            var response = repository.AddCarInformation(carModel);
            return response;
            //person.DateTime = DateTime.Now.ToString();
           // return car;
        }

        [System.Web.Http.Route("api/AjaxAPI/AjaxMethod")]
        [System.Web.Http.HttpGet]
        public List<CarModel> GetCarServiceInformation()
        {            
            var dsResponse = repository.GetAllCarInformation();

            var carList = dsResponse.Tables[0].AsEnumerable()
            .Select(dataRow => new CarModel
            {
                RegistratonNo = dataRow.Field<int>("RegistratonNo"),
                Reg_Date = dataRow.Field<string>("Reg_Date"),
                ModelNo = dataRow.Field<string>("ModelNo"),
                OwnerName = dataRow.Field<string>("OwnerName")
            }).ToList();
            
            return carList;       
        }
    }
}
