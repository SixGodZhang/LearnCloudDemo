using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class MessageBox : MessagePanelBase
    {
        public override string AssetName
        {
            get
            {
                return "MessageBox";
            }
        }
        public override string BundleName
        {
            get
            {
                return "messagebox";
            }
        }

        private Action OnCancel;
        private Action OnOK;

        private Button CancelBtn;
        private TextMeshProUGUI ShowMsgTxt;
        private Button ConfirmBtn;
        private Transform PanelRoot;

        public override void InitializePanel(Transform go)
        {
            PanelRoot = go;
            CancelBtn = go.FindChildWithName("CancelBtn").GetComponent<Button>();
            CancelBtn.onClick.RemoveAllListeners();
            CancelBtn.onClick.AddListener(OnClickCancelBtn);
            ShowMsgTxt = go.FindChildWithName("ShowMsgTxt").GetComponent<TextMeshProUGUI>();
            ConfirmBtn = go.FindChildWithName("ConfirmBtn").GetComponent<Button>();
            ConfirmBtn.onClick.RemoveAllListeners();
            ConfirmBtn.onClick.AddListener(OnClickConfirmBtn);
        }

        private void OnClickCancelBtn()
        {
            Debug.Log("Click Cancel Btn....");
            Hide();
            if (OnCancel != null)
            {
                OnCancel();
            }
            
        }

        private void OnClickConfirmBtn()
        {
            Debug.Log("Click Confirm Btn....");
            Hide();
            if (OnOK != null)
            {
                OnOK();
            }

        }

        public override void Show(string msg,Action ok = null,Action cancel = null)
        {
            base.Show(msg);
            ShowMsgTxt.text = msg;
            OnOK = ok;
            OnCancel = cancel;
        }
    }
}