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
    MESSAGE_PRETENDANT,
    MESSAGE_MATCH,
    MESSAGE_END,
    PROFIL,
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
    public GameObject messageMenuPretendant;
    public GameObject messageMenuMatch;
    public GameObject messageMenuEnd;
    public GameObject profile;


    public static UIManager instance;

    [HideInInspector] public string swiper;

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
        messageMenuPretendant.SetActive(false);
        messageMenuMatch.SetActive(false);
        messageMenuEnd.SetActive(false);
        profile.SetActive(true);

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
                theMacthPlayerMenu.SetActive(true);
                theMacthPlayerMenu.GetComponent<SwipeMatch>().switchMode(false);
                break;

            case MenuType.THE_SWIPER:
                contextualText.SetActive(true);
                //contextualText.GetComponent<ContextualManage>().ChangeContexte($"Au tour de {swiper} !");
                theMacthPlayerMenu.SetActive(true);
                theMacthPlayerMenu.GetComponent<SwipeMatch>().switchMode(true);
                break;

            case MenuType.CATH_PHRASE:
                contextualText.SetActive(true);
                cathPhrase.SetActive(true);
                break;

            case MenuType.MESSAGE_PRETENDANT: 
                contextualText.SetActive(true);
                messageMenuPretendant.SetActive(true);
                break;

            case MenuType.MESSAGE_MATCH:
                contextualText.SetActive(true);
                messageMenuMatch.SetActive(true);
                break;

            case MenuType.MESSAGE_END:
                contextualText.SetActive(true);
                messageMenuEnd.SetActive(true);
                break;

            case MenuType.PROFIL:
                profile.SetActive(true);
                break;
        }
    }

    public void ChangeContexteText(string newtext) 
    {
        contextualText.GetComponent<ContextualManage>().ChangeContexte(newtext);
    }
}
