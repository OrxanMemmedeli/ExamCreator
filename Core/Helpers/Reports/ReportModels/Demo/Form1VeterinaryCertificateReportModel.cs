using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.Reports.ReportModels.Demo
{
    public class Form1VeterinaryCertificateReportModel
    {
        public Guid Id { get; set; }
        public string RegionalSectionName { get; set; } // Regional bolme
        public DateTime? PrintDate { get; set; } // Cap ede bilme vaxti
        public string QRUrl { get; set; } // 

        public String Description { get; set; }
        public String HealthPeriodMonth { get; set; }
        public String HealthPeriodYear { get; set; }
        public String ExistencPeriod { get; set; }
        public String KeepinQuarantineInfo { get; set; }

        public string UnicalNumber { get; set; }
        public string RequestNumber { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public String FullName { get; set; }
        public string IdentityOrPinCode { get; set; }
        //public string PinCode { get; set; }
        public String Adress { get; set; }

        public DateTime? GeneratedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }

        public string InspectorName { get; set; } //notMapped
        //public string UserName { get; set; }
        public TransportationReportModel Transportation { get; set; }

        public List<ProductInfoReportModel> ProductInfos { get; set; }
        public List<RouteInfoReportModel> RouteInfos { get; set; }
        public List<ActItemItem> Items { get; set; }
    }

    public class TransportationReportModel : BaseOrderModel
    {
        public String DN_TransportType { get; set; }
        public String TransportNumber { get; set; }
        public String TrailerNumber { get; set; }
    }

    public class ActItemItem : BaseOrderModel
    {
        public String DiseaseName { get; set; }
        public DateTime? CheckupStartDate { get; set; }
        public DateTime? CheckupEndDate { get; set; }
        public String LaboratoryName { get; set; }
        public String CheckupMethod { get; set; }
        public String CheckupResult { get; set; }
    }

    public class ProductInfoReportModel : BaseOrderModel
    {
        public String TagNumber { get; set; } // birka 
        public String CertificateNumber { get; set; } //sehadetname
        public String AnimalType { get; set; } //cins
        public String AnimalKind { get; set; } //nov
        public String Gender { get; set; } // cinsiyyet
        public decimal? Age { get; set; } // yasi
        public String OriginCountry { get; set; } // mense
        public decimal? AnimalCount { get; set; } // bas sayi
        public DateTime? VaccinationDate { get; set; } = null; //
        public DateTime? AgainstParasitesDate { get; set; } = null; //
    }

    public class RouteInfoReportModel : BaseOrderModel
    {
        public string ExitRegion { get; set; }
        public string ExitCity { get; set; }
        public string ReachRegion { get; set; }
        public string ReachCity { get; set; }


        public String FullName { get; set; } // qebul eden 
        public decimal? AnimalCount { get; set; } //bas sayi
        public string AnimalType { get; set; } // novleri
        public string ProductDesignation { get; set; } //İstifadə təyinatı
    }

    public class BaseOrderModel
    {
        public int Order { get; set; }
    }
}
