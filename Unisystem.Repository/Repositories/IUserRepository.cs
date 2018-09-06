using System;
using System.Collections.Generic;
using Unisystem.Domain.Entities;

namespace Unisystem.Repository.Repositories
{
    public interface IUserRepository
    {
        User Get(int id);
        List<User> GetAll();
        Response Insert(User user);
        Response Update(User user);
        Response Delete(int id);
    }
}
