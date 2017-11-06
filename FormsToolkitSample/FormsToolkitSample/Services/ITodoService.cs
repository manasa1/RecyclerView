using FormsToolkitSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormsToolkitSample.Services
{
    public interface ITodoService
    {

        Task<IList<Todo>> ListAllAsync();

    }
}
