using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiaoMgr : MonoBehaviour
{ 
    public List<GameObject> m_Qiaos; 
    
    //显示
    public void ShowQiao()
    {
        for(int i=0;i<m_Qiaos.Count;i++)
        {
            if(m_Qiaos[i].gameObject.activeSelf == false)
            {
                m_Qiaos[i].SetActive(true);
                break;
            }
        }
    }
    
    //隐藏
    public void HideQiao()
    {
         for(int i=0;i<m_Qiaos.Count;i++)
        {
            if(m_Qiaos[i].gameObject.activeSelf == true)
            {
                m_Qiaos[i].SetActive(false);
                break;
            }
        }
    } 
}
