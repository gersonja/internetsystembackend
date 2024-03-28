
using InternetSystem.DBModels;
using InternetSystem.Models;

namespace InternetSystem.Repository
{
    public class UserCashRepository
    {
        private InternetsysContext _Context;
        public UserCashRepository(InternetsysContext ctx)
        {
            _Context = ctx;
        }
        public List<Usercash?> GetUsersCashes()
        {
            var listUserCash = _Context.Usercashes.ToList();
            return listUserCash;

            // no te deja crear nuevas plantillas?no desde el solution explorer no te deja agregar nueva plantilla? 
            //solo puedes agregar un archivo txt y carpetas que raro dejame probar en mi laptop dale
        }
        public Usercash? GetUserCash(int id)
        {
            var userCashFind = _Context.Usercashes.Where(x => x.UserUserid == id).FirstOrDefault();

            return userCashFind;
        }
        public int GetCashContUser(int id)
        {
            int cashByUser = _Context.Usercashes.Where(x => x.CashCashid == id)
                              .Count();

            return cashByUser;
        }
        public bool GetByUserCash(int userId, int cashId)
        {
            var userCashFind = _Context.Usercashes.Any(x => x.UserUserid == userId && x.CashCashid == cashId);

            return userCashFind;
        }
        public Usercash? GetUserGestorCash(int id)
        {
            var userGestorCashFind = _Context.Usercashes.Where(x => x.Gestorid == id).FirstOrDefault();

            return userGestorCashFind;
        }
        // se necesita el context para conectar a la bd, el modelo para insertar los datos
        public Usercash CreatedUserCash(InternetsysContext Context, UserCashModelReq userCash)
        {

            try
            {
                Usercash Usercash = new Usercash
                {
                    UserUserid = userCash.UserUserid,
                    CashCashid = userCash.CashCashid,
                    Gestorid = userCash.Gestorid,

                };
              
                Context.Usercashes.Add(Usercash);
                Context.SaveChanges();

                return Usercash;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
              
                return null;
            }
        }

        public bool? DeleteUserCash(int userId, int cashId)
        {
            
            
            try
            {
                Usercash userCashFind = _Context.Usercashes.FirstOrDefault(x => x.UserUserid == userId && x.CashCashid == cashId);
                
                if (userCashFind != null)
                {
                    _Context.Attach(userCashFind);
                    _Context.Remove(userCashFind);
                    _Context.SaveChanges();
                    Console.WriteLine("ENTRE EN TRUE");
                    return true;
                }
                else
                {
                    return false;
                    Console.WriteLine("ENTRE EN FALSE");
                }
               
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}



