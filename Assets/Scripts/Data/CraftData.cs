using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftData", menuName = "CraftData", order = 1)]
public class CraftData : ScriptableObject{
    public List<CraftItem> CraftItems;
}