using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIName : MonoBehaviour
{
    public Text Name;

    private string mName;


    void Update()
    {
        // 设置ui的朝向为摄像机的朝向
        transform.forward = Camera.main.transform.forward;


        Name.text = mName;
    }


    // 设置名字
    public void SetName(string name)
    {
        mName = name;
    }
}
