using System;
using UnityEngine;

namespace Assets
{
    public abstract class PanelBase
    {
        public abstract String AssetName { get; set; }
        public abstract String BundleName { get; set; }

        public PanelBase()
        {
        }

        public abstract void InitializePanel(Transform go);

        public void UpdatePanel()
        {

        }

        public void Show()
        {
            if (string.IsNullOrEmpty(AssetName) || string.IsNullOrEmpty(BundleName))
            {
                Debug.LogError("assetName or bundleName is null...");
                return;
            }
            GameObject uiRoot = GameObject.Find("UIRoot");
            GameObject root = LoadABManager.LoadABFromFile(AssetName, BundleName);
            root.transform.SetParent(uiRoot.transform);
            //reset position
            root.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            InitializePanel(root.transform);
            
        }

        public void Hide()
        {

        }
    }
}
