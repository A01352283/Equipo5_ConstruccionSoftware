using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextFade : MonoBehaviour
// Scripts that make the instructions fade after a certain time
{
public Text canvasText1;
   void Start ()
   {
      Invoke("DisableText", 10f);
   }
   void DisableText()
   {
      canvasText1.enabled = false;
   }
}
