using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets
{
    class LoadABManager
    {
        public static GameObject LoadABFromFile(String abName,String bundleName)
        {
            var baseAB = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
            if (baseAB == null)
            {
                Debug.LogError(bundleName + "Not Found!");
            }

            GameObject rootPanel = baseAB.LoadAsset<GameObject>(abName);

            //unload
            //baseAB.Unload(true);

            //return GameObject.Instantiate<GameObject>(rootPanel);
            return rootPanel;
        }
    }

}