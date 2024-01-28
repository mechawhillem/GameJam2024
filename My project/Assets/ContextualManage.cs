using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ContextualManage : MonoBehaviour
{
    public TextMeshProUGUI contexte;
    // Start is called before the first frame update
    public void ChangeContexte(string txt){
        contexte.text = txt;
    }
}
