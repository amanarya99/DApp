using System.Collections.Generic;
using DApp.API.Models;
using Newtonsoft.Json;

namespace DApp.API.Data
{
  public class Seed
  {
    private readonly DataContext _context;
    public Seed(DataContext context)
    {
      _context = context;

    }

    public void SeedUsers()
    {
      var UserData = System.IO.File.ReadAllText("Data/UserSeedData.json");
      var Users = JsonConvert.DeserializeObject<List<User>>(UserData);
      foreach (var user in Users)
      {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash("password", out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.Username = user.Username.ToLower();

        _context.Users.Add(user);
      }
      _context.SaveChanges();

    }


    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      //throw new NotImplementedException();
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

  }
}