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
    public partial class createAccount : ContentPage
    {
        public createAccount()
        {
            InitializeComponent();
            labelClicked();
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
        
    }
}