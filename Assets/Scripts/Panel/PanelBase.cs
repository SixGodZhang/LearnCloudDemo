using System;
using UnityEngine;

namespace Assets
{
    public abstract class PanelBase
    {
        public abstract String AssetName { get; }
        public abstract String BundleName { get; }

        private GameObject currentPanel;

        public PanelBase()
        {
            LoadPanelAndInitialize("UIRoot");
        }

        public abstract void InitializePanel(Transform go);

        public void UpdatePanel()
        {
        }

        public virtual void UpdateData()
        {

        }

        public virtual void Show(string msg = "")
        {
        }

        private void LoadPanelAndInitialize(string rootName)
        {
            if (string.IsNullOrEmpty(AssetName) || string.IsNullOrEmpty(BundleName))
            {
                Debug.LogError("assetName or bundleName is null...");
                return;
            }
            GameObject uiRoot = GameObject.Find(rootName);
            currentPanel = LoadABManager.LoadABFromFile(AssetName, BundleName);
            currentPanel.transform.SetParent(uiRoot.transform);
            //reset position
            currentPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            InitializePanel(currentPanel.transform);
        }

        public void HidePanel()
        {
            currentPanel.SetActive(false);
            Debug.Log("HidePanel");
            //this.gameObject.SetActive(false);
        }

        public void DestroyPanel()
        {
            GameObject.Destroy(currentPanel);
            Debug.Log("DestroyPanel");
            //Destroy(this.gameObject);
        }
    }
}