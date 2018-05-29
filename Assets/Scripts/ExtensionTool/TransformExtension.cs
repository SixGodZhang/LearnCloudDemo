using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public static class ExtensionMethod
    {
        /// <summary>
        /// 根据名称寻找子孙中的对应节点(同名第一顺位)
        /// </summary>
        /// <param name="findName">名称</param>
        /// <param name="isActiveInHierarchy">true:隐藏的不被找到(default) false:隐藏的可以被找到</param>
        /// <returns></returns>
        public static Transform FindChildWithName(this Transform source,string findName,bool isCanFindHideInHierarchy = false)
        {

            //first: 找同一层级
            for (int i = 0; i < source.childCount; i++)
            {
                Transform temp = source.GetChild(i);
                bool findFlag = isCanFindHideInHierarchy ? true : temp.gameObject.activeInHierarchy;
                if (findName.Equals(temp.name) && findFlag)
                {
                    return temp;
                }
            }

            //second:递归，找子孙
            for (int i = 0; i < source.childCount; i++)
            {
                Transform result = FindChildWithName(source.GetChild(i), findName, isCanFindHideInHierarchy);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }  
    }
}
