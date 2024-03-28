using InternetSystem.DBModels;
using InternetSystem.Models;

namespace InternetSystem.Repository
{
    public class UserRepository
    {
        private InternetsysContext _Context;
        public UserRepository(InternetsysContext ctx)
        {
            _Context = ctx;
        }
        public List<User> GetUsers()
        {
            var usersFound = _Context.Users.ToList();
            return usersFound;
        }

        public User? GetUser(int id)
        {
            var userFound = _Context.Users.Where(x => x.Userid == id).FirstOrDefault();
            
            return userFound;
        }

        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            var userFound = _Context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            
            return userFound;
        }

        public User? CreateUser(UserModelReq user)
        {
            var UserTemplate = new User()
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                RolRolid = user.RolRolid,
                Creationdate = DateTime.Now,
                UserstatusStatusid = "ACT"
            };

            try
            {
                _Context.Users.Add(UserTemplate);
                _Context.SaveChanges();
                return UserTemplate;
            } catch (Exception)
            {
                return null;
            }
        }
        public string? DeleteUserById(int id)
        {
            User user = new User() { Userid = id };
            try
            {
                _Context.Attach(user);
                _Context.Remove(user);
                _Context.SaveChanges();
                return "Removed user succesfully";
            } catch (Exception)
            {
                return null;
            }
        }
        public User? UpdateUser(int id, UserModelReq UserData)
        {
            try
            {
                var userFoundById = _Context.Users.First(u => u.Userid == id);
                userFoundById.Username = UserData.Username;
                userFoundById.Email = UserData.Email;
                userFoundById.Password = UserData.Password;
                userFoundById.RolRolid = UserData.RolRolid;
                userFoundById.UserstatusStatusid = UserData.UserstatusStatusid;
                _Context.SaveChanges();
                return userFoundById;
            } catch (Exception)
            {
                return null;
            }   
        }
    }
}
