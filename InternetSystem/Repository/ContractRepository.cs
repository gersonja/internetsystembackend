using InternetSystem.DBModels;
using InternetSystem.Models;

namespace InternetSystem.Repository
{
    public class ContractRepository
    {
        private InternetsysContext _Context;
        public ContractRepository(InternetsysContext ctx)
        {
            _Context = ctx;
        }
        public List<Contract> GetContractsByClientId(int id)
        {
            var contractsFound = _Context.Contracts.Where(c => c.ClientClientid == id).ToList();
            return contractsFound;
        }

        public Contract? GetContract(int id)
        {
            var contractFound = _Context.Contracts.Where(x => x.Contractid == id).FirstOrDefault();

            return contractFound;
        }

        public Contract? CreateContract(ContractModelReq contract)
        {
            var ContractTemplate = new Contract()
            {
                Startdate = contract.Startdate,
                Enddate = contract.Enddate,
                ServiceServiceid = contract.ServiceServiceid,
                StatuscontractStatusid = contract.StatuscontractStatusid,
                ClientClientid = contract.ClientClientid,
                MethodpaymentMethodpaymentid = contract.MethodpaymentMethodpaymentid
            };

            try
            {
                _Context.Contracts.Add(ContractTemplate);
                _Context.SaveChanges();
                return ContractTemplate;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string? DeleteContractById(int id)
        {
            Contract contract = new Contract() { Contractid = id };
            try
            {
                _Context.Attach(contract);
                _Context.Remove(contract);
                _Context.SaveChanges();
                return "Removed contract succesfully";
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Contract? UpdateContract(int id, ContractModelReq ContractData)
        {
            try
            {
                var contractFoundById = _Context.Contracts.First(u => u.Contractid == id);
                contractFoundById.Startdate = ContractData.Startdate;
                contractFoundById.Enddate = ContractData.Enddate;
                contractFoundById.ServiceServiceid = ContractData.ServiceServiceid;
                contractFoundById.StatuscontractStatusid = ContractData.StatuscontractStatusid;
                contractFoundById.ClientClientid = ContractData.ClientClientid;
                contractFoundById.MethodpaymentMethodpaymentid = ContractData.MethodpaymentMethodpaymentid;

                _Context.SaveChanges();
                return contractFoundById;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
