using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Data.SqlClient; 


namespace newProject01.Models
{
    public class Card
    {

        [DisplayName("待做事項")]
        public string Name { get; set; }
        [DisplayName("事項狀態")]
        public string Schedule { get;set; }
        [DisplayName("新增時間")]
        public string Date { get; set; }
    }

}