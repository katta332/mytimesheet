using System;
using System.Linq;
using System.Collections.Generic;
namespace AngularProject.Models
{
    public class MockUserDetailsRepository: IUserDetailsRepository
    {
        private List<UserDetails> _userDetailsList;
        private readonly AppDBContext context;
        public MockUserDetailsRepository(AppDBContext context)
        {
            this.context = context;
            _userDetailsList = new List<UserDetails>
            {
                new UserDetails(){Id=1, email="test1@gmail.com", firstname="test1first", lastname="test1last", middlename="", Username="test1username"},
                new UserDetails(){Id=2, email="test2@gmail.com", firstname="test2first", lastname="test2last", middlename="", Username="test2username"},
                new UserDetails(){Id=3, email="test3@gmail.com", firstname="test3first", lastname="test3last", middlename="", Username="test3username"},
                new UserDetails(){Id=4, email="test4@gmail.com", firstname="test4first", lastname="test4last", middlename="", Username="test4username"}
            };
        }

        public UserDetails Add(UserDetails userDetails)
        {
            
            userDetails.Id = context.UserDetails.Count()+1;
            context.UserDetails.Add(userDetails);
            context.SaveChanges();
            return userDetails;
        }
        public UserDetails Delete(string username)
        {
            UserDetails user = context.UserDetails.FirstOrDefault(e=>e.Username.ToUpper()==username.ToUpper());
            if (user != null)
            {
                context.UserDetails.Remove(user);
                context.SaveChanges();
            }
            return user;
        }
        public IEnumerable<UserDetails> GetAllUserDetails()
        {
            return context.UserDetails;
        }

        public UserDetails GetUserDetails(string username)
        {
            UserDetails user =  context.UserDetails.FirstOrDefault(t => t.Username.ToUpper() == username.ToUpper());
            return user;
        }
        public UserDetails Update(UserDetails userDetails)
        {
            UserDetails user = context.UserDetails.FirstOrDefault(e => e.Id == userDetails.Id);
            if (user != null)
            {
                user.Username = userDetails.Username;
                user.email = userDetails.email;
                user.firstname = userDetails.firstname;
                user.lastname = userDetails.lastname;
                user.middlename = userDetails.middlename;
            }
            var updatedUser = context.UserDetails.Attach(user);
            updatedUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return user;
        }
    }
}
