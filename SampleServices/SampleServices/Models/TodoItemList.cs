using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace SampleServices.Models
{
    public class TodoItemList : BindableObject
    {
        private ObservableCollection<TodoItem> listTodoItem;
        public ObservableCollection<TodoItem> ListTodoItem
        {
            get { return listTodoItem; }
            set { listTodoItem = value; OnPropertyChanged("ListTodoItem"); }
        }
    }
}
