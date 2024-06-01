using BlazorWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorWebApp.Services
{
    public class ApplicationState
    {
        private List<User> users = new List<User>();

        public List<User> Users
        {
            get => users;
            set => users = value;
        }

        public User GetUserById(int userId)
        {
            return users.FirstOrDefault(u => u.Id == userId);
        }

        public void AddUser(User user)
        {
            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
        }

        public void UpdateUser(User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.PhoneNumber = updatedUser.PhoneNumber;
                user.Experience = updatedUser.Experience;
                user.Skills = updatedUser.Skills;
            }
        }

        public void DeleteUser(int userId)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                users.Remove(user);
            }
        }
    }
}
