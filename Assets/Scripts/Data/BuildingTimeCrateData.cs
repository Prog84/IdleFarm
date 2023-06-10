using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingTimeCrateData", menuName = "BuildingTimeCrateData", order = 1)]
public class BuildingTimeCrateData: ScriptableObject{
    public List<GroupTypeBuildingTimeCrate> ListBuildingTimeCrates;
}