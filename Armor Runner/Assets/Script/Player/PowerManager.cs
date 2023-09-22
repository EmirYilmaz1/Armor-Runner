using UnityEngine;
using System;
using Unity.VisualScripting;

public class PowerManager : MonoBehaviour 
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

    private GameObject currentPlayer;

    private void Awake() 
    {
        currentPlayer = Instantiate(players[currentLevel], transform);
        characterType = players[currentLevel].GetComponent<CharacterInfo>().CharacterType();    
    }
    

    public void SetPower(int amount)
    {
        int level = powerLevel+amount;
        
        if(level>=100)
        {
            int willAdd = level - 100;
            powerLevel = willAdd;

            SetNewCharacter(true);
        }
        else if(level < 0)
        {
            if(currentLevel==0)
            {
                return;
            }

            int willAdd = 100 + level;
            powerLevel = willAdd;
            
            SetNewCharacter(false);
           
        }
        else
        {
            powerLevel = level;
            OnLevelChange?.Invoke();
        }
    }

    private void SetNewCharacter(bool isUpgrade)
    {
        Destroy(currentPlayer);

        if(isUpgrade)
        {
            currentLevel++;
            Instantiate(upgradeWFX, transform);
        }
        else if(!isUpgrade)
        {
            currentLevel--;
            Instantiate(downgradeVFX, transform);
        }

        currentPlayer = Instantiate(players[currentLevel], transform);
        characterType = players[currentLevel].GetComponent<CharacterInfo>().CharacterType();

        OnLevelChange?.Invoke();
        OnCharacterChange?.Invoke();
    }
}