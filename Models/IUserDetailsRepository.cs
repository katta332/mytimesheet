using System;
using System.Collections.Generic;
namespace AngularProject.Models
{
    public interface IUserDetailsRepository
    {
            UserDetails GetUserDetails(string username);
            IEnumerable<UserDetails> GetAllUserDetails();
            UserDetails Add(UserDetails userdetails);
            UserDetails Update(UserDetails userDetails);
            UserDetails Delete(string username);
    }
}
