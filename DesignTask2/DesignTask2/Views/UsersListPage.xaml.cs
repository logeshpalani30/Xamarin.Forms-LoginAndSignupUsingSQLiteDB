using DesignTask2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesignTask2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersListPage : ContentPage
    {
       // List<string> list = new List<string>() { "logesh", "palani", "palani", "guna" };

        UserDB userData = new UserDB();
        public UsersListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            var sourceData = userData.GetUsers();
            listUser.ItemsSource = sourceData;
        }
    }
}