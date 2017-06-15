using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using SampleServices.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace SampleServices.Services
{
    public class TodoItemServices
    {
        private HttpClient _client;

        public TodoItemServices()
        {
            _client = new HttpClient();
        }

        public async Task<List<TodoItem>> GetAll()
        {
            var strUrl = new Uri(Path.Combine(Koneksi.RestUrl, "api/TodoItem"));
            var response = await _client.GetAsync(strUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                return data;
            }
            else
            {
                throw new Exception("Error : " + response.StatusCode.ToString());
            }
        }

        public async Task TambahData(TodoItem todoItem)
        {
            var strUrl = new Uri(Path.Combine(Koneksi.RestUrl, "api/TodoItem"));
            var newItem = JsonConvert.SerializeObject(todoItem);
            var content = new StringContent(newItem, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await _client.PostAsync(strUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error: Data gagal ditambah !" + 
                    response.StatusCode.ToString());
            }
        }

        public async Task UpdateData(TodoItem todoItem)
        {
            var strUrl = new Uri(Path.Combine(Koneksi.RestUrl, 
                string.Format("api/TodoItem/{0}", todoItem.ID)));
            var editItem = JsonConvert.SerializeObject(todoItem);
            var content = new StringContent(editItem, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await _client.PutAsync(strUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error: data gagal diupdate ! " + 
                    response.StatusCode.ToString());
            }
        }

        public async Task DeleteData(string id)
        {
            var strUrl = new Uri(Path.Combine(Koneksi.RestUrl, 
                string.Format("api/TodoItem/{0}", id)));
            HttpResponseMessage response = null;
            response = await _client.DeleteAsync(strUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error: data gagal didelete ! " + 
                    response.StatusCode.ToString());
            }
        }


    }
}
