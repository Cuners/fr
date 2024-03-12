using Microsoft.AspNetCore.Mvc.Localization;
using fr.Models;

namespace fr.MyData
{
    public class MyApplicationState
    {
        public User? currentUser { get; set; }
        public Order? currentOrder { get; set; }
        public void SetCurrentUser(User user) => currentUser = user;
        public void SetCurrentOreder(Order order) => currentOrder = order;

    }
}
