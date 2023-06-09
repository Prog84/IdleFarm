using UnityEngine;

public class PlayerData: MonoBehaviour{

    [SerializeField] private LevelData _levelData;
    public LevelData LevelData => _levelData;

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