using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Data
{
    public class EFDataRepository : IDataRepository
    {
        private readonly WebAppContext _dbc;

        public EFDataRepository()
        {
            _dbc = new WebAppContext();
        }

        public void AddOrUpdateEvent(Event anEvent)
        {
            if (anEvent.EventID == default(int))
                _dbc.Entry(anEvent).State = EntityState.Added;
            else
                _dbc.Entry(anEvent).State = EntityState.Modified;

            _dbc.SaveChanges();
        }

        public void AddOrUpdateGroup(Group group)
        {
            if (group.GroupID == default(int))
                _dbc.Entry(group).State = EntityState.Added;
            else
                _dbc.Entry(group).State = EntityState.Modified;

            _dbc.SaveChanges();
        }

        public void AddOrUpdateUser(User user)
        {
            if (user.ID == default(int))
                _dbc.Entry(user).State = EntityState.Added;
            else
                _dbc.Entry(user).State = EntityState.Modified;

            _dbc.SaveChanges();
        }

        public List<Event> GetAllEvents()
        {
            return _dbc.Events.ToList();
        }

        public List<Group> GetAllGroups()
        {
            return _dbc.Groups.ToList();
        }

        public List<User> GetAllUsers()
        {
            return _dbc.Users.ToList();
        }

        public Event GetEvent(int id)
        {
            return _dbc.Events.Find(id);
        }

        public Group GetGroup(int id)
        {
            return _dbc.Groups.Find(id);
        }

        public User GetUser(int id)
        {
            return _dbc.Users.Find(id);
        }

        public void RemoveEvent(Event anEvent)
        {
            _dbc.Events.Remove(anEvent);
            _dbc.SaveChanges();
        }

        public void RemoveGroup(Group group)
        {
            _dbc.Groups.Remove(group);
            _dbc.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _dbc.Users.Remove(user);
            _dbc.SaveChanges();
        }

        public void Dispose()
        {
            _dbc.Dispose();
        }
    }
}