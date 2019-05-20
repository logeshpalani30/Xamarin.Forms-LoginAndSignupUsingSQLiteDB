using DesignTask2.Helper;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesignTask2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserDB userData = new UserDB();
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            firstPassword.ReturnCommand = new Command(() => secondPassword.Focus());
            var forgetpassword_tap = new TapGestureRecognizer();
            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetpassword_tap);
        }

        private async void Forgetpassword_tap_Tapped(object sender, EventArgs e)
        {
            popupLoadingView.IsVisible = true;
            //var textresult = userData.updateUserValidation(useridValidationEntry.Text);
            //if (textresult)
            //{

            //}
        }
        string logesh;
        private async void userIdCheckEvent(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(useridValidationEntry.Text)) || (string.IsNullOrWhiteSpace(useridValidationEntry.Text)))
            {                
                await DisplayAlert("Alert", "Enter Mail Id","OK"); 
            }
            else
            {
                logesh = useridValidationEntry.Text;
                var textresult = userData.updateUserValidation(useridValidationEntry.Text);
                if (textresult)
                {
                    popupLoadingView.IsVisible = false;
                    passwordView.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("User Mail Id Not Exist", "Enter Correct User Name", "OK");
                }
            }

        }
        private async void Password_ClickedEvent(object sender, EventArgs e)
        {
            if (!string.Equals(firstPassword.Text, secondPassword.Text))
            {
                warningLabel.Text = "Enter Same Password";
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if ((string.IsNullOrWhiteSpace(firstPassword.Text)) || (string.IsNullOrWhiteSpace(secondPassword.Text)))
            {
                await DisplayAlert("Alert", " Enter Password", "OK");
            }
            else
            {
                try
                {
                  var return1 =  userData.updateUser(logesh, firstPassword.Text);
                    passwordView.IsVisible = false;
                    if (return1)
                    {
                        await DisplayAlert("Password Updated","User Data updated","OK");
                    }
                }
                catch (Exception)
                {
                     throw;
                }
            }
        }


            private async void LoginValidation_ButtonClicked(object sender, EventArgs e)
        {
            //popupLoadingView.IsVisible = true;
            //activityIndicator.IsVisible = true;
            //activityIndicator.IsRunning = true;

            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                var validData = userData.LoginValidate(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    popupLoadingView.IsVisible = false;
                    //activityIndicator.IsVisible = false;
                    //activityIndicator.IsRunning = false;
                    //var name = this.GetType().Name;
                    await App.NavigatiPageAsync(loginPage);

                }
                else
                {
                    popupLoadingView.IsVisible = false;
                    //activityIndicator.IsVisible = false;
                    //activityIndicator.IsRunning = false;
                    await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                }

            }
            else
            {
                popupLoadingView.IsVisible = false;
                await DisplayAlert("He He", "Enter User Name and Password Please", "OK");
            }
        }

        //TapGestureRecognizer forgetpassword_tab = new TapGestureRecognizer();


    }
}