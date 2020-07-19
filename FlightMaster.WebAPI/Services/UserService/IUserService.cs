using AutoMapper;
using FlightMaster.Model.MobileModel;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database.ClassModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.UserService
{
    public interface IUserService
    {
        Model.User Authenticate(string username, string password);
        public Model.User RegisterEmployee(EmployeRegisterModel model);
        public Model.User RegisterUser(UserRegistrationModel model);
        List<Model.User> Test();
        bool UpdateUserCity(UserCityUpdateModel data);
        List<Model.TicketPreferences> GetUserTicketPreferences(int userId);
        bool SetUserTicketPreferences(List<Model.TicketPreferences> ticketPreferences);
        List<Model.LuxuryPreferences> GetUserLuxuriesPreferences(int userId);
        bool SetUserLuxuriesPreferences(List<Model.LuxuryPreferences> luxuryPreferences);
        bool UserNameExsists(string userName);
    }

    public class UserService : IUserService
    {


        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

     

        public UserService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public Model.User Authenticate(string username, string password)
        {

            var users = db.Users.Where(x => x.Username == username).ToList();


            if (users.Count == 0) 
                return null;


            foreach (var user in users)
            {



                var newHash = GenerateHash(user.PasswordSalt, password);


                if (newHash == user.PasswordHash)
                {

                    var secret = "THIS IS Ughjgjhgjhghgighiizgzigiz";

                    // authentication successful so generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                  //  new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                        }),
                        Expires = DateTime.UtcNow.AddHours(12),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    user.Token = tokenHandler.WriteToken(token);

                    db.Update(user);
                    db.SaveChanges();





                    return mapper.Map<Model.User>(user);
                }


            }




            return null;


        }


        public List<Model.User> Test()
        {
            return mapper.Map<List<Model.User>>(db.Users.ToList());
        }


        public Model.User RegisterUser(UserRegistrationModel model)
        {
            Database.ClassModels.User NewUser = new Database.ClassModels.User()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Picture = model.Picture,
                Role = Role.User

            };




            NewUser.PasswordSalt = GenerateSalt();
            NewUser.PasswordHash = GenerateHash(NewUser.PasswordSalt, model.Password);

            db.Users.Add(NewUser);
            db.SaveChanges();


            var secret = "THIS IS Ughjgjhgjhghgighiizgzigiz";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, NewUser.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            NewUser.Token = tokenHandler.WriteToken(token);

            db.Users.Update(NewUser);
            db.SaveChanges();



            return mapper.Map<Model.User>(NewUser);
        }
        public Model.User RegisterEmployee(EmployeRegisterModel model)
        {

            Database.ClassModels.User NewEmployee = new Database.ClassModels.User()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.UserName,
                Picture = model.Picture,
                Role = Role.Employe

            };




            NewEmployee.PasswordSalt = GenerateSalt();
            NewEmployee.PasswordHash = GenerateHash(NewEmployee.PasswordSalt, model.Password);

            db.Users.Add(NewEmployee);
            db.SaveChanges();


            var secret = "THIS IS Ughjgjhgjhghgighiizgzigiz";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, NewEmployee.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            NewEmployee.Token = tokenHandler.WriteToken(token);

            db.Users.Update(NewEmployee);
            db.SaveChanges();



            return mapper.Map<Model.User>(NewEmployee);
        }




        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public bool UpdateUserCity(UserCityUpdateModel data)
        {
            Database.ClassModels.User user = db.Users.SingleOrDefault(x => x.Id == data.UserId);

            if (user == null)
                return false;

            user.CityId = data.CityId;
            db.Users.Update(user);
            db.SaveChanges();


            return true;
        }

       
        public List<Model.TicketPreferences> GetUserTicketPreferences(int userId)
        {

            var data = db.TicketPreferences.Where(x => x.CustomerId == userId).ToList();

            return mapper.Map<List<Model.TicketPreferences>>(data);

        }

        public bool SetUserTicketPreferences(List<Model.TicketPreferences> ticketPreferences)
        {


            foreach (var item in ticketPreferences)
            {

                Database.ClassModels.TicketPreferences Olddata = db.TicketPreferences.SingleOrDefault(x => x.CustomerId == item.CustomerId && x.TicketTypeId == item.TicketTypeId);

                if (Olddata != null)
                {
                    Olddata.Rating = item.Rating;
                    db.TicketPreferences.Update(Olddata);
                    db.SaveChanges();
                }
                else
                {
                    Database.ClassModels.TicketPreferences NewEntry = new Database.ClassModels.TicketPreferences() { CustomerId = item.CustomerId, TicketTypeId = item.TicketTypeId, Rating = item.Rating };
                    db.TicketPreferences.Add(NewEntry);
                    db.SaveChanges();
                }
                
            }

            return true;

        }

        public List<Model.LuxuryPreferences> GetUserLuxuriesPreferences(int userId)
        {
            var data = db.LuxuryPreferences.Where(x => x.CustomerId == userId).ToList();

            return mapper.Map<List<Model.LuxuryPreferences>>(data);
        }

        public bool SetUserLuxuriesPreferences(List<Model.LuxuryPreferences> luxuryPreferences)
        {

            foreach (var item in luxuryPreferences)
            {

                Database.ClassModels.LuxuryPreferences Olddata = db.LuxuryPreferences.SingleOrDefault(x => x.CustomerId == item.CustomerId && x.LuxuriesId == item.LuxuriesId);

                if (Olddata != null)
                {
                    Olddata.Rating = item.Rating;
                    db.LuxuryPreferences.Update(Olddata);
                    db.SaveChanges();
                }
                else
                {
                    Database.ClassModels.LuxuryPreferences NewEntry = new Database.ClassModels.LuxuryPreferences() { CustomerId = item.CustomerId, LuxuriesId = item.LuxuriesId, Rating = item.Rating };
                    db.LuxuryPreferences.Add(NewEntry);
                    db.SaveChanges();
                }

            }

            return true;
        }

        public bool UserNameExsists(string userName)
        {

            User exsists = db.Users.SingleOrDefault(x => x.Username == userName);
            if (exsists == null)
                return false;
            return true;
        }
    }
}
