using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        public class HobbysSelction
        {
            public GameObject menu;
            public HobbysAssets hobbysAssets;
            public Button firstHobbys;
            public Button secondHobbys;
            public Button thirdHobbys;
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
        ProfilCreationMenu.CharacterParts.Part part = profilCreationMenu.characterSelection.hair;
        profilCreationMenu.characterSelection.hair.next.onClick.AddListener(delegate { SelectAssets(part); });
        profilCreationMenu.characterSelection.hair.before.onClick.AddListener(delegate { SelectAssets(part, false); });

        part = profilCreationMenu.characterSelection.eyes;
        profilCreationMenu.characterSelection.eyes.next.onClick.AddListener(delegate { SelectAssets(part); });
        profilCreationMenu.characterSelection.eyes.before.onClick.AddListener(delegate { SelectAssets(part, false); });

        part = profilCreationMenu.characterSelection.nose;
        profilCreationMenu.characterSelection.nose.next.onClick.AddListener(delegate { SelectAssets(part); });
        profilCreationMenu.characterSelection.nose.before.onClick.AddListener(delegate { SelectAssets(part, false); });

        part = profilCreationMenu.characterSelection.mouth;
        profilCreationMenu.characterSelection.mouth.next.onClick.AddListener(delegate { SelectAssets(part); });
        profilCreationMenu.characterSelection.mouth.before.onClick.AddListener(delegate { SelectAssets(part, false); });

        part = profilCreationMenu.characterSelection.clothe;
        profilCreationMenu.characterSelection.clothe.next.onClick.AddListener(delegate { SelectAssets(part); });
        profilCreationMenu.characterSelection.clothe.before.onClick.AddListener(delegate { SelectAssets(part, false); });
    }

    void SelectAssets(ProfilCreationMenu.CharacterParts.Part part, bool isNext = true)
    {
        part.index = isNext ? part.index + 1 : part.index - 1;
        part.index = part.index > part.assets.sprites.Length - 1 ? 0 : part.index;
        part.index = part.index < 0 ? part.assets.sprites.Length - 1 : part.index;
        part.image.sprite = part.assets.sprites[part.index];
    }
}
