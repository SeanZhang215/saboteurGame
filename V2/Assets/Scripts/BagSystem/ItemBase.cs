using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//物品类型
public enum E_ItemType
{ 
    COST,       //消耗品
    EquipMent   //装备
}

[Serializable]
//物品基类 
public class ItemBase 
{
    //卡牌类型
    //0 可拆   1 添加
    public int m_Type;
    //ID
    public int m_ID;

    //图标名称
    public string m_IconName;

    //模型名称
    public string m_ModleName;
    
    //类型
    public E_ItemType m_ItemType; 

    //名称
    public string m_Name;

    //个数
    public int m_Nums;

    //价格
    public int m_Price;

    //------装备对应得属性------
    //头部-增加暴击几率 魔法防御
    public float m_AddRate; 
    public float m_AddHp;
    public float m_AddMp; 
    public float m_AddAttackSpeed; 
    public float m_AddMagicDefind;
    public float m_AddPhysicDefind; 
    public float m_AddPhysicAtack;
    public float m_AddMgicAttack; 

    public virtual void UseItem(GameObject m_Target) { }  
}
