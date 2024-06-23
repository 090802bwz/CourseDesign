using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 主角实体，继承实体基类
public class EntityMainPlayer : Entity
{
    public EntityMainPlayer() :base()
    {

    }

    public override void OnCreate()
    {
        base.OnCreate();

        string pathPrefab = "Assets/Res/Role/ToonRTS_demo_Knight.prefab";
        mBody = ResManager.Instance.InstantiateGameObject(pathPrefab);

        OnEnable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }
}
