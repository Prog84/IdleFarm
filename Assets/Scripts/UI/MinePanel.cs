using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MinePanel: MonoBehaviour{
    [Header("Resource Button")]
    [SerializeField] private Button _changeResourceButton;
    [SerializeField] private Image _resourceIcon;
    
    [Header("Producing Button")]
    [SerializeField] private Button _startProducingButton;
    [SerializeField] private Text _startProducingLabel;
    private string _startText = "Start";
    private string _stopText = "Stop";

    private List<ResourceIcon> _resourceIcons;
    private Building _currentBuilding;
    private int _currentRecourseIndex = 0;
    private bool _isStarted = false;

    private void Awake() {
        _changeResourceButton.onClick.AddListener(OnChangeResourceClick);
        _startProducingButton.onClick.AddListener(OnStartClick);
    }

    private void OnDestroy() {
        _changeResourceButton.onClick.RemoveListener(OnChangeResourceClick);
        _startProducingButton.onClick.RemoveListener(OnStartClick);
    }

    public void Init(Building building) {
        _currentBuilding = building;
        _isStarted = building.IsWorking;

        if (_isStarted) {
            SetStopButton();     
        }
        else {
            SetStartButton();
        }
       
        SetStartIcon();
    }
    
    private void OnStartClick() {
        EventsHolder.SetStartProducingClick(_currentBuilding, _currentRecourseIndex);
        ChangeButton();
    }

    private void SetStartIcon() {
        _resourceIcons = PlayerData.Instance.ResourceData.ResourceIcons;

        for (int i = 0; i < _resourceIcons.Count; i++) {
            if (_resourceIcons[i].TypeResource == _currentBuilding.CurrentResource) {
                _currentRecourseIndex = i;
                SetResourceIcon();
            }
        }
    }

    private void SetResourceIcon() {
        _resourceIcon.sprite = _resourceIcons[_currentRecourseIndex].Icon;
    }
    
    private void OnChangeResourceClick() {
        _currentRecourseIndex++;
        if (_currentRecourseIndex > _resourceIcons.Count - 1)
            _currentRecourseIndex = 0;
        SetResourceIcon();
    }

    private void ChangeButton() {
        if (_isStarted) {
            SetStartButton();
        }
        else {
            SetStopButton();
        }
    }

    private void SetStartButton() {
        _isStarted = false;
        _startProducingLabel.text = _startText;
        _changeResourceButton.interactable = true;
    }
    
    private void SetStopButton() {
        _isStarted = true;
        _startProducingLabel.text = _stopText;
        _changeResourceButton.interactable = false;
    }
}