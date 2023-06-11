using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource Data", menuName = "Resource Data", order = 1)]
public class ResourceData : ScriptableObject{
    public Sprite EmptyIcon;
    public List<ResourceSettings> ResourceIcons;
    public List<ResourceSettings> CraftIcons;
}