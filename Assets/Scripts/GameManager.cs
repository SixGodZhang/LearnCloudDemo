using Assets;
using LeanCloud;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform testGo;
    private string childName = "GameObject";

	void Start () {
        PanelManager.LoginPanel.Show();
        //Debug.Log("child count : "+ testGo.FindChildWithName(childName).childCount);

    }




    /// <summary>
    /// 注册新用户
    /// </summary>
    void Singup()
    {
        var user = new AVUser();
        user.Username = SystemInfo.deviceUniqueIdentifier;  //唯一识别码
        user.Password = SystemInfo.deviceUniqueIdentifier.Substring(2, 14);
        user["testA"] = "aaa";
        user.SignUpAsync().ContinueWith(t =>
        {
            if (t.IsFaulted || t.IsCanceled)
            {
                Debug.Log(t.Exception.Message);
            }
            else
            {
                Debug.Log(t.Exception.Message);
                string uid = user.ObjectId;
            }
        });

    }

    /// <summary>
    /// 登录已有账户
    /// </summary>
    void Login(string username,string password)
    {
        AVUser.LogInAsync(username, password).ContinueWith(t => {
            if (t.IsFaulted || t.IsCanceled)
            {
                Debug.Log(t.Exception.Message);
            }
            else
            {
                string str = AVUser.CurrentUser.Get<string>("Username");
                Debug.Log(str);
            }
        });
    }

    /// <summary>
    /// 数据常用方法
    /// </summary>
    void Updata()
    {
        //updata data
        AVObject ao = AVUser.CurrentUser;
        ao["testA"] = "a5";
        //add remove
        ao.Add("testB", "b1");
        ao.Remove("testA");
        //link focusType 使用链接对象
        AVObject sceneData = new AVObject("GirType");
        sceneData["typeName"] = "class1";
        ao["SceneData"] = sceneData;
        //Async
        ao.SaveAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    void LoadFoucsType(){
    //loadd focusType
    AVObject theSceneData = AVUser.CurrentUser.Get<AVObject> ("SceneData");
    Task<AVObject> fetchTask = theSceneData.FetchIfNeededAsync ();
    Debug.Log (theSceneData.Get<string> ("typeName"));
    }


}
