using Plugin.Toast;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProject.entities;
using XamarinProject.Model;
using XamarinProject.persistence;

[assembly: Dependency(typeof(DBManager))]
namespace XamarinProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class loginView : ContentPage
    {
        private SQLiteConnection connection;
        public loginView()
        {
            InitializeComponent();
            labelClicked();
            connection = DependencyService.Get<ISQLiteDB>().GetConnection();
        }
        public IEnumerable<Teacher> GetTeachers()
        {
            return (from teachers in connection.Table<Teacher>() select teachers).ToList();
        }
        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            string username = user.Text;
            string pass = password.Text;
            IEnumerable<Teacher> teachers = GetTeachers();
            if (teachers.Count() > -1)
            {
                foreach (Teacher teacher in teachers)
                {
                    if (teacher.userName.Equals(username))
                    {

                        if (teacher.password.Equals(pass))
                        {
                            await Navigation.PushAsync(new Home());
                            break;
                        }
                        else
                        {
                            CrossToastPopUp.Current.ShowToastWarning("Wrong password");
                        }

                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastError("Account does not exist");
                    }
                }
            }
            
            

        }
        void labelClicked()
        {
            sign.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new createAccount());
                })
            });
        }
    }
}