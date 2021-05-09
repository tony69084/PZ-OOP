
namespace Web_Service.Models
{
    public class FootballFieldInfo
    {
        public int Id { get; set; }

        public string ObjectName { get; set; }
        public string AdmArea { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string HelpPhone { get; set; }
        public System.Collections.Generic.List<WorkingHoursWinter> WorkingHoursWinter { get; set; } = new System.Collections.Generic.List<WorkingHoursWinter>();
        public string HasEquipmentRental { get; set; }
        public string HasTechService { get; set; }
        public string HasDressingRoom { get; set; }
        public string HasEatery { get; set; }
        public string HasToilet { get; set; }
        public string HasWifi { get; set; }
        public string HasCashMachine { get; set; }
        public string HasFirstAidPost { get; set; }
        public string HasMusic { get; set; }
        public string Lighting { get; set; }
        public string SurfaceTypeWinter { get; set; }
        public string Seats { get; set; }
        public string Paid { get; set; }
        public string DisabilityFriendly { get; set; }
     
    }
}