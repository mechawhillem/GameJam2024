using UnityEngine;

public class ScrollStickers : MonoBehaviour
{
    public GameObject content;
    public Transform holder;
    public HobbysAssets assets;
    public CharacterSelection characterSelection;
    UIManager UIM;

    bool isFirst = false;

    void Start()
    {
        UIM = UIManager.instance;
        isFirst = true;
        UIM.ChangeContexteText("Choisie un centre d'intérêt");
        for (int i = 0; i < assets.sprites.Length; i++)
        {
            GameObject instance = Instantiate(content, holder);
            ContentInfo info = instance.GetComponent<ContentInfo>();
            info.index = i;
            info.image.sprite = assets.sprites[i];
            info.button.onClick.AddListener(delegate {
                characterSelection.stickerInt = info.index;
                UIM.SetActiveMenu(MenuType.PROFIL_CREATION);            
            });
        }
    }

    private void OnEnable()
    {
        if (isFirst)
        {
            UIM.ChangeContexteText("Choisie un centre d'intérêt");
        }
    }
}
