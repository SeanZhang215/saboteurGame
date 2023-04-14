using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����
public class Bag : MonoBehaviour
{
    //���������Ʒ�ü���-����װ�� ���� ҩƷ
    public List<ItemBase> m_ItemList = new List<ItemBase>(); 

    public BagPlane bagplen;
    //���
    public int m_Gold;

    private void Start()
    {
    
        InitBagData();
    } 
    
    //��ʼ����������
    public void InitBagData()
    {
        
    }

    //ʹ����Ʒ
    public void UseItem(int _index)
    {
        Debug.Log("_index" + _index);
        ItemBase item =  m_ItemList[_index];

        //������������ƷĿǰ���������ڽ�ɫ �Ժ���ܻ���ݱ�ǩ ȥ�ı�Ŀ��
        item.UseItem(gameObject);
    }

    public void UseItem(ItemBase _item)
    {

    }

    //�����Ʒ
    public void AddItem(ItemBase _item)
    {
        m_ItemList.Add(_item);
    }

   //ɾ����Ʒ-��������
   public void ReMoveItem(int _index)
    {
        m_ItemList.RemoveAt(_index);
    }

    //ɾ����Ʒ-���ݶ���
    public void ReMoveItem(ItemBase _item)
    {
        m_ItemList.Remove(_item); 
    }

    //���������Ʒ
    public void ClearBag()
    {
        m_ItemList.Clear();
    }
}
