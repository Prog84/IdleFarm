using System.Collections.Generic;

public class SaveData{
    public List<TypeResource> PlayerResourcesKey;
    public List<int> PlayerResourcesValue;
    public int CurrentMineCount;
    public int CurrentLevelIndex;

    public SaveData(Dictionary<TypeResource, int> playerResources, int currentMineCount, int currentLevelIndex) {
        PlayerResourcesKey = new List<TypeResource>();
        PlayerResourcesValue = new List<int>();
        foreach (var playerResource in playerResources) {
            PlayerResourcesKey.Add(playerResource.Key);
            PlayerResourcesValue.Add(playerResource.Value);
        }

        CurrentMineCount = currentMineCount;
        CurrentLevelIndex = currentLevelIndex;
    }

    public SaveData() {
    }
}