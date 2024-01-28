using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndMessageinfo : MonoBehaviour
{
    public TextMeshProUGUI display;
    public Toggle toggle;

    GameManager GM;

    private void Start()
    {
        GM = GameManager.instance;
        toggle.onValueChanged.AddListener(delegate { CheckIsOn(); });
        if (toggle.isOn)
        {
            GM.playersRepondSelect = display.text;
        }
    }

    void CheckIsOn() 
    {
        if (toggle.isOn)
        {
            GM.playersRepondSelect = display.text;
        }
    }
}
