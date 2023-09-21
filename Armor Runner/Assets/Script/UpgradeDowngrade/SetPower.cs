using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SetPower : MonoBehaviour
{
    protected int powerAmount;
    protected bool isCollectable;
    [SerializeField] protected bool isNegativeAmount;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Power>().SetPower(ChangeAmount());
            SetFalse();
        }
    }

    private void SetFalse()
    {
        if(!isCollectable)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    protected abstract int ChangeAmount();

}
