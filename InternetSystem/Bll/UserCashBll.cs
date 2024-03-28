using InternetSystem.DBModels;
using InternetSystem.Models;
using InternetSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace InternetSystem.Bll
{
    public class UserCashBll
    {
        private InternetsysContext _Context;
        private readonly UserRepository UserR;
        private readonly CashRepository CashR;
        private readonly UserCashRepository UserCashR;
        private readonly InternetsysContext _db;

        public UserCashBll(InternetsysContext db)
        {
            _db = db;
            UserR = new UserRepository(_db);
            CashR = new CashRepository(_db);
            UserCashR = new UserCashRepository(_db);
        }
        public Usercash? CreateUserCash(UserCashModelReq userCash)
        {

            try
            {
                var userFingGestor = UserR.GetUser(userCash.Gestorid);
               
                if (userFingGestor != null &&  userFingGestor.RolRolid == 1)
                {
                    var userFind = UserR.GetUser(userCash.UserUserid);
                    var cashFind = CashR.GetCash(userCash.CashCashid);

                    if (userFind != null && cashFind != null)
                    {

                        var statusCash = cashFind.Active;
                        if (statusCash == "A")
                        {
                            
                            var userByCash = UserCashR.GetUserCash(userCash.UserUserid);
                            Console.WriteLine("everifique el usuario por caja");
                           
                            if (userByCash == null)
                            {


                                var cashByUserCount = UserCashR.GetCashContUser(userCash.CashCashid);
                                Console.WriteLine("everifique el la cantidad de cajas");
                                if (cashByUserCount < 3)
                                {
                                   
                                   
                                    Usercash UsercashCreated = UserCashR.CreatedUserCash(_db, userCash);
                                    Console.WriteLine(UsercashCreated);
                                    return UsercashCreated;

                                }
                                else
                                {
                                    return null;
                                }


                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }



                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _db.Database.RollbackTransaction();
                return null;
            }
        }
    
    }
}
