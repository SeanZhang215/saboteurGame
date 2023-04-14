using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPlane : PlaneBase
{
    public Sprite m1;
     public Sprite m2;
    
    //物品UI资源
    public GameObject UIItemRes;

    //返回按钮
    public Button m_ReturnBtn;

    //存放物品UI的列表
    public List<GameObject> m_ItemUiList = new List<GameObject>();

    //存放物品root
    public Transform m_BagRoot;
    
    private void Start() {
        m_ReturnBtn.onClick.AddListener(()=>{
            gameObject.SetActive(false);
        });
    }

    private void OnEnable() 
    { 
        UpdataInfor(GameObject.FindWithTag("Player").GetComponent<Bag>());
    } 

    //背包UI信息更新
    public void UpdataInfor(Bag _bag)
    {   
        //清空物品UI
        for(int i=0;i<m_ItemUiList.Count;i++)
        {
            m_ItemUiList[i].GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Destroy(m_ItemUiList[i]);
        }
        m_ItemUiList.Clear();

        //更新背包内容
        for(int i=0;i<_bag.m_ItemList.Count;i++)
        {
            //创建物品UI
            GameObject itemUI = GameObject.Instantiate(UIItemRes);
            itemUI.transform.SetParent(m_BagRoot,false);

            if(_bag.m_ItemList[i].m_Type == 0)
            {
                  itemUI.transform.GetChild(0).GetComponent<Text>().text = "拆";
                  itemUI.GetComponent<Image>().sprite =  m1;
            }
               
            else if(_bag.m_ItemList[i].m_Type == 1)
            {
                 itemUI.transform.GetChild(0).GetComponent<Text>().text = "增";
                   itemUI.GetComponent<Image>().sprite =  m2;
            }
                 
                  ItemBase item = _bag.m_ItemList[i];
            //同时为按钮增加监听
            itemUI.GetComponent<Button>().onClick.AddListener(()=>{
                Debug.Log("哈哈哈"); 
                item.UseItem(_bag.gameObject); 
                
            });

            //把ITEMUI增加到列表中
            m_ItemUiList.Add(itemUI);
            itemUI = null;
        } 
    }  
}
