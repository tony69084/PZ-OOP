﻿

namespace Web_Service.Models
{
    public class WorkingHoursWinter
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public string Hours{ get; set; }

        public System.Collections.Generic.List<FootballFieldInfo> FootballFieldInfo { get; set; } = new System.Collections.Generic.List<FootballFieldInfo>();
    }
}