using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Job Summary - scriptable object to be used for anything the baby throws
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public string prefabName;
    public GameObject prefab;

    public int numberOfPrefabsToCreate;
    public int points;
}