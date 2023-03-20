using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        List<UserDTO> GetAll();
        void Add(UserDTO user);
        UserDTO GetUserByUid(string uid);
    }
}
