using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : SetPower
{
    public void Awake() =>isCollectable = true;
    protected override int ChangeAmount()
    {
        return -40;
    }
}
