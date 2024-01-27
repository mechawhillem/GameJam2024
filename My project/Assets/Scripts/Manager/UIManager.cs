using UnityEngine;

public enum MenuType
{
    MAIN,
    PROFIL_CREATION,
    GAME_PARAM,
    STICKER_SCROLL,

}

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject profilCreationMenu;
    public GameObject contextualText;
    public GameObject stickerScroll;
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
    /// D�finis le menu a activer (d�sactive tout les autres)
    /// </summary>
    /// <param name="menuType">Le type de menu a activer</param>
    public void SetActiveMenu(MenuType menuType) 
    {
            mainMenu.SetActive(false);
            profilCreationMenu.SetActive(false);
            //gameParamMenu.SetActive(false);
            contextualText.SetActive(false);
            stickerScroll.SetActive(false);
        switch (menuType) 
        {
            case MenuType.MAIN:
                mainMenu.SetActive(true);
                break;

            case MenuType.PROFIL_CREATION:
                profilCreationMenu.SetActive(true);
                break;

            case MenuType.GAME_PARAM:
                gameParamMenu.SetActive(true);
                break;
            case MenuType.STICKER_SCROLL:
                contextualText.SetActive(true);
                stickerScroll.SetActive(true);
                break;
        }
    } 
}
