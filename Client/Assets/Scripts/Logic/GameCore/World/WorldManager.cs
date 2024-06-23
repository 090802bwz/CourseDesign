using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : BaseMgr<WorldManager>
{
    // 场景状态机
    enum LoadState
    {
        // 初始化状态
        Init,
        // 加载场景状态
        LoadScene,
        // 更新状态
        Update,
        // 等待状态
        Wait,
    }
    private LoadState mState;
    private string mLoadSceneName;


    private long mObjectID;

    // 初始化
    public void Init()
    {
        mObjectID = 0;
        EnterState(LoadState.Init);
    }


    // 世界更新
    public void Update()
    {
        if (mState == LoadState.Init)
        {

        }

        if (mState == LoadState.LoadScene)
        {
            EnterState(LoadState.Wait);
            // "rpgpp_lt_scene_1.0"
            ResManager.Instance.LoadSceneAsync(mLoadSceneName, () =>
            {
                // 等待场景加载完成后，加载玩家到场景中
                LoadMainPlayer();

                LoadNpc();
            });
            //ResManager.Instance.LoadScene(mLoadSceneName);
        }
    }


    // 世界管理中的加载场景
    public void LoadScene(string name)
    {
        mLoadSceneName = name;

        EnterState(LoadState.LoadScene);
    }


    // 改变当前的状态机
    private void EnterState(LoadState state)
    {
        mState = state;
    }

    private void LoadMainPlayer()
    {
        Vector3 mainPlayerPos = new Vector3(63.0f, 22.23f, 43.0f);
        EntityMainPlayer mainPlayer = (EntityMainPlayer)EntityManager.Instance.CreateEntity(eEntityType.PLAYER_MAIN, GeneraterObjectID(), mainPlayerPos);
        //mainPlayer.PlayAnimator("metarig|Idle");
        //mainPlayer.PlayAnimator("metarig|Walk");
        mainPlayer.PlayerAnimation("WK_heavy_infantry_05_combat_idle");
    }


    // 加载场景中的npc
    private void LoadNpc()
    {
        Vector3 npcPostion = new Vector3(56.53f, 22.24f, 43.8f);
        EntityNpc npc = (EntityNpc)EntityManager.Instance.CreateEntity(eEntityType.NPC, GeneraterObjectID(), npcPostion);
        npc.PlayAnimator("metarig|Idle");
        npc.SetForward(new Vector3(90, 0, 0));
        npc.SetName("神秘商人");
    }


    // 生成物体的id
    private long GeneraterObjectID()
    {
        mObjectID++;
        return mObjectID;
    }
}
