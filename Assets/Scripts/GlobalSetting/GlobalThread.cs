using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GlobalThread : MonoBehaviour
{
    private static Queue<Action> watingActions = null;
    private static Queue<Action> handlingActions = null;

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        GameObject global = new GameObject("GlobalThread");
        DontDestroyOnLoad(global);
        global.AddComponent<GlobalThread>();
        global.hideFlags = HideFlags.HideInHierarchy;
    }

    void Awake()
    {
        watingActions = new Queue<Action>();
        handlingActions = new Queue<Action>();
    }

    void Update()
    {
        if (handlingActions.Count == 0)
        {
            lock (watingActions)
            {
                if (watingActions.Count > 0)
                {
                    Queue<Action> tmp = handlingActions;
                    handlingActions = watingActions;
                    watingActions = tmp;
                }
            }
        }
        else
        {
            while (handlingActions.Count > 0)
            {
                Action action = handlingActions.Dequeue();
                action.Invoke();
            }
        }
    }

    public static void runOnMainThread(Action action)
    {
        lock (watingActions)
        {
            watingActions.Enqueue(action);
        }
    }
}