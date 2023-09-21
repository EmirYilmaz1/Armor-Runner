using UnityEngine;
using System;
using Unity.VisualScripting;

public class Power : MonoBehaviour 
{
    
    public Action OnLevelChange;
    public Action OnCharacterChange;

    [SerializeField] ParticleSystem upgradeWFX;
    [SerializeField] ParticleSystem downgradeVFX;
    
    [SerializeField] private GameObject[] players = new GameObject[4];
    private int currentLevel = 1;

    private CharacterType characterType;
    public CharacterType CharacterType()
    {
        return characterType;
    }

    private int powerLevel = 0;
    public int PowerLevel()
    {
        return powerLevel;
    }

    private void Awake() 
    {
        characterType = players[currentLevel].GetComponent<CharacterInfo>().CharacterType();    
    }
    

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
            upgradeWFX.Play();
            characterType = players[currentLevel].GetComponent<CharacterInfo>().CharacterType();
            OnCharacterChange?.Invoke();
        }
        else if(level < 0)
        {
            if(currentLevel==0)
            {
                 return;
            }

            int willAdd = 100 + level;
            powerLevel = willAdd;
            players[currentLevel].gameObject.SetActive(false);
            currentLevel--;
            downgradeVFX.Play();
            players[currentLevel].gameObject.SetActive(true);
            characterType = players[currentLevel].GetComponent<CharacterInfo>().CharacterType();
            OnCharacterChange?.Invoke();
        }
        else
        {
            powerLevel = level;
        }
        OnLevelChange?.Invoke();
    } 
}