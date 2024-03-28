namespace InternetSystem.Models
{
    public class ContractModelReq
    {
        public DateTime Startdate { get; set; }

        public DateTime Enddate { get; set; }

        public int ServiceServiceid { get; set; }

        public string StatuscontractStatusid { get; set; } = null!;

        public int ClientClientid { get; set; }

        public int MethodpaymentMethodpaymentid { get; set; }

    }
}