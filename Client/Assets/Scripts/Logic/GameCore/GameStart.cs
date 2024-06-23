using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // 游戏运行期间使用保留的GameObject
    private GameObject mGo;


    // 游戏启动运行开始的地方
    void Start()
    {
        Debug.Log("Game Start");
        mGo = gameObject;

        // 切换场景加载时不销毁
        DontDestroyOnLoad(mGo);

        try
        {
            // 场景世界初始化
            WorldManager.Instance.Init();

            EntityManager.Instance.Init();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }


    // 游戏循环
    void Update()
    {
        try
        {
            ResManager.Instance.Update();

            WorldManager.Instance.Update();

            EntityManager.Instance.Update();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }

    // 在update 后更新
    private void LateUpdate()
    {
        try
        {
            EntityManager.Instance.LateUpdate();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }


    // 以固定频率更新
    private void FixedUpdate()
    {
        try
        {

        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }


    // 游戏退出
    // 作用是，退出游戏时销毁资源
    private void OnApplicationQuit()
    {
        Debug.Log("Game Quit");

        try
        {
            EntityManager.Instance.Exit();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }
}
