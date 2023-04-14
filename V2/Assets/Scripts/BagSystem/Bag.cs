using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//背包
public class Bag : MonoBehaviour
{
    //存放所有物品得集合-包括装备 武器 药品
    public List<ItemBase> m_ItemList = new List<ItemBase>(); 

    public BagPlane bagplen;
    //金币
    public int m_Gold;

    private void Start()
    {
    
        InitBagData();
    } 
    
    //初始化背包数据
    public void InitBagData()
    {
        
    }

    //使用物品
    public void UseItem(int _index)
    {
        Debug.Log("_index" + _index);
        ItemBase item =  m_ItemList[_index];

        //这里武器和物品目前都是适用于角色 以后可能会根据标签 去改变目标
        item.UseItem(gameObject);
    }

    public void UseItem(ItemBase _item)
    {

    }

    //添加物品
    public void AddItem(ItemBase _item)
    {
        m_ItemList.Add(_item);
    }

   //删除物品-根据索引
   public void ReMoveItem(int _index)
    {
        m_ItemList.RemoveAt(_index);
    }

    //删除物品-根据对象
    public void ReMoveItem(ItemBase _item)
    {
        m_ItemList.Remove(_item); 
    }

    //清空所有物品
    public void ClearBag()
    {
        m_ItemList.Clear();
    }
}
