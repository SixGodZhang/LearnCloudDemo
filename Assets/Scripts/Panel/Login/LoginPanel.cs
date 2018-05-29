using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LeanCloud;

namespace Assets
{
    public class LoginPanel : PanelBase
    {
        private String assetName = "LoginPanel";
        public override String AssetName
        {
            get
            {
                return assetName;
            }
            set
            {
                assetName = value;
            }
        }
        private String bundleName = "loginpanel";
        public override String BundleName
        {
            get
            {
                return bundleName;
            }
            set
            {
                bundleName = value;
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
        private TMP_InputField PasswordInputRegisterField;
        private TMP_InputField PhoneNumberInputField;
        

        public override void InitializePanel(Transform go)
        {
            LoginRoot = go.Find("LoginRoot").gameObject;
            RegisterRoot = go.Find("RegisterRoot").gameObject;

            //login
            go.FindChildWithName("LoginBtn").GetComponent<Button>().onClick.AddListener(OnClickLoginBtn);
            go.FindChildWithName("Go2RegisterBtn").GetComponent<Button>().onClick.AddListener(OnClickGo2RegisterBtn);
            go.FindChildWithName("SendCodeBtn").GetComponent<Button>().onClick.AddListener(OnClickSendCodeBtn);
            PhoneNumberInputField = go.FindChildWithName("PhoneNumberInputField").GetComponent<TMP_InputField>();
            ValidateLoginCodeInputField = go.FindChildWithName("ValidateLoginCodeInputField").GetComponent<TMP_InputField>();

            //register
            go.FindChildWithName("BackBtn").GetComponent<Button>().onClick.AddListener(OnClickSendRegisterCodeBtn);
            go.FindChildWithName("RegisterBtn").GetComponent<Button>().onClick.AddListener(OnClickRegisterBtn);
            go.FindChildWithName("SendRegisterCodeBtn").GetComponent<Button>().onClick.AddListener(OnClickSendRegisterCodeBtn);

            Goto(LoginStatus.Login);

        }

        private void OnClickRegisterBtn()
        {
            
        }

        private void OnClickSendRegisterCodeBtn()
        {
            Goto(LoginStatus.Login);
        }

        private void OnClickGo2RegisterBtn()
        {
            Goto(LoginStatus.Register);
        }

        private enum LoginStatus
        {
            Login,
            Register
        }

        private void Goto(LoginStatus status)
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
            var user = new AVUser();
            user.Username = PhoneNumberInputField.text;
            user.Password = PhoneNumberInputField.text;
            user.MobilePhoneNumber = PhoneNumberInputField.text;
            var task = user.SignUpAsync();
        }

        private void OnClickLoginBtn()
        {
            //var task = AVUser.VerifyMobilePhoneAsync(ValidateCodeInputField.text);
            //task.ContinueWith(t =>
            //{
            //    var success = t.Result;
            //});


            //try
            //{
            //    AVUser.RequestLoginSmsCodeAsync(PhoneNumberInputField.text).ContinueWith(t =>
            //    {
            //        var success = t.Result;
            //        //判断返回值可以判断是否发送成功，不成功会抛出带有error的AVException，并且t.Result会被置为false.
            //        //在处理这种容易因为用户输入不合法而产生的异常的时候，为了保证程序的正常运行，建议使用try/catch机制进行提前的异常处理。
            //    });
            //}
            //catch (AVException avException)
            //{
            //    Debug.LogError(avException.Data);
            //}

            //try
            //{
            //    AVUser.LoginBySmsCodeAsync(mobilePhoneNumber, code).ContinueWith(t =>
            //    {
            //        var success = t.Result;
            //    });
            //}
            //catch (AVException avException)
            //{
            //}
        }


    }
}
