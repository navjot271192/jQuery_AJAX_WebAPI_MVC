using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jQuery_AJAX_WebAPI_MVC.Models
{
    public class CarModel
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Reg_Date { get; set; }

        public string ModelNo { get; set; }

        public string OwnerName { get; set; }

        public int RegistratonNo { get; set; }

        /// <summary>
        /// Gets or sets DateTime.
        /// </summary>
        public string DateTime { get; set; }
    }
}