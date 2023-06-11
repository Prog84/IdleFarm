using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelGoalData", menuName = "LevelGoalData", order = 1)]
public class LevelGoalData : ScriptableObject{
    public List<LevelGoal> LevelGoals;
}
