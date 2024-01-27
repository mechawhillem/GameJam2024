using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterAssets", menuName = "ScriptableObjects/CharacterAssets", order = 1)]
public class CharacterAssets : ScriptableObject
{
    public Image[] sprites;
}
