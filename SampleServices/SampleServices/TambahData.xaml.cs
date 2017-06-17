using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SampleServices.Services;
using SampleServices.Models;

namespace SampleServices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TambahData : ContentPage
    {
        private TodoItemServices todoServices;
        public TambahData()
        {
            InitializeComponent();
            todoServices = new TodoItemServices();
            string idRandom = Guid.NewGuid().ToString().Substring(0, 10);
            var newData = new TodoItem
            {
                ID = idRandom
            };
            this.BindingContext = newData;
        }

        private async void btnTambah_Clicked(object sender, EventArgs e)
        {
            try
            {
                var data = (TodoItem)BindingContext;
                await todoServices.TambahData(data);
                await DisplayAlert("Keterangan", "Tambah Data Berhasil !", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}