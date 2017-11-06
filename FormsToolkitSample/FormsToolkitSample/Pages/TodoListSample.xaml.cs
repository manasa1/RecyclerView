using FormsToolkitSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FormsToolkitSample.Models;
using System.ComponentModel;

namespace FormsToolkitSample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoListSample : ContentPage
	{
		public TodoListSample ()
		{
            BindingContext = new TodoViewModel();
			InitializeComponent ();
		}
	}

    public class TodoViewModel : INotifyPropertyChanged
    {

        readonly ITodoService TodoService;

        IList<Todo> todos;

        public IList<Todo> Todos
        {
            get => todos;
            set
            {
                todos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Todos)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TodoViewModel()
        {
            TodoService = DependencyService.Get<ITodoService>(DependencyFetchTarget.GlobalInstance);
            RefreshList();
        }

        async void RefreshList()
        {
            Todos = await TodoService.ListAllAsync();
        }
    }
}