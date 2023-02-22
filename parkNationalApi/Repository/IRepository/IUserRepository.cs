using parkNationalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parkNationalApi.Repository.IRepository
{
    public interface IUserRepository
    {
        bool isUnique(string username);
        User Authenticate(string username, string password);
        User Register(string username, string password);

    }
}
