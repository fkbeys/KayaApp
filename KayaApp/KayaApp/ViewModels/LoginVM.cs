using Acr.UserDialogs;
using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Language;
using KayaApp.Models;
using KayaApp.Views;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KayaApp.ViewModels
{
    public class LoginVM : BaseViewModel
    {

        public static LISTMANAGER _LSTMANAGER;

        private static CompanyModel GelenCompany;
        private static UsersModel GelenUser;
        public ICommand LoginCommand { get; set; }
        public ICommand DemoCommand { get; set; }

        public LoginVM()
        {


            LoginCommand = new Command(LoginGO);
            DemoCommand = new Command(DemoGO);

            UserCompanyName = UserSettings.UserCompanyName;
            UserName = UserSettings.UserName;
            UserPass = UserSettings.UserPass;

            if (UserPass != "")
            {
                remeberpassword = true;
            }
            else
            {
                remeberpassword = false;
            }


        }

        #region properties



        private bool _IsLoginActive;

        public bool IsLoginActive
        {
            get
            {
                return _IsLoginActive;
            }
            set
            {
                _IsLoginActive = value;
                INotifyPropertyChanged();
            }
        }

        private string _UserCompanyName;

        public string UserCompanyName
        {
            get
            {
                if (_UserCompanyName == null)
                {
                    _UserCompanyName = "";
                }
                return _UserCompanyName;
            }
            set
            {
                _UserCompanyName = value;
                userloginbuttonaktivitecontrol();
                INotifyPropertyChanged();
            }
        }

        private string _UserName;

        public string UserName
        {
            get
            {
                if (_UserName == null)
                {
                    _UserName = "";
                }
                return _UserName;
            }
            set
            {
                _UserName = value;
                userloginbuttonaktivitecontrol();
                INotifyPropertyChanged();
            }
        }


        private string _UserPass;

        public string UserPass
        {
            get
            {
                if (_UserPass == null)
                {
                    _UserPass = "";
                }
                return _UserPass;
            }
            set
            {
                _UserPass = value;
                userloginbuttonaktivitecontrol();
                INotifyPropertyChanged();
            }
        }

        //public bool remeberpassword { get; set; }
        private bool _remeberpassword;

        public bool remeberpassword
        {
            get { return _remeberpassword; }
            set
            {
                _remeberpassword = value;
                INotifyPropertyChanged();
            }
        }


        private void userloginbuttonaktivitecontrol()
        {
            if (UserCompanyName == "" || UserName == "" || UserPass == "") IsLoginActive = false;
            else IsLoginActive = true;
        }
        #endregion

        private async void LoginGO(object obj)
        {
            UserSettings.UserCompanyName = UserCompanyName;
            UserSettings.UserName = UserName;
            if (remeberpassword)
            {
                UserSettings.UserPass = UserPass;
            }
            else
            {
                UserSettings.UserPass = "";

            }
            UserDialogs.Instance.ShowLoading(AppResources.dialog_logginginplzwait, MaskType.Gradient);
            IsLoginActive = false;


            //********ZAMAN OLCME **************************************
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //*******************************************************

            if (await LoginMethod())
            {
                bool sonuc = await DataClass.GetData(GelenCompany, GelenUser);
                if (sonuc)
                {
                    await HelpME.SayfaAc(new MainMenuPage());
                }
                else
                {
                    await HelpME.MessageShow("HATA", "Bir hata olustu lutfen tekrar deneyiniz", "ok");
                }

            }
            else
            {
                await HelpME.MessageShow("Hatali", "hata", "hata");
            }
            UserDialogs.Instance.HideLoading();
            IsLoginActive = true;


            //*******************************************************
            watch.Stop();
            await HelpME.MessageShow("Gecen Sure", watch.Elapsed.Seconds.ToString(), "ok");
            //*******************************************************

        }
        private async Task<bool> LoginMethod()
        {
            try
            {
                GelenCompany = new CompanyModel();
                GelenUser = new UsersModel();

                if (CrossConnectivity.Current.IsConnected)
                {
                    GelenCompany = await getcompanyinfo(UserCompanyName);
                    GelenUser = await GetUsersInfo(GelenCompany, UserName, UserPass);
                }
                else
                {
                    var CompanyList = await LocalSQL<CompanyModel>.GETLISTALL();
                    GelenCompany = CompanyList.Where(x => x.COMPANY_NAME == UserCompanyName).FirstOrDefault();

                    var UserList = await LocalSQL<UsersModel>.GETLISTALL();
                    GelenUser = UserList.Where(x => x.USERS_NAME == UserName && x.USERS_PASS == Sifrele.SSifrele(UserPass)).FirstOrDefault();
                }
                if (GelenCompany.COMPANY_DB_NAME != "" && GelenUser.USERS_NAME != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        private void DemoGO(object obj)
        {
            UserCompanyName = "Demo";
            UserName = "Demo";
            UserPass = "Demo";
            remeberpassword = true;
        }

        private async Task<CompanyModel> getcompanyinfo(string compname)
        {
            string CompanyLink = SabitUrl.SirketBilgileriUrl(compname);
            var GetCompany = await ApiBaglan<CompanyModel>.VeriListeAl(CompanyLink);

            await LocalSQL<CompanyModel>.DELETEROW(GetCompany[0]);
            await LocalSQL<CompanyModel>.DBROWINSERT(GetCompany[0]);

            return GetCompany[0];
        }
        private async Task<UsersModel> GetUsersInfo(CompanyModel CompanyMM, string usersname, string userspass)
        {
            string Userlink = SabitUrl.UserLink(CompanyMM, usersname, userspass);
            var GetUser = await ApiBaglan<UsersModel>.VeriListeAl(Userlink);

            await LocalSQL<UsersModel>.DELETEROW(GetUser[0]);
            await LocalSQL<UsersModel>.DBROWINSERT(GetUser[0]);

            var tt = await LocalSQL<UsersModel>.GETLISTALL();
            return GetUser[0];
        }
    }
}