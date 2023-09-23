using System;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
   public event Action OnHealtChange;
   [SerializeField] BossType bossType;
    
    private int bossCurrentHealt;

    public int BossCurrentHealt()
    {
        return bossCurrentHealt;
    }

    private void Awake() 
    {
        bossCurrentHealt = bossType.healt;    
    }

    
    public void DecreaseHealt(int amount)
    {
        bossCurrentHealt -= amount;
        OnHealtChange?.Invoke();
        
        if(bossCurrentHealt<0)
        {
            Destroy(gameObject);
        }
    }

}
