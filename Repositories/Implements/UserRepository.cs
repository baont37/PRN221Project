using BusinessObjects;
using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class UserRepository:IUserRepository
    {
        UserDAO userDAO = new UserDAO();
        public List<UserDTO> GetAll()
        {
            return userDAO.GetUsers().Select(m => Mapper.mapToDTO(m)).ToList();
        }

        public void Add(UserDTO user)
        {
            userDAO.AddUser(Mapper.mapToEntity(user));
        }

        public UserDTO GetUserByUid( string uid)
        {
            return userDAO.GetUserByUid(uid);
        }
    }
}
