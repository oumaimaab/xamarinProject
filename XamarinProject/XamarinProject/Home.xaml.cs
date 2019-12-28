using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private void absence(object sender, EventArgs e)
        {

        }
        async private void student(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addStudent());
        }
        private void lesson(object sender, EventArgs e)
        {

        }
        private void search(object sender, EventArgs e)
        {

        }
        private void logout(object sender, EventArgs e)
        {

        }
    }
}