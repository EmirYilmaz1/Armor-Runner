using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : SetPower
{   private void Awake()  => isCollectable = false;
    protected override int ChangeAmount()
    {
        if(isNegativeAmount)
        {
            return -30;
        }
        else
        {
            return 30;
        }
    }
}
