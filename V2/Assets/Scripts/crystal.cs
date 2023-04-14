using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal : MonoBehaviour
{
    public GameObject m_Target;

    private void OnDestroy() {
        if(m_Target.tag == "Player")
        {   
            int type = Random.Range(0,2);
            Debug.Log("卡牌类型：" + type);
            Card card = new Card();
            card.m_Type = type;
            GameObject.FindWithTag("Player").GetComponent<Bag>().AddItem(card);
        }
       
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player")
        {
            m_Target = other.gameObject;
        }
    }
}
