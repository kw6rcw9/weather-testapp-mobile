using MobileTestApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTestApp.Data
{
    interface IRepository: IDisposable
    {
        IEnumerable<User> GetUserList();
        User GetUser(int id);
        int Create(User item);
     
    }
}
