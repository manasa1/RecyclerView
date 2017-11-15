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
using System.Collections.ObjectModel;

namespace FormsToolkitSample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoListSample : ContentPage
	{

        readonly ISettingsService SettingsService;

		public TodoListSample ()
		{
            SettingsService = DependencyService.Get<ISettingsService>();
            BindingContext = new TodoViewModel();

			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            Recycler.CanReorder = SettingsService.CanReorder;
            base.OnAppearing();
        }

        void OnDeleteItemRequest(object sender, PropertyChangedEventArgs args)
        {
            var button = sender as Button;
            var context = button.BindingContext;

            ((TodoViewModel)BindingContext).RemoveTask(context as Todo);
        }

    }

    public class TodoViewModel : INotifyPropertyChanged
    {

        readonly ITodoService TodoService;

        ObservableCollection<Todo> _allTasks;

        public ObservableCollection<Todo> AllTasks
        {
            get => _allTasks;
            set
            {
                _allTasks = value;
                RaisePropertyChanged(nameof(AllTasks));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TodoViewModel()
        {
            TodoService = DependencyService.Get<ITodoService>(DependencyFetchTarget.GlobalInstance);

            AllTasks = new ObservableCollection<Todo>();
            RefreshListAsync().ConfigureAwait(false);
        }

        internal void RemoveTask(Todo todo)
        {
            AllTasks.Remove(todo);
        }

        async Task RefreshListAsync()
        {
            AllTasks = new ObservableCollection<Todo>(await TodoService.ListAllAsync());
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}