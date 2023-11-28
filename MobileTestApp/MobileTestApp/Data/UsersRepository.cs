using MobileTestApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace MobileTestApp.Data
{
    public class UsersRepository: IRepository
    {


        private SQLiteConnection _db;
        public UsersRepository(string databasePath)
        {
            _db = new SQLiteConnection(databasePath);
            _db.CreateTable<User>();
        }

        public IEnumerable<User> GetUserList()
        {
            return _db.Table<User>().ToList();
        }

        public User GetUser(int id)
        {
            return _db.Get<User>(id);
        }

        public User GetUserByLogin(string login)
        {
            return _db.Get<User>(u => u.Login == login);
        }
        public User GetUserByPassword(string pass)
        {
            return _db.Get<User>(u => u.Password == pass);
        }


        public int Create(User user)
        {
         
            return _db.Insert(user);
            
        }



        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
