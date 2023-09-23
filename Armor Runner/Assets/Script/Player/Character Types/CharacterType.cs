using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Character Type", menuName = "Character Type")]
public class CharacterType : ScriptableObject
{
   public string characterName;
   public int healt;
   public int damage;
}
