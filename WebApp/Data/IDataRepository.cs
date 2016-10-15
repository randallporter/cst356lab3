using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Data
{
    public interface IDataRepository
    {
        //USER
        List<User> GetAllUsers();
        void AddOrUpdateUser(User user);
        User GetUser(int id);
        void RemoveUser(User user);
        //GROUP
        List<Group> GetAllGroups();
        void AddOrUpdateGroup(Group group);
        Group GetGroup(int id);
        void RemoveGroup(Group group);
        //EVENT
        List<Event> GetAllEvents();
        void AddOrUpdateEvent(Event anEvent);
        Event GetEvent(int id);
        void RemoveEvent(Event anEvent);
        void Dispose();
    }
}
