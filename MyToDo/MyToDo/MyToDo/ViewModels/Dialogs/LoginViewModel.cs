using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels.Dialogs
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public LoginViewModel()
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
        }

        public string Title { get; set; } = "ToDo";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        #region Login

        public DelegateCommand<string> ExecuteCommand { get; private set; }


        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Login": Login(); break;
                case "LoginOut": LoginOut(); break;
            }
        }

        void Login()
        {
            if (string.IsNullOrWhiteSpace(UserName) ||
                string.IsNullOrWhiteSpace(PassWord))
            {
                return;
            }


        }

        void LoginOut()
        {

        }
        #endregion
    }
}
