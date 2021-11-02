using System;
using System.Threading.Tasks;

namespace BusinessLayer.Data
{
    public interface IUserService
    {
        Task<String> HelloWorld();
    }
}