using System.Collections.Generic;
using System.Threading.Tasks;
using FormsToolkitSample.Models;
using Refit;
using Xamarin.Forms;
using FormsToolkitSample.Services;

[assembly: Dependency(typeof(TodoService))]
namespace FormsToolkitSample.Services
{
    public class TodoService : ITodoService
    {

        ITodoRest TodoRestService;

        public TodoService()
        {
            TodoRestService = RestService.For<ITodoRest>(new System.Net.Http.HttpClient()
            {
                BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com")
            }); 
        }

        public async Task<IList<Todo>> ListAllAsync()
        {
            return await TodoRestService.ListAll();
        }
    }
}
