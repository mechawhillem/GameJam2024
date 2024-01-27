using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameParamMenu : MonoBehaviour
{
    public GameParam gameParamMenu;

    [Serializable]
    public class GameParam
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
}
