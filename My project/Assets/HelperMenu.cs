using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HelperMenu : MonoBehaviour
{
    public Button Close;

    UIManager UIM;
    // Start is called before the first frame update

    private void Start()
    {
        UIM = UIManager.instance;
        Bind();
    }

    /// <summary>
    /// Lie les events li? au menu principale
    /// </summary>
    void Bind()
    {
        Close.onClick.AddListener(() => UIM.SetActiveMenu(MenuType.MAIN));
        
    }
}
