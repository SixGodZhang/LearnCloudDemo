using LeanCloud;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UpData : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(UpDataRole);
    }

    /// <summary>
    /// 新建数据
    /// </summary>
    private void UpDataRole()
    {
        AVObject gameScore = new AVObject("GameScore");
        gameScore["score"] = 1337;
        gameScore["playerName"] = "Neal Caffrey";
        Task saveTask = gameScore.SaveAsync();

        Debug.Log("store data end ....");
    }

    /// <summary>
    /// 查询数据
    /// </summary>
    private void QueryData()
    {
        int score;
        string playerName;
        AVQuery<AVObject> query = new AVQuery<AVObject>("GameScore");
        query.GetAsync("53706cd1e4b0d4bef5eb32ab").ContinueWith(t =>
        {
            AVObject gameScore = t.Result;//如果成功获取，t.Result将是一个合法有效的AVObject
            score = gameScore.Get<int>("score");
            playerName = gameScore.Get<string>("playerName");
        });
    }

    private void UpdateData()
    {
        var gameScore = new AVObject("GameScore")
        {
            { "score", 1338 },
            { "playerName", "Peter Burke" },
            { "cheatMode", false },
            { "skills", new List<string> { "FBI", "Agent Leader" } },
        };//创建一个全新的 GameScore 对象
        gameScore.SaveAsync().ContinueWith(t =>//第一次调用 SaveAsy`nc 是为了增加这个全新的对象
        {
            // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改 cheatMode 和 score
            // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的 playerName 不会被修改
            gameScore["cheatMode"] = true;
            gameScore["score"] = 9999;
            gameScore.SaveAsync();//第二次调用是为了把刚才修改的2个属性发送到服务端生效。
        });
    }
}