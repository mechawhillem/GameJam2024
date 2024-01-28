using UnityEngine;

public enum MenuType
{
    MAIN,
    PROFIL_CREATION,
    GAME_PARAM,
    STICKER_SCROLL,
    THE_MATCH,
    THE_SWIPER,
    CATH_PHRASE,
}

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject profilCreationMenu;
    public GameObject contextualText;
    public GameObject stickerScroll;
    public GameObject gameParamMenu;
    public GameObject theMacthPlayerMenu;
    public GameObject cathPhrase;

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
        gameParamMenu.SetActive(false);
        contextualText.SetActive(false);
        stickerScroll.SetActive(false);
        theMacthPlayerMenu.SetActive(false);
        cathPhrase.SetActive(false);

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

            case MenuType.THE_MATCH:
                contextualText.SetActive(true);
                contextualText.GetComponent<ContextualManage>().ChangeContexte($"{matchname} est le match");
                theMacthPlayerMenu.SetActive(true);
                theMacthPlayerMenu.GetComponent<SwipeMatch>().switchMode(false);
                break;

            case MenuType.THE_SWIPER:
                contextualText.SetActive(true);
                contextualText.GetComponent<ContextualManage>().ChangeContexte($"Au tour de {swiper} !");
                theMacthPlayerMenu.SetActive(true);
                theMacthPlayerMenu.GetComponent<SwipeMatch>().switchMode(true);
                break;

            case MenuType.CATH_PHRASE:
                contextualText.SetActive(true);
                cathPhrase.SetActive(true);
                break;
        }
    }
}
