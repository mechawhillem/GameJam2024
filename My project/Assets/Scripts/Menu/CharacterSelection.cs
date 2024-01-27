using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static CharacterSelection.ProfilCreationMenu.CharacterParts;

public class CharacterSelection : MonoBehaviour
{
    public ProfilCreationMenu profilCreationMenu;
    UIManager UIM;

    [Serializable]
    public class ProfilCreationMenu
    {
        public TextMeshProUGUI playerName;
        public Button Next;
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
                public int index = 0;
                public CharacterAssets assets;
                public Button next;
                public Button before;
                public Image image;
            }
        }

        [Serializable]
        public class HobbysSelection
        {
            public GameObject menu;
            public HobbysAssets hobbysAssets;
            public Button firstHobbys;
            public Button secondHobbys;
            public Button redFlag;
        }
    }

    private void Start()
    {
        UIM = UIManager.instance;
        Bind();
    }

    /// <summary>
    /// Lie les events lié au menu de creation de personnage
    /// </summary>
    void Bind()
    {
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
        ProfilCreationMenu.HobbysSelection hob = profilCreationMenu.hobbysSelection;
        //hob

    }

    void SelectAssets(ProfilCreationMenu.CharacterParts.Part part, bool isNext = true)
    {
        part.index = isNext ? part.index + 1 : part.index - 1;
        part.index = part.index > part.assets.sprites.Length - 1 ? 0 : part.index;
        part.index = part.index < 0 ? part.assets.sprites.Length - 1 : part.index;
        part.image.sprite = part.assets.sprites[part.index];
    }

}
