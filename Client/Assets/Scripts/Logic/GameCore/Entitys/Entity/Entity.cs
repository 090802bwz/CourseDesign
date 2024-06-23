using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 所有实体的基类，游戏中所有的物体都继承此类
public class Entity 
{
    // 实体的类型
    protected eEntityType mEntityType;

    // 实体的唯一Id
    private long mId;

    // 实体的可见模型
    public GameObject mBody;

    public void SetID(long id)
    {
        mId = id;
    }

    public long GetID()
    {
        return mId;
    }


    // 设置实体的名字
    public void SetName(string name)
    {
        GameObject nameBar = mBody.transform.Find("NameBar").gameObject;
        if (nameBar == null)
        {
            return;
        }

        UIName uiName = nameBar.GetComponent<UIName>();
        if (uiName == null)
        {
            return;
        }
        uiName.SetName(name);
    }

    // 设置实体的位置坐标
    public void SetPosition(Vector3 position)
    {
        mBody.transform.position = position;
    }


    // 设置实体的朝向
    public void SetForward(Vector3 forward)
    {
        mBody.transform.forward = forward;
    }


    // 播放实体的动作
    public void PlayAnimator(string state)
    {
        Animator animator = mBody.GetComponent<Animator>();
        if (animator == null)
        {
            return;
        }

        animator.Play(state);
    }


    // 使用animation的方式播放动画
    public void PlayerAnimation(string state)
    {
        Animation animation = mBody.GetComponent<Animation>();
        if (animation == null)
        {
            return;
        }

        animation.CrossFade(state);
    }


    // 当实体创建出来后调用
    public virtual void OnCreate()
    {

    }


    // 当销毁一个实体时调用
    public virtual void OnDestory()
    {

    }

    // 实体启用　
    public virtual void OnEnable()
    {

    }


    // 禁用实体
    public virtual void OnDisable()
    {

    }


    // 实体更新
    public virtual void OnUpdate(float deltaTime)
    {

    }


    public virtual void OnLateUpdate(float deltaTime)
    {

    }
}
