using UnityEngine;

public class Fighter : MonoBehaviour 
{
    int damage;
    Boss boss;
    private void Start() 
    {
       damage = GetComponent<Power>().CharacterType().damage;
        boss = FindObjectOfType<Boss>();
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            boss.DecreaseHealt(damage);
        }    
    }
}