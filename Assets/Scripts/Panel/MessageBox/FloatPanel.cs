using PathologicalGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class FloatPanel : MessagePanelBase
    {
        public override string AssetName
        {
            get
            {
                return "FloatPanel";
            }
        }
        public override string BundleName
        {
            get
            {
                return AssetName.ToLower();
            }
        }

        private TextMeshProUGUI FloatText;
        private Transform Root;
        

        public override void InitializePanel(Transform go)
        {
            Root = go;
            Debug.Log("go: "+ go.name);
            FloatText = go.FindChildWithName("FloatText").GetComponent<TextMeshProUGUI>();
        }

        public override void Show(string msg)
        {
            base.Show(msg);
            FloatText.text = msg;
            SpawnPool pool = PoolManager.Pools["MessageBox"];
            GameObject poolRoot = GameObject.Find("MessageBoxPool");
            pool.Despawn(Root,1,poolRoot.transform);
        }
    }
}
