using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// npc 实体类，继承实体基类
public class EntityNpc : Entity
{
    public EntityNpc() : base()
    {

    }

    public override void OnCreate()
    {
        base.OnCreate();

        string pathPrefab = "Assets/Res/Npc/Peasant Nolant Blue.prefab";
        mBody = ResManager.Instance.InstantiateGameObject(pathPrefab);

        OnEnable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        //mBody.transform.Rotate(new Vector3(0, 1, 0));
    }
}
