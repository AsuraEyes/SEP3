using System;
using System.Threading.Tasks;

namespace DefaultNamespace
{
    public interface IUserService
    {
        Task<String> helloWorld();
    }
}