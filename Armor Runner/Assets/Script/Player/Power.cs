using UnityEngine;
using System;
using Unity.VisualScripting;

public class Power : MonoBehaviour 
{
    
    public Action OnLevelChange;

    [SerializeField] private GameObject[] players = new GameObject[4];
    private int currentLevel = 1;
    public int PowerLevel()
    {
        return powerLevel;
    }
    private int powerLevel = 0;

    

    public void SetPower(int amount)
    {
        int level = powerLevel+amount;
        
        if(level>=100)
        {
            int willAdd = level - 100;
            players[currentLevel].gameObject.SetActive(false);
            currentLevel++;
            players[currentLevel].gameObject.SetActive(true);
            powerLevel = willAdd;    
        }
        else if(level < 0)
        {
            if(currentLevel==0)
            {
                 OnLevelChange?.Invoke();
                 return;
            }

            int willAdd = 100 + level;
            powerLevel = willAdd;
            players[currentLevel].gameObject.SetActive(false);
            currentLevel--;
            players[currentLevel].gameObject.SetActive(true);
        }
        else
        {
            powerLevel = level;
        }
        print(powerLevel);
        OnLevelChange?.Invoke();
    } 
}