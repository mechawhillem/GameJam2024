using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefabs;
    public List<DataPlayer> players = new List<DataPlayer>();
    int index = 0;

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

    public void CreatePlayer(string name, int hairIndex) 
    {
        GameObject instance = Instantiate(playerPrefabs, transform);
        instance.gameObject.name = name;
        DataPlayer player = instance.GetComponent<DataPlayer>();
        player.playerName = name;
        player.hairIndex = hairIndex;
        players.Add(player);  
    }
}
