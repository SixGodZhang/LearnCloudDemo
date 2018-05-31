using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LeanCloud;
using System.Threading.Tasks;

namespace Assets
{
    public class LoginPanel : PanelBase
    {
        public override String AssetName
        {
            get
            {
                return "LoginPanel";
            }
        }

        public override String BundleName
        {
            get
            {
                return "loginpanel";
            }
        }

        private GameObject LoginRoot;
        private GameObject RegisterRoot;

        //Login UI
        private Button LoginBtn;

        private Button SendCodeBtn;
        private Button Go2RegisterBtn;
        private TMP_InputField PhoneNumberLoginInputField;
        private TMP_InputField ValidateLoginCodeInputField;

        //Register UI
        private Button BackBtn;

        private Button RegisterBtn;
        private Button SendRegisterCodeBtn;

        private TMP_InputField UserNameInputField;
        private TMP_InputField PasswordInputField;
        private TMP_InputField PhoneNumberRegisterInputField;
        private TMP_InputField ValidateRegisterCodeInputField;

        public override void InitializePanel(Transform go)
        {
            LoginRoot = go.Find("LoginRoot").gameObject;
            //RegisterRoot = go.Find("RegisterRoot").gameObject;

            //login
            go.FindChildWithName("LoginBtn").GetComponent<Button>().onClick.AddListener(OnClickLoginBtn);
            UserNameInputField = go.FindChildWithName("UserNameInputField").GetComponent<TMP_InputField>();
            PasswordInputField = go.FindChildWithName("PasswordInputField").GetComponent<TMP_InputField>();
            //go.FindChildWithName("Go2RegisterBtn").GetComponent<Button>().onClick.AddListener(OnClickGo2RegisterBtn);
            //go.FindChildWithName("SendCodeBtn").GetComponent<Button>().onClick.AddListener(OnClickSendCodeBtn);
            //PhoneNumberLoginInputField = go.FindChildWithName("PhoneNumberLoginInputField").GetComponent<TMP_InputField>();
            //ValidateLoginCodeInputField = go.FindChildWithName("ValidateLoginCodeInputField").GetComponent<TMP_InputField>();

            //register
            //go.FindChildWithName("BackBtn").GetComponent<Button>().onClick.AddListener(OnClickSendRegisterCodeBtn);
            //go.FindChildWithName("RegisterBtn").GetComponent<Button>().onClick.AddListener(OnClickRegisterBtn);
            //go.FindChildWithName("SendRegisterCodeBtn").GetComponent<Button>().onClick.AddListener(OnClickSendRegisterCodeBtn);

            //UserNameInputField = go.FindChildWithName("UserNameInputField").GetComponent<TMP_InputField>();
            //PasswordInputField = go.FindChildWithName("PasswordInputField").GetComponent<TMP_InputField>();
            //PhoneNumberRegisterInputField = go.FindChildWithName("PhoneNumberRegisterInputField").GetComponent<TMP_InputField>();
            //ValidateRegisterCodeInputField = go.FindChildWithName("ValidateRegisterCodeInputField").GetComponent<TMP_InputField>();

            //初始化显示UI
            //Goto(LoginStatus.Login);
        }

        private void OnClickRegisterBtn()
        {
        }

        private void OnClickSendRegisterCodeBtn()
        {
            var user = new AVUser();
            user.Username = UserNameInputField.text;
            user.Password = PasswordInputField.text;
            user.MobilePhoneNumber = PhoneNumberRegisterInputField.text;
            var task = user.SignUpAsync();
        }

        private void OnClickGo2RegisterBtn()
        {
            Goto(LoginStatus.Register);
        }

        public enum LoginStatus
        {
            Login,
            Register
        }

        public void Goto(LoginStatus status)
        {
            switch (status)
            {
                case LoginStatus.Login:
                    LoginRoot.SetActive(true);
                    RegisterRoot.SetActive(false);
                    break;

                case LoginStatus.Register:
                    LoginRoot.SetActive(false);
                    RegisterRoot.SetActive(true);
                    break;
            }
        }

        private void OnClickSendCodeBtn()
        {
        }

        private void OnClickLoginBtn()
        {
            AVUser.Query.WhereEqualTo("username", UserNameInputField.text).FindAsync().ContinueWith((t) =>
            {

            //    if (t.IsFaulted || t.IsCanceled)
            //    {
            //        string err = t.Exception.Message;
            //        Debug.LogFormat("user not found : {0}", err);
            //    }
            //    else
            //    {
            //        Debug.LogFormat("find this user: {0}", AVUser.CurrentUser.ObjectId);
            //    }

            //    //string tt = t.Exception.InnerExceptions[0].Message;
            //    IEnumerable<AVUser> players = t.Result;
            //    AVUser user = players.First<AVUser>();
            //    string name = user.Get<string>("username");
            //    GlobalThread.runOnMainThread(() =>
            //    {
            //        PasswordInputField.text = name;
            //    });
            //});
        }

        private void OnClickQueryBtn()
        {
            var query = new AVQuery<ACCOUNT>();
            query.FindAsync().ContinueWith(t =>
            {
                ACCOUNT first = t.Result.FirstOrDefault();
                PanelManager.MessageBox.Show(first.ToString());
            });
        }
    }
}