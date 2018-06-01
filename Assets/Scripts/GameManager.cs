using Assets;
using LeanCloud;
using PathologicalGames;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform testGo;

    private void Start()
    {
        PanelManager.StartPanel.Show();
        //PanelManager.LoginPanel.Show();
        Initialize();
        //Debug.Log("child count : "+ testGo.FindChildWithName(childName).childCount);
    }

    public void Initialize()
    {
        InitializeGameObject();
        InitializeMessageBoxPoolManager();//初始化提示弹窗对象池
        InitializeFloatPanelPoolManager();//初始化飘字对象池
        InitializeDataClass(); 
    }

    private void InitializeGameObject()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(GameObject.Find("MessageBoxRoot")); 
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
    }

    private void InitializeDataClass()
    {
        AVObject.RegisterSubclass<ACCOUNT>();
    }

    
    private void InitializeMessageBoxPoolManager()
    {
        SpawnPool spawnPool = PoolManager.Pools.Create("UIRoot/MessageBox");

        PrefabPool messageboxPool = new PrefabPool(PanelManager.MessageBox.GetPanel());
        messageboxPool.preloadAmount = 1;

        messageboxPool.limitInstances = true;
        messageboxPool.limitAmount = 1;

        spawnPool.CreatePrefabPool(messageboxPool);
    }

    private void InitializeFloatPanelPoolManager()
    {
        SpawnPool spawnPool = PoolManager.Pools["MessageBox"];

        PrefabPool floatPanelPool = new PrefabPool(PanelManager.FloatPanel.GetPanel());
        floatPanelPool.preloadAmount = 3;

        floatPanelPool.limitInstances = true;
        floatPanelPool.limitAmount = 3;

        spawnPool.CreatePrefabPool(floatPanelPool);
    }
}