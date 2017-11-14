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

        void OnSelectedIndexChanged(object sender, PropertyChangedEventArgs args)
        {
            (BindingContext as TodoViewModel).Filter = FilterPicker.SelectedItem as string;
        }

    }

    public class TodoViewModel : INotifyPropertyChanged
    {

        readonly ITodoService TodoService;

        IList<Todo> todos;

        public IList<Todo> Todos
        {
            get => ReturnWithFilter();
            set
            {
                todos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Todos)));
            }
        }

        private IList<Todo> ReturnWithFilter()
        {
            switch (Filter)
            {
                case "All":
                    return todos;
                case "Todo":
                    return todos.Where(t => !t.Completed).ToList();
                default:
                    return todos.Where(t => t.Completed).ToList();
            }
        }

        string filter = "All";

        public string Filter
        {
            get => filter;
            set
            {
                filter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Todos)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));
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