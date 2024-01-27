using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public MainMenu mainMenu;
    public ProfilCreationMenu profilCreationMenu;
    public GameParamMenu gameParamMenu;

    enum MenuType 
    {
        MAIN,
        PROFIL_CREATION,
    }

    [Serializable]
    public class MainMenu
    {
        public GameObject menu;
        public Button play;
    }

    [Serializable]
    public class ProfilCreationMenu
    {
        public GameObject menu;
        public TextMeshProUGUI playerName;
        public Button Next;
        public CharacterSelection characterSelection;

        [Serializable]
        public class CharacterSelection 
        {
            public CharacterPersonalisation hair;
            public CharacterPersonalisation eyes;
            public CharacterPersonalisation nose;
            public CharacterPersonalisation mouth;
            public CharacterPersonalisation clothe;

            [Serializable]
            public class CharacterPersonalisation
            {
                public CharacterAssets assets;
                public Button next;
                public Button before;
                public Image image; 
            }
        }

        [Serializable]
        public class HobbysSelction 
        {
            public GameObject menu;
            public HobbysAssets hobbysAssets;
            public Button firstHobbys;
            public Button secondHobbys;
            public Button thirdHobbys;
        }
    }

    [Serializable]
    public class GameParamMenu
    {
        public GameObject menu;
        public Button back;
        public Button play;
        public Button addPlayer;
        public RoundParam roundParam;

        [Serializable]
        public class RoundParam 
        {
            public Button addRound;
            public Button removeRound;
            public TextMeshProUGUI nmbOfRound;
        }
    }

    void Awake()
    {
        BindAllMenu();
        SetActiveMenu(MenuType.MAIN);
    }

    /// <summary>
    /// Définis le menu a activer (désactive tout les autres)
    /// </summary>
    /// <param name="menuType">Le type de menu a activer</param>
    void SetActiveMenu(MenuType menuType) 
    {
        switch (menuType) 
        {
            case MenuType.MAIN:
                mainMenu.menu.SetActive(true);
                profilCreationMenu.menu.SetActive(false);
                break;

            case MenuType.PROFIL_CREATION:
                mainMenu.menu.SetActive(false);
                profilCreationMenu.menu.SetActive(true);
                break;
        }
    } 

    /// <summary>
    /// Lie tout les events au différents bouton de chaque menu
    /// </summary>
    void BindAllMenu() 
    {
        BindMainMenu();
    }

    /// <summary>
    /// Lie les events lié au menu principale
    /// </summary>
    void BindMainMenu() 
    {
        mainMenu.play.onClick.AddListener(()=> SetActiveMenu(MenuType.PROFIL_CREATION));
    }

}
