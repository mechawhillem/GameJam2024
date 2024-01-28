using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public ProfilCreationMenu profilCreationMenu;
    public TMP_InputField inputFieldname;
    [HideInInspector] public int stickerInt = -1;
    public Image selectedImage1;
    public Image selectedImage2;
    public Image selectedImage3;
    public Sprite def;
    int tempo = -1;
    int sprite1;
    int sprite2;
    int sprite3;


    Image selected;

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

    private void OnEnable()
    {
        if (stickerInt != -1)
        {
            selected.sprite = profilCreationMenu.hobbysSelection.hobbysAssets.sprites[stickerInt];
        }

        if (tempo != -1)
        {
            if (tempo == 0)
            {
                sprite1 = stickerInt;
            }
            if (tempo == 1)
            {
                sprite2 = stickerInt;
            }
            if (tempo == 2)
            {
                sprite3 = stickerInt;
            }
        }
    }

    public void ResetUI()
    {
        inputFieldname.text = "";
        profilCreationMenu.characterSelection.hair.index = 0;
        profilCreationMenu.characterSelection.hair.image.sprite = profilCreationMenu.characterSelection.hair.assets.sprites[0];
        profilCreationMenu.characterSelection.eyes.index = 0;
        profilCreationMenu.characterSelection.eyes.image.sprite = profilCreationMenu.characterSelection.eyes.assets.sprites[0];
        profilCreationMenu.characterSelection.nose.index = 0;
        profilCreationMenu.characterSelection.nose.image.sprite = profilCreationMenu.characterSelection.nose.assets.sprites[0];
        profilCreationMenu.characterSelection.mouth.index = 0;
        profilCreationMenu.characterSelection.mouth.image.sprite = profilCreationMenu.characterSelection.mouth.assets.sprites[0];
        profilCreationMenu.characterSelection.clothe.index = 0;
        profilCreationMenu.characterSelection.clothe.image.sprite = profilCreationMenu.characterSelection.clothe.assets.sprites[0];
        selectedImage1.sprite = def;
        selectedImage2.sprite = def;
        selectedImage3.sprite = def;
    }

    /// <summary>
    /// Lie les events lié au menu de creation de personnage
    /// </summary>
    void Bind()
    {
        profilCreationMenu.next.onClick.AddListener(delegate
        {
            GM.CreatePlayer(
            GetPlayerName(),
            profilCreationMenu.characterSelection.hair.index,
            profilCreationMenu.characterSelection.eyes.index,
            profilCreationMenu.characterSelection.nose.index,
            profilCreationMenu.characterSelection.mouth.index,
            profilCreationMenu.characterSelection.clothe.index,
            sprite1,
            sprite2,
            sprite3
            );
            UIM.SetActiveMenu(MenuType.GAME_PARAM);
        });

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

        // Hobby Selection
        profilCreationMenu.hobbysSelection.firstHobbys.onClick.AddListener(delegate
        {
            UIM.SetActiveMenu(MenuType.STICKER_SCROLL);
            selected = selectedImage1;
            tempo = 0;
        });
        profilCreationMenu.hobbysSelection.secondHobbys.onClick.AddListener(delegate
        {
            UIM.SetActiveMenu(MenuType.STICKER_SCROLL);
            selected = selectedImage2;
            tempo = 1;
        });
        profilCreationMenu.hobbysSelection.redFlag.onClick.AddListener(delegate
        {
            UIM.SetActiveMenu(MenuType.STICKER_SCROLL);
            selected = selectedImage3;
            tempo = 2;
        });
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
