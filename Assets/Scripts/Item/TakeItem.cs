using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : CCHTMonoBehaviour
{
    [SerializeField] protected float dropChanceItem = 60f;
    public float DropChanceItem => dropChanceItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.TakeIItem();
        }
    }

    protected void TakeIItem()
    {
        Debug.Log("Đã nhặt vật phẩm");
        //Destroy(transform.parent.gameObject);
        this.transform.gameObject.SetActive(false);
    }
}
