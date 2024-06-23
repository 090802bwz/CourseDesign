using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogin : MonoBehaviour
{
    public void OnLogin()
    {
        WorldManager.Instance.LoadScene("rpgpp_lt_scene_1.0");
    }
}
