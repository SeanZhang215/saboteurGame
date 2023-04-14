using System.Collections;
using System.Collections.Generic;
using UnityEngine;  


public class Card : ItemBase
{
     

    public override void UseItem(GameObject m_Target)
    {
        QiaoMgr qiao = GameObject.Find("qiao").GetComponent<QiaoMgr>();
         Debug.Log("使用卡牌"); 
         switch(m_Type)
         {
            case 0: //拆
                qiao.HideQiao();
                break;
            case 1: //曾
                qiao.ShowQiao();
                break;
         }

        m_Target.GetComponent<Bag>().ReMoveItem(this);
        m_Target.GetComponent<Bag>().bagplen.UpdataInfor( m_Target.GetComponent<Bag>());

    }
}
