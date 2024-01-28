using UnityEngine;
using UnityEngine.SceneManagement;

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
    SCORE,
    HELPER,
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
    public GameObject scoreMenu;
    public GameObject helperMenu;



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
        profile.SetActive(false);
        scoreMenu.SetActive(false);
        helperMenu.SetActive(false);


        switch (menuType)
        {
            case MenuType.MAIN:
                mainMenu.SetActive(true);
                break;

            case MenuType.PROFIL_CREATION:
                profilCreationMenu.SetActive(true);
                break;

            case MenuType.GAME_PARAM:
                contextualText.SetActive(true);
                gameParamMenu.SetActive(true);
                break;

            case MenuType.STICKER_SCROLL:
                contextualText.SetActive(true);
                stickerScroll.SetActive(true);
                break;

            case MenuType.THE_MATCH:
                theMacthPlayerMenu.GetComponent<SwipeMatch>().switchMode(false);
                contextualText.SetActive(true);
                theMacthPlayerMenu.SetActive(true);      
                break;

            case MenuType.THE_SWIPER:
                theMacthPlayerMenu.GetComponent<SwipeMatch>().switchMode(true);
                contextualText.SetActive(true);
                theMacthPlayerMenu.SetActive(true);              
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
            case MenuType.SCORE:
                scoreMenu.SetActive(true);
                break;

            case MenuType.HELPER:
                helperMenu.SetActive(true);
                break;
        }
    }

    public void ChangeContexteText(string newtext) 
    {
        contextualText.GetComponent<ContextualManage>().ChangeContexte(newtext);
    }

    public void ResetScene() 
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
