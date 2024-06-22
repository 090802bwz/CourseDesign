using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    //游戏运行期间始终保留的GameObject
    private GameObject mGo;

    //游戏启动运行开始的地方
    void Start()
    {
        Debug.Log("Game Start");
        mGo = gameObject;

        //切换场景加载时不销毁
        DontDestroyOnLoad(mGo);

        try
        {

        }catch(Exception e)
        {
            Debug.LogException(e);
        }

        ResManager.Instance.LoadSceneAsync("rpgpp_lt_scene_1.0",null);
    }

    //游戏循环
    void Update()
    {
        try
        {
            ResManager.Instance.Update();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    //游戏退出
    //退出游戏时销毁资源
    private void OnApplicationQuit()
    {
        Debug.Log("Game Quit");
        try
        {

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

}
