using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Main mainMenu;
    public Button helper;

    UIManager UIM;

    [Serializable]
    public class Main
    {
        public Button play;
    }

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
        mainMenu.play.onClick.AddListener(() => UIM.SetActiveMenu(MenuType.PROFIL_CREATION));
        helper.onClick.AddListener(() => UIM.SetActiveMenu(MenuType.HELPER));
    }
}
