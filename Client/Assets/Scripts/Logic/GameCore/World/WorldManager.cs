using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : BaseMgr<WorldManager>
{
    //����״̬��
    enum LoadState
    {
        //��ʼ��״̬
        Init,
        //���س���״̬
        LoadScene,
        //����״̬
        Update,
        //�ȴ�״̬
        Wait,
    }
    private LoadState mstate;
    private string mLoadSceneName;


    //��ʼ��
    public void Init()
    {
        EnterState(LoadState.Init);
    }

    //�������
    public void Update()
    {
        if (mstate == LoadState.Init)
        {

        }
        if(mstate ==LoadState.LoadScene)
        {
            EnterState(LoadState.Wait);
            //rpgpp_lt_scene_1.0
            ResManager.Instance.LoadSceneAsync(mLoadSceneName,() =>
            {
                //�ȴ�����������ɺ󣬼�����ҵ�������
                LoadMainPlayer();
            });
        }
    }

    //��������еļ��س���
    public void LoadScene(string name)
    {
        mLoadSceneName = name;

        EnterState(LoadState.LoadScene);
    }

    //�ı䵱ǰ��״̬��
    private void EnterState(LoadState state)
    {
        mstate = state;
    }

    private void LoadMainPlayer()
    {
        GameObject mainPlayer=ResManager.Instance.InstantiateGameObject("Assets/Res/Role/Peasant Nolant Blue(Free Version).prefab");

        mainPlayer.transform.position = new Vector3(63.0f,22.25f,43.0f);
    }

}
    

