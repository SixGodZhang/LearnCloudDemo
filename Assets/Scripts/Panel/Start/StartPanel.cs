using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class StartPanel : PanelBase
    {
        public override string AssetName
        {
            get
            {
                return "StartPanel";
            }
        }

        public override string BundleName
        {
            get
            {
                return AssetName.ToLower();
            }
        }

        private Transform SignUpPart;
        private Transform LoginPart;

        private Button LoginBtn;
        private TMP_InputField SPasswordInputField;
        private TMP_InputField SUserNameInputField;
        private Button SignUpBtn;
        private TMP_InputField SEmailInputField;
        private TMP_InputField LUserNameInputField;
        private TMP_InputField LPasswordInputField;

        public override void InitializePanel(Transform go)
        {
            SignUpPart = go.FindChildWithName("SignUpPart");
            LoginPart = go.FindChildWithName("LoginPart");

            LoginBtn = go.FindChildWithName("LoginBtn").GetComponent<Button>();
            LoginBtn.onClick.RemoveAllListeners();
            LoginBtn.onClick.AddListener(OnClickLoginBtn);
            SPasswordInputField = go.FindChildWithName("SPasswordInputField").GetComponent<TMP_InputField>();
            SUserNameInputField = go.FindChildWithName("SUserNameInputField").GetComponent<TMP_InputField>();
            SignUpBtn = go.FindChildWithName("SignUpBtn").GetComponent<Button>();
            SignUpBtn.onClick.RemoveAllListeners();
            SignUpBtn.onClick.AddListener(OnClickSignUpBtn);
            SEmailInputField = go.FindChildWithName("SEmailInputField").GetComponent<TMP_InputField>();
            LUserNameInputField = go.FindChildWithName("LUserNameInputField").GetComponent<TMP_InputField>();
            LPasswordInputField = go.FindChildWithName("LPasswordInputField").GetComponent<TMP_InputField>();

            InitializeStartPanel();

        }

        private void InitializeStartPanel()
        {
            SignUpPart.gameObject.SetActive(false);
            LoginPart.gameObject.SetActive(false);
        }

        private void OnClickLoginBtn()
        {
           // PanelManager.FloatPanel.Show("登录成功!");
            PanelManager.MessageBox.Show("Welcome to The Game : 寻觅 !");
        }

        private void OnClickSignUpBtn()
        {
            //PanelManager.FloatPanel.Show("注册成功!");
        }
    }
}
