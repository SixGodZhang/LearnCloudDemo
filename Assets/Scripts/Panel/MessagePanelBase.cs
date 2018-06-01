using PathologicalGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public abstract class MessagePanelBase
    {
        public abstract String AssetName { get; }
        public abstract String BundleName { get; }

        public MessagePanelBase()
        {
            LoadPanelAndInitialize();//加载面板预设
        }

        public abstract void InitializePanel(Transform go);

        public void UpdatePanel()
        {
        }

        /// <summary>
        /// 适用于MessageBox
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ok"></param>
        /// <param name="cancel"></param>
        public virtual void Show(string msg, Action ok = null, Action cancel = null)
        {
            ShowCommonCode();//执行主体代码
        }

        /// <summary>
        /// 适用于ShowPanel
        /// </summary>
        /// <param name="msg"></param>
        public virtual void Show(string msg)
        {
            ShowCommonCode();//执行主体代码
        }

        public void ShowCommonCode()
        {
            //从缓冲池中取
            Transform current = PoolManager.Pools["MessageBox"].Spawn(AssetName);

            if (current == null)
            {
                Debug.LogError("MessageBox Pool Not Found");
                return;
            }

            GameObject uiRoot = GameObject.Find("MessageBoxRoot");
            current.SetParent(uiRoot.transform,false);
            //reset position
            current.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            InitializePanel(current);
        }

        private void LoadPanelAndInitialize()
        {
            if (string.IsNullOrEmpty(AssetName) || string.IsNullOrEmpty(BundleName))
            {
                Debug.LogError("assetName or bundleName is null...");
                return;
            }
        }

        public Transform GetPanel()
        {

            //Resources.Load<Transform>("Prefab/"+AssetName);
            GameObject getPanel = LoadABManager.LoadABFromFile(AssetName, BundleName);

            if (getPanel == null)
            {
                Debug.Log("MessageBox Not Found!");
            }

            return getPanel.transform;
        }

        /// <summary>
        /// 放入缓存池
        /// </summary>
        public void Hide()
        {
            Debug.Log("HidePanel"+ PoolManager.Pools["MessageBox"].Count);

            SpawnPool pool = PoolManager.Pools["MessageBox"];

            while (pool.Count > 0)
            {
                Transform instance = pool[pool.Count - 1];
                GameObject poolRoot = GameObject.Find("MessageBoxPool");

                pool.Despawn(instance, poolRoot.transform);
                
            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void DestroyPanel()
        {
            Debug.Log("DestroyPanel");
            //GameObject.Destroy(currentPanel);
        }
    }
}
