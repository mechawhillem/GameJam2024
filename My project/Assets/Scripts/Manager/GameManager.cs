using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefabs;
    public List<DataPlayer> players = new List<DataPlayer>();
    public GameParamMenu gameParamMenu;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void CreatePlayer(string name, int hairIndex, int eyesIndex, int noseIndex, int mouthIndex, int clothIndex) 
    {
        GameObject instance = Instantiate(playerPrefabs, transform);
        instance.gameObject.name = name;
        DataPlayer player = instance.GetComponent<DataPlayer>();
        player.playerName = name;
        player.hairIndex = hairIndex;
        player.eyesIndex = eyesIndex;
        player.noseIndex = noseIndex;   
        player.mouthIndex = mouthIndex;
        player.clotheIndex = clothIndex;
        players.Add(player);
        gameParamMenu.CreatePlayer(name,hairIndex,eyesIndex,noseIndex,mouthIndex,clothIndex);
    }


}
