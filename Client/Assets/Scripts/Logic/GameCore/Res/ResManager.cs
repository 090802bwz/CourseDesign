using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//��Դ�����࣬����ģʽʵ��
public class ResManager : BaseMgr<ResManager>
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
                //ͨ���ص���ί�У��ķ�ʽ�������ǣ������������
                SceneManager.sceneLoaded += SceneManager_sceneLoaded;

                //ͨ���첽�ķ�ʽ���س���
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

    //public void LoadScene(string name)
    //{
    //    //ͬ�����س���
    //    SceneManager.LoadScene(name);
    //}

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

    //������Դ
    public UnityEngine.Object LoadResource(string resPath)
    {
#if UNITY_EDITOR
        //ֻ����unity�е�editor�µ���Դ���ط�ʽ
        UnityEngine.Object obj =UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(resPath);
        return obj;
#else
        //�������ط�ʽ
#endif
    }

    //ʵ������ʾһ����Դ
    public GameObject InstantiateGameObject(string resPath)
    {
        GameObject obj=LoadResource(resPath) as GameObject;
        if (obj!=null)
        {
            //ʵ������Դ
            GameObject go=GameObject.Instantiate(obj);
            if (go==null)
            {
                Debug.LogError("game instantiate failed"+resPath);
                return null;
            }

            //��ʾ��Դ
            go.SetActive(true);
            return go;
        }
        else
        {
            return null;
        }
    }
}
