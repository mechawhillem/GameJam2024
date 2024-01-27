using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Main mainMenu;
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
    /// Lie les events lié au menu principale
    /// </summary>
    void Bind()
    {
        mainMenu.play.onClick.AddListener(() => UIM.SetActiveMenu(MenuType.PROFIL_CREATION));
    }
}
