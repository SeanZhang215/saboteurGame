using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//游戏中菜单栏
public class GameMenuPlane : PlaneBase
{ 
    public GameObject m_BagPlane; 

    private void Update() {
        //按B打开界面
        if(Input.GetKeyDown(KeyCode.B))
        {
             m_BagPlane.SetActive(true); 
        }
    }
}
