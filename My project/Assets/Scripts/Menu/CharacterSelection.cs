using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public ProfilCreationMenu profilCreationMenu;

    Image selectedImage = null;

    GameManager GM;
    UIManager UIM;

    [Serializable]
    public class ProfilCreationMenu
    {
        public TextMeshProUGUI playerName;
        public Button next;
        public CharacterParts characterSelection;
        public HobbysSelection hobbysSelection;

        [Serializable]
        public class CharacterParts
        {
            public Part hair;
            public Part eyes;
            public Part nose;
            public Part mouth;
            public Part clothe;

            [Serializable]
            public class Part
            {
                [HideInInspector] public int index = 0;
                public CharacterAssets assets;
                public Button next;
                public Button before;
                public Image image;
            }
        }

        [Serializable]
        public class HobbysSelection
        {
            public HobbysAssets hobbysAssets;
            public Button firstHobbys;
            [HideInInspector] public int firstHobbysIndex;
            public Button secondHobbys;
            [HideInInspector] public int secondHobbysIndex;
            public Button redFlag;
            [HideInInspector] public int redFlagIndex;
        }
    }

    private void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;

        Bind();
    }

    /// <summary>
    /// Lie les events lié au menu de creation de personnage
    /// </summary>
    void Bind()
    {
        profilCreationMenu.next.onClick.AddListener(delegate { GM.CreatePlayer(
            GetPlayerName(),
            profilCreationMenu.characterSelection.hair.index
            ); });

        // Character Creation
        profilCreationMenu.characterSelection.hair.next.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.hair); });
        profilCreationMenu.characterSelection.hair.before.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.hair, false); });

        profilCreationMenu.characterSelection.eyes.next.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.eyes); });
        profilCreationMenu.characterSelection.eyes.before.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.eyes, false); });

        profilCreationMenu.characterSelection.nose.next.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.nose); });
        profilCreationMenu.characterSelection.nose.before.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.nose, false); });

        profilCreationMenu.characterSelection.mouth.next.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.mouth); });
        profilCreationMenu.characterSelection.mouth.before.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.mouth, false); });

        profilCreationMenu.characterSelection.clothe.next.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.clothe); });
        profilCreationMenu.characterSelection.clothe.before.onClick.AddListener(delegate { SelectAssets(profilCreationMenu.characterSelection.clothe, false); });
        /*
        // Hobby Selection
        profilCreationMenu.hobbysSelection.firstHobbys.onClick.AddListener(delegate { 
            UIM.SetActiveMenu(MenuType.STICKER_SCROLL);
            selectedImage = GetComponent<Image>();
        });
        profilCreationMenu.hobbysSelection.secondHobbys.onClick.AddListener(delegate { 
            UIM.SetActiveMenu(MenuType.STICKER_SCROLL);
            selectedImage = GetComponent<Image>();
        });
        profilCreationMenu.hobbysSelection.redFlag.onClick.AddListener(delegate { 
            UIM.SetActiveMenu(MenuType.STICKER_SCROLL);
            selectedImage = GetComponent<Image>();
        });
        */
    }

    void SelectAssets(ProfilCreationMenu.CharacterParts.Part part, bool isNext = true)
    {
        part.index = isNext ? part.index + 1 : part.index - 1;
        part.index = part.index > part.assets.sprites.Length - 1 ? 0 : part.index;
        part.index = part.index < 0 ? part.assets.sprites.Length - 1 : part.index;
        part.image.sprite = part.assets.sprites[part.index];
    }

    string GetPlayerName() 
    {
        return profilCreationMenu.playerName.text;
    }
}
