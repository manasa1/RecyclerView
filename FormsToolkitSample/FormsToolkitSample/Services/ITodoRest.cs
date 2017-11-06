using FormsToolkitSample.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormsToolkitSample.Services
{
    public interface ITodoRest
    {

        [Get("/todos")]
        Task<IList<Todo>> ListAll();

    }
}
