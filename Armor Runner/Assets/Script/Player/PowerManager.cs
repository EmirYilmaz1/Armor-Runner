using UnityEngine;
using System;
using Unity.VisualScripting;

public class PowerManager : MonoBehaviour 
{
    
    public event Action OnLevelChange;
    public event Action OnCharacterChange;

    [SerializeField] ParticleSystem upgradeWFX;
    [SerializeField] ParticleSystem downgradeVFX;
    
    [SerializeField] private GameObject[] players = new GameObject[4];
    private int currentCharacterLevel = 1;

    private CharacterType characterType;
    public CharacterType CharacterType()
    {
        return characterType;
    }

    private int currentExperience = 0;
    public int CurrentExperience()
    {
        return currentExperience;
    }

    private GameObject currentPlayer;

    private void Awake() 
    {
        currentPlayer = Instantiate(players[currentCharacterLevel], transform);
        characterType = players[currentCharacterLevel].GetComponent<CharacterInfo>().CharacterType();    
    }
    

    public void SetPower(int amount)
    {
        int level = currentExperience+amount;
        
        if(level>=100)
        {
            int willAdd = level - 100;
            currentExperience = willAdd;

            SetNewCharacter(true);
        }
        else if(level < 0)
        {
            if(currentCharacterLevel==0)
            {
                return;
            }

            int willAdd = 100 + level;
            currentExperience = willAdd;
            
            SetNewCharacter(false);
           
        }
        else
        {
            currentExperience = level;
            OnLevelChange?.Invoke();
        }
    }

    private void SetNewCharacter(bool isUpgrade)
    {
        Destroy(currentPlayer);

        if(isUpgrade)
        {
            currentCharacterLevel++;
            Instantiate(upgradeWFX, transform);
        }
        else if(!isUpgrade)
        {
            currentCharacterLevel--;
            Instantiate(downgradeVFX, transform);
        }

        currentPlayer = Instantiate(players[currentCharacterLevel], transform);
        characterType = players[currentCharacterLevel].GetComponent<CharacterInfo>().CharacterType();

        OnLevelChange?.Invoke();
        OnCharacterChange?.Invoke();
    }
}