using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//��Դ�����࣬����ģʽʵ��
public class ResManager : BasetMgr<ResManager>
{
    private enum LoadState
    {
        //����״̬
        Idle,
        //����״̬
        LoadScene,
        //������
        TickLoadSceneProgress,
    }

    private LoadState mCurrentLoadState = LoadState.Idle;
    private string mCurrentSceneName = null;
    private AsyncOperation mCurrentSceneAsyncOperation;


    public delegate void OnLoadCallBack();
    private OnLoadCallBack SceneLoadedCallback;

    public void Update()
    {
        switch (mCurrentLoadState)
        {
            case LoadState.Idle:
                break;
            case LoadState.LoadScene:
                SceneManager.sceneLoaded += SceneManager_sceneLoaded;
                mCurrentSceneAsyncOperation = SceneManager.LoadSceneAsync(mCurrentSceneName, LoadSceneMode.Single);
                if (mCurrentSceneAsyncOperation == null)
                {
                    Debug.LogError("Faild t oload scene,mCurrentSceneAsyncOperation is null");
                    mCurrentLoadState = LoadState.Idle;
                    return;
                }
                mCurrentLoadState = LoadState.TickLoadSceneProgress;
                break;
            case LoadState.TickLoadSceneProgress:
                Debug.Log("Loading scene"+mCurrentSceneName+"progress"+mCurrentSceneAsyncOperation.progress);
                break;
        }
    }



    //�첽���س���
    public void LoadSceneAsync(string name,OnLoadCallBack callBack)
    {
        //��ǰ�Ƿ����ڼ��س���
        if (mCurrentLoadState != LoadState.Idle)
        {
            Debug.LogError("One scene is loading,scene name:"+name);
            return;
        }

        mCurrentLoadState = LoadState.LoadScene;
        mCurrentSceneName = name;
        SceneLoadedCallback = callBack;
    }

    //unity �ص������ǵļ������
    public void SceneManager_sceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        mCurrentLoadState= LoadState.Idle;

        if (SceneLoadedCallback != null)
        {
            SceneLoadedCallback();
        }
    }
}
