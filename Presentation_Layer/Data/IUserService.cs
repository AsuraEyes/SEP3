using System;
using System.Threading.Tasks;

namespace Data
{
    public interface IUserService
    {
        Task<string> helloWorld();
    }
}