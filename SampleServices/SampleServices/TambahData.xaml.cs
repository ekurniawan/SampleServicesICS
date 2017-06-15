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
            txtID.Text = Guid.NewGuid().ToString().Substring(0, 10);
        }

        private async void btnTambah_Clicked(object sender, EventArgs e)
        {
            var newData = new TodoItem
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Notes = txtNotes.Text,
                Done = swDone.IsToggled
            };

            try
            {
                await todoServices.TambahData(newData);
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