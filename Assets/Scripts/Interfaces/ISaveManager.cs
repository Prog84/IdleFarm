public interface ISaveManager{
    void Save(SaveData saveData);
    SaveData Load();
}