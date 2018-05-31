using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class UnitTestPanel : PanelBase
    {
        public override string AssetName
        {
            get
            {
                return "UnitTestPanel";
            }
        }

        public override string BundleName
        {
            get
            {
                return AssetName.ToLower();
            }
        }

        private Button FloatPanelBtn;
        private Button MessageBoxBtn;

        public override void InitializePanel(Transform go)
        {
            FloatPanelBtn = go.FindChildWithName("FloatPanelBtn").GetComponent<Button>();
            FloatPanelBtn.onClick.AddListener(OnClickFloatPanelBtn);
            MessageBoxBtn = go.FindChildWithName("MessageBoxBtn").GetComponent<Button>();
            MessageBoxBtn.onClick.AddListener(OnClickMessageBoxBtn);
        }

        public override void Show(string msg = "")
        {
            base.Show(msg);
        }

        public override void UpdateData()
        {
            base.UpdateData();
        }

        private void OnClickFloatPanelBtn()
        {
            PanelManager.FloatPanel.Show("hello world!");
        }
        private void OnClickMessageBoxBtn()
        {
            PanelManager.MessageBox.Show("这是一个对话框!");
        }
    }
}
