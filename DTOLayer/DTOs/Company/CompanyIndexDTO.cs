namespace DTOLayer.DTOs.Company
{
    public class CompanyIndexDTO : DTOLayer.DTOs.BaseFields.BaseFields
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? BlockedDate { get; set; }
        public decimal DailyAmount { get; set; }  // günlük məbləğ AZN
        public decimal DebtLimit { get; set; } // maksimal borc limiti
        public decimal PersentOfFine { get; set; } // limit aşıldıqda məbləğə artım faizi AZN

        public bool IsFree { get; set; }
        public bool IsPenal { get; set; }
    }
}
