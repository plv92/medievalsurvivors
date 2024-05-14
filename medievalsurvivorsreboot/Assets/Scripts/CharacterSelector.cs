using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;
    public CharacterScriptableObject CharacterData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("EXTRA" + this + "DESTROYED");
            Destroy(gameObject);
        }
    }

    public static CharacterScriptableObject GetCharacterData()
    {
        return instance.CharacterData;
    }

    public void SelectCharacter(CharacterScriptableObject character)
    {
        CharacterData = character;
    }

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
