using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
   [SerializeField] CharacterType characterType;
   public CharacterType CharacterType()
   {
     return characterType;
   }
}
