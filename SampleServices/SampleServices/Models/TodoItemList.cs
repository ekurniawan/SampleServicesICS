using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleServices.Models
{
    public class TodoItemList
    {
        private List<TodoItem> listTodoItem;
        public List<TodoItem> ListTodoItem
        {
            get { return listTodoItem; }
            set { listTodoItem = value; }
        }
    }
}
