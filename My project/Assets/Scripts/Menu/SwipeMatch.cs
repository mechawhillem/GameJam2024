using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeMatch : MonoBehaviour
{
    public MiniatureInfo miniature;
    public Button next;
    public Button like;
    public Button vote;

    public Animator animator;
    public AudioSource swipeSound;

    private Animator anim; 

    [HideInInspector] public bool state = false;
    [HideInInspector] public bool isEnd = false;

    int index = -1;

    public GameObject ButtonLike, ButtonReady, buttonVote;

    GameManager GM;
    UIManager UIM;

    private void Start()
    {
        GM = GameManager.instance;
        UIM = UIManager.instance;

        animator = GetComponent<Animator>();
        swipeSound.Play();

        GetRandomPlayer();


        next.onClick.AddListener(delegate { StartCoroutine(WaitNextAnim()); });
        like.onClick.AddListener(delegate { StartCoroutine(WaitLikeAnim()); });
        vote.onClick.AddListener(delegate { UIM.SetActiveMenu(MenuType.MESSAGE_MATCH); });

    }

    private IEnumerator WaitNextAnim()
    {
        animator.Play("Out");
        swipeSound.Play();
        yield return new WaitForSeconds(1);
        UIM.SetActiveMenu(MenuType.CATH_PHRASE);
    }

    private IEnumerator WaitLikeAnim()
    {
        animator.Play("Out");
        swipeSound.Play();
        yield return new WaitForSeconds(1);
        UIM.SetActiveMenu(MenuType.MESSAGE_PRETENDANT);
    }

    private void OnEnable()
    {
        animator.Play("In");
        swipeSound.Play();

        if (state && isEnd == false)
        {
            TakePlayers();
        }

        if (isEnd)
        {
            UIM.ChangeContexteText($"{GM.matchName} a toi de voter");
            buttonVote.SetActive(true);
            ButtonLike.SetActive(false);
            ButtonReady.SetActive(false);
        }
    }

    void TakePlayers() 
    {
        index++;
        if (!GM.players[index].isMatch)
        {
            GM.currentPlayer = GM.players[index].playerName;
            GM.currentIndexPlayer = index;
            UIM.ChangeContexteText($"Au tour de {GM.players[index].playerName}");
        }
        else 
        {
            TakePlayers();
        }
        
    }

    void GetRandomPlayer()
    {
        int nmbOfPlayer = GM.players.Count;
        int player = Random.Range(0, nmbOfPlayer - 1);
        miniature.playerName.text = GM.players[player].playerName;
        miniature.hair.sprite = miniature.hairAssets.sprites[GM.players[player].hairIndex];
        miniature.eyes.sprite = miniature.eyesAssets.sprites[GM.players[player].eyesIndex];
        miniature.nose.sprite = miniature.noseAssets.sprites[GM.players[player].noseIndex];
        miniature.mouth.sprite = miniature.mouthAssets.sprites[GM.players[player].mouthIndex];
        miniature.clothe.sprite = miniature.clotheAssets.sprites[GM.players[player].clotheIndex];
        UIM.ChangeContexteText($"{GM.players[player].playerName} est le match");
        GM.matchName = GM.players[player].playerName;
        GM.matchIndex = player;
        GM.players[player].isMatch = true;
    }

    public void switchMode(bool state)
    {
        this.state = state;
        if (this.state)
        {
            ButtonLike.SetActive(true);
            ButtonReady.SetActive(false);
        }
        else
        {
            ButtonLike.SetActive(false);
            ButtonReady.SetActive(true);
        }
    }
}
