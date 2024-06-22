using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//实现单例模版类
public class BasetMgr <T> where T : class,new()
{
    private static T mInstance = null;

    public static T Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance=new T();
            }
            return mInstance;
        }
    }
}
