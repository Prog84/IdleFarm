using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinePanel: MonoBehaviour{
    [SerializeField] private Button _changeResourceButton;
    [SerializeField] private Button _startProducingButton;

    private List<ResourceIcon> _resourceIcons;

    private Building _currentBuilding;

    /*private void Awake() {
        throw new NotImplementedException();
    }*/

    public void Init(Building building) {
        _currentBuilding = building;
    }

    /*private SetResourceIcons() {
        foreach (var buildings in PlayerData.Instance.LevelData.BuildingsPositions) {
            
        }
    }*/

    private void ChangeResource() {
        
        
        /*foreach (Fruits fruit in Enum.GetValues(typeof(Fruits)))
        {
            DoSomething(fruit);
        }*/
    }
}