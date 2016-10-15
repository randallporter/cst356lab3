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

        void IDataRepository.AddOrUpdateEvent(Event anEvent)
        {
            if (anEvent.EventID == default(int))
                _dbc.Entry(anEvent).State = EntityState.Added;
            else
                _dbc.Entry(anEvent).State = EntityState.Modified;

            _dbc.SaveChanges();
        }

        void IDataRepository.AddOrUpdateGroup(Group group)
        {
            if (group.GroupID == default(int))
                _dbc.Entry(group).State = EntityState.Added;
            else
                _dbc.Entry(group).State = EntityState.Modified;

            _dbc.SaveChanges();
        }

        void IDataRepository.AddOrUpdateUser(User user)
        {
            if (user.ID == default(int))
                _dbc.Entry(user).State = EntityState.Added;
            else
                _dbc.Entry(user).State = EntityState.Modified;

            _dbc.SaveChanges();
        }

        List<Event> IDataRepository.GetAllEvents()
        {
            return _dbc.Events.ToList();
        }

        List<Group> IDataRepository.GetAllGroups()
        {
            return _dbc.Groups.ToList();
        }

        List<User> IDataRepository.GetAllUsers()
        {
            return _dbc.Users.ToList();
        }

        Event IDataRepository.GetEvent(int id)
        {
            return _dbc.Events.Find(id);
        }

        Group IDataRepository.GetGroup(int id)
        {
            return _dbc.Groups.Find(id);
        }

        User IDataRepository.GetUser(int id)
        {
            return _dbc.Users.Find(id);
        }

        void IDataRepository.RemoveEvent(Event anEvent)
        {
            _dbc.Events.Remove(anEvent);
            _dbc.SaveChanges();
        }

        void IDataRepository.RemoveGroup(Group group)
        {
            _dbc.Groups.Remove(group);
            _dbc.SaveChanges();
        }

        void IDataRepository.RemovePerson(User user)
        {
            _dbc.Users.Remove(user);
            _dbc.SaveChanges();
        }
    }
}