using UnityEngine;

public class PlayerData: MonoBehaviour{

    [SerializeField] private LevelData _levelData;
    [SerializeField] private ResourceData _resourceData;
    [SerializeField] private BuildingTimeCrateData _buildingTimeCrateData;

    public LevelData LevelData => _levelData;
    public ResourceData ResourceData => _resourceData;
    public BuildingTimeCrateData BuildingTimeCrateData => _buildingTimeCrateData;

    public int CurrentMineCount = 0;
    
    public static PlayerData Instance = null;

    private void Awake() {
       
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
}