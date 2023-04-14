using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//��Ʒ����
public enum E_ItemType
{ 
    COST,       //����Ʒ
    EquipMent   //װ��
}

[Serializable]
//��Ʒ���� 
public class ItemBase 
{
    //��������
    //0 �ɲ�   1 ���
    public int m_Type;
    //ID
    public int m_ID;

    //ͼ������
    public string m_IconName;

    //ģ������
    public string m_ModleName;
    
    //����
    public E_ItemType m_ItemType; 

    //����
    public string m_Name;

    //����
    public int m_Nums;

    //�۸�
    public int m_Price;

    //------װ����Ӧ������------
    //ͷ��-���ӱ������� ħ������
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
