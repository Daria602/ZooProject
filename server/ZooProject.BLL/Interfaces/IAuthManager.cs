using ZooProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.DAL.Entities;

namespace ZooProject.BLL.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task<string> Refresh(RefreshModel refreshModel);

        Task<List<UserModel>> GetAll();
    }
}
