using Plugin.Toast;
using SQLite;
using System;
using System.Collections.Generic;
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
    public partial class createAccount : ContentPage
    {
        private SQLiteConnection connection;
        public createAccount()
        {
            InitializeComponent();
            labelClicked();
            connection = DependencyService.Get<ISQLiteDB>().GetConnection();

        }
        protected override void OnAppearing()
        {
            
            connection.CreateTable<Teacher>();
            base.OnAppearing();
        }
        public IEnumerable<Teacher> GetTeachers()
        {
            return (from teachers in connection.Table<Teacher>() select teachers).ToList();
        } 

        void labelClicked()
        {
            login.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new loginView());
                })
            }) ; 

        }

        async private void onAdd(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passEntry.Text;
            string passwordConf = confirmPassEntry.Text;
            IEnumerable<Teacher> teachers = GetTeachers();
            Teacher teacher = teachers.FirstOrDefault(t => t.userName.Equals(username));
            
            if (teacher == null && password.Equals(passwordConf))
            {
               
                Teacher newTeacher = new Teacher(username, password);
                connection.Insert(newTeacher);
                CrossToastPopUp.Current.ShowToastSuccess("Account created successfully");
                await Navigation.PushAsync(new loginView());
            }
            else if(!password.Equals(passwordConf))
            {
                CrossToastPopUp.Current.ShowToastWarning("Password does not match");
            }
            else
            {
                CrossToastPopUp.Current.ShowToastError("Account exist");
            }

        }
    }
}