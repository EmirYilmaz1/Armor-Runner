using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : SetPower
{
    private void Awake() => isCollectable = true; 

    protected override int ChangeAmount()
    {
        if(isNegativeAmount)
        {
            return -5;
        }
        else
        {
            return 5;
        }
    }

}
