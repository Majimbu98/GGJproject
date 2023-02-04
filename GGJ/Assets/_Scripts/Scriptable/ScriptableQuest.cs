using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Quest", menuName = " Create New Quest")]
public class ScriptableQuest : ScriptableObject
{

#region Variables & Properties

[SerializeField] private Sprite sprite;
[SerializeField] private int number;
[field: SerializeField] public ItemSO item { get; private set; }

#endregion

#region Methods



public Sprite GetSprite()
{
    return sprite;
}

public int GetNumber()
{
    return number;
}

#endregion

}
