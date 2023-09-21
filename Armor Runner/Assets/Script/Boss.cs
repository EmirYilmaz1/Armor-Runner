using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Action OnHealtChange;
    public int healt = 100;
    public void DecreaseHealt(int amount)
    {
        print("uuu");
        healt -= amount;
        OnHealtChange?.Invoke();
        if(healt<0)
        {
            Destroy(gameObject);
        }
    }
}
