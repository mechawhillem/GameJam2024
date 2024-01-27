using UnityEngine;

public enum MenuType
{
    MAIN,
    PROFIL_CREATION,
    GAME_PARAM,
}

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject profilCreationMenu;
    public GameObject gameParamMenu;

    public static UIManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

        SetActiveMenu(MenuType.MAIN);
    }

    /// <summary>
    /// Définis le menu a activer (désactive tout les autres)
    /// </summary>
    /// <param name="menuType">Le type de menu a activer</param>
    public void SetActiveMenu(MenuType menuType) 
    {
        switch (menuType) 
        {
            case MenuType.MAIN:
                mainMenu.SetActive(true);
                profilCreationMenu.SetActive(false);
                gameParamMenu.SetActive(false);
                break;

            case MenuType.PROFIL_CREATION:
                mainMenu.SetActive(false);
                profilCreationMenu.SetActive(true);
                gameParamMenu.SetActive(false);
                break;

            case MenuType.GAME_PARAM:
                mainMenu.SetActive(false);
                profilCreationMenu.SetActive(false);
                gameParamMenu.SetActive(true);
                break;
        }
    } 
}
