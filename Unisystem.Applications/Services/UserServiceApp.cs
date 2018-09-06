using System;
using System.Collections.Generic;
using System.Linq;
using Unisystem.Domain.Entities;
using Unisystem.Infra.Context;
using Unisystem.Repository.Repositories;

namespace Unisystem.Applications.Services
{
    public class UserServiceApp : IUserRepository
    {
        public User Get(int id)
        {
            using (var db = new UnisystemContext())
            {
                return db.Users.FirstOrDefault(x=>x.Id == id);
            }
        }
        
        public List<User> GetAll()
        {
            using (var db = new UnisystemContext())
            {
                return db.Users.ToList();
            }
        }

        public Response Insert(User user)
        {
            var response = new Response();
            response.Status = false;

            using (var db = new UnisystemContext())
            {
                if (db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
                {
                    response.Message = "Email já cadastrado!";
                    return response;
                }

                if (db.Users.FirstOrDefault(x => x.Phone == user.Phone) != null)
                {
                    response.Message = "Telefone já cadastrado!";
                    return response;
                }
                
                user.Created = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();

                response.Status = true;
                response.Message = "Cadastrado com sucesso!";
                return response;
            }
        }

        public Response Update(User u)
        {
            var response = new Response();
            response.Status = false;

            using (var db = new UnisystemContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == u.Id);

                if (user.Email != u.Email)
                {
                    if (db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
                    {
                        response.Message = "Email já cadastrado!";
                        return response;
                    }
                }

                if (user.Phone != u.Phone)
                {
                    if (db.Users.FirstOrDefault(x => x.Phone == user.Phone) != null)
                    {
                        response.Message = "Telefone já cadastrado!";
                        return response;
                    }
                }

                user.Email = u.Email;
                user.Name = u.Name;
                user.Phone = u.Phone;

                db.SaveChanges();

                response.Status = true;
                response.Message = "Atualizado com sucesso!";
                return response;
            }
        }

        public Response Delete(int id)
        {
            var response = new Response();
            response.Status = false;

            using (var db = new UnisystemContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();

                    response.Status = true;
                    response.Message = "Removido com sucesso!";
                    return response;
                }

                response.Message = "Usuário não encontrado!";
                return response;
            }
        }
    }
}
