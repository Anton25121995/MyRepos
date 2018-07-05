
using HelloMvxForms.Interfaces;
using HelloMvxForms.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelloMvxForms.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IAlertService _alertService;

        public LoginViewModel(IMvxNavigationService navigationService,
            IDataBaseService<User> userService,
            IDataBaseService<Item> itemService,
            IAlertService alertService) : base(navigationService, itemService, userService)
        {
            _navigationService = navigationService;
            _alertService = alertService;
            _userService = userService;
            _itemService = itemService;

            LoginCommand = new MvxAsyncCommand(Login);
        }

        #region Properties

        private User _user;
        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private bool _isValidated;
        public bool IsValidated
        {
            get
            {
                return _isValidated;
            }
            set
            {
                _isValidated = value;
                RaisePropertyChanged(() => IsValidated);
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }

        #endregion

        #region LifeCycle

        public override void ViewAppeared()
        {
            IsEnabled = true;
            base.ViewAppeared();
        }

        #endregion

        #region Methods

        public bool CheckFields()
        {
            string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            //string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{8,16}$";

            //if (!Regex.IsMatch(Password, passwordPattern))
            //{
            //    CleanFields();
            //    return false;
            //}

            if (string.IsNullOrEmpty(Email))
            {
                CleanFields();
                IsValidated = false;
                return IsValidated;
            }

            if (!Regex.IsMatch(Email, emailPattern, RegexOptions.IgnoreCase))
            {
                CleanFields();
                IsValidated = false;
                return IsValidated;
            }

            if (string.IsNullOrEmpty(Password))
            {
                CleanFields();
                IsValidated = false;
            }

            if (Password.Length < 6)
            {
                CleanFields();
                IsValidated = false;
            }

            IsValidated = true;
            return IsValidated;
        }

        private void CleanFields()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        private async Task Login()
        {
            if (CheckFields() && UserExisted())
            {
                await _navigationService.Navigate<MvxTableViewModel, User>(User);
            }
            else
            {
                _alertService.ShowSingle("Error, please enter correct data");
            }
        }

        private bool UserExisted()
        {
            var currentUser = _userService.GetAllInstances().Where(x => x.Email == Email).FirstOrDefault();
            if (currentUser != null)
            {
                User = currentUser;
                if (Password != (currentUser as User).Password)
                {
                    _alertService.ShowMessage("Error", "Incorrect password!");
                    CleanPassword();
                    return false;
                }
            }
            if (currentUser == null)
            {
                var user = new User { Email = Email, Password = Password };
                _userService.CreateInstance(user);
                User = user;
                RaiseAllPropertiesChanged();
                return true;
            }
            //User = currentUser;
            //RaiseAllPropertiesChanged();

            return true;
        }

        private void CleanPassword()
        {
            Password = string.Empty;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            CleanFields();
        }

        private void CreateNewUser(string email, string password)
        {
            User oldUser;
            try
            {
                oldUser = _userService.GetInstance(User.Id) ?? null;
                oldUser = User;
                _userService.UpdateInstance(oldUser); //update existed element
            }
            catch //if element doesn't exist in Db
            {
                oldUser = User;
                _userService.InsertInstance(oldUser);
            }
            Close(this);
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand LoginCommand { get; private set; }

        #endregion
    }
}
