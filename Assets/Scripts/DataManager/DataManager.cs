using LeanCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public class DataManager
    {
        public static Dictionary<DataTable, string> TableMapClass = new Dictionary<DataTable, string>()
        {
            //{ DataTable.ACCOUNT,Account},
        };

        /// <summary>
        /// 查询一张表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task QueryData<T>() where T : AVObject
        {
            var query = new AVQuery<T>();
            return query.FindAsync().ContinueWith(t =>
            {
                T first = t.Result.FirstOrDefault();
                PanelManager.MessageBox.Show(first.ToString());
            });
        }

        public static Task SaveData<T>(T data)where T:AVObject
        {
            return data.SaveAsync();
        }

        /// <summary>
        /// 存储数据
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="data">数据</param>
        public static Task StorageData(DataTable table, Dictionary<string, string> data)
        {
            AVObject gameScore = new AVObject(table.ToString());
            foreach (var key in data.Keys)
            {
                gameScore[key] = data[key];
            }
            Task saveTask = gameScore.SaveAsync();

            return saveTask;
        }

        /// <summary>
        /// 根据ID查询，此方法不适合即时查询(适用于静态数据)
        /// </summary>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void QuerySingleDataByID(DataTable table,string id)
        {
            AVQuery<AVObject> query = new AVQuery<AVObject>(table.ToString());
            AVObject dataObject = null;
            query.GetAsync(id).ContinueWith(t =>
            {
                dataObject = t.Result;//如果成功获取，t.Result将是一个合法有效的AVObject
                //acc.UserName = dataObject.Get<string>(Account.UserName.ToString());
                //acc.Password = dataObject.Get<string>(Account.Password.ToString());
                //acc.PhoneNumber = dataObject.Get<string>(Account.PhoneNumber.ToString());
            });
        }
    }
}