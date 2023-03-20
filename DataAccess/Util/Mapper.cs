using BusinessObjects;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Util
{
    public class Mapper
    {
        public static UserDTO mapToDTO(User user)
        {
            if (user != null)
            {
                UserDTO userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    Uid = user.Uid,
                    Role = user.Role,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    AvtUrl = user.AvtUrl
                };
                return userDTO;
            }
            else
            {
                return null;
            }

        }

        public static User mapToEntity(UserDTO userDTO)
        {
            User user = new User
            {
                UserId = userDTO.UserId,
                Uid = userDTO.Uid,
                Role = userDTO.Role,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                AvtUrl = userDTO.AvtUrl
            };

            return user;
        }
    }
}
