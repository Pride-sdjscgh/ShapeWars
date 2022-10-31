using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionofGOaftertime : MonoBehaviour
{
   public float killTime;

   private void Start()
   {  
      if(this != null)
      {
         Destroy(this.gameObject, killTime);
      }
   }
  
}
