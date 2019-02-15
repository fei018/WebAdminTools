using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AdminToolsModel.CSPCall;
using PagedList;

namespace AdminToolsViewModel.CSPCall
{
    #region CSPCallDetailsViewModel
    public class CSPCallDetailsViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public string Location { get; set; }

        public string ContactPerson { get; set; }

        //public string RequestType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Symptom { get; set; }

        public string ScheduleTime { get; set; }

        public string ServeTime1 { get; set; }

        public string ServeTime2 { get; set; }

        [DataType(DataType.MultilineText)]
        public string ServiceDescription { get; set; }

        public void SetAllProperty(CSPCallDetails call)
        {
            this.Company = call.Company;
            this.ContactPerson = call.ContactPerson;
            this.Id = call.Id;
            this.Location = call.Location;
            this.ScheduleTime = call.ScheduleTime;
            this.ServeTime1 = call.ServeTime1;
            this.ServeTime2 = call.ServeTime2;
            this.ServiceDescription = call.ServiceDescription;
            this.Symptom = call.Symptom;
        }
    }
    #endregion

    #region CSPCallPagedListViewModel
    public class CSPCallPagedListViewModel : BaseViewModel
    {
        public IPagedList<CSPCallDetails> PagedList { get; set; }
    }
    #endregion

    #region CSPCallSetViewModel
    public class CSPCallSetViewModel:BaseViewModel
    {
        public string LoginName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Assignto { get; set; }

        [DataType(DataType.Date)]
        public string StartDate { get; set; }

        [DataType(DataType.Date)]
        public string EndDate { get; set; }
       
        public string DayCalls { get; set; }
    } 
    #endregion
}