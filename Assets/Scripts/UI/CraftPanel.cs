using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanel: MonoBehaviour{
    [Header("Resource Buttons")]
    [SerializeField] private Button _changeResourceButtonOne;
    [SerializeField] private Image _resourceIconOne;
    [SerializeField] private Button _changeResourceButtonTwo;
    [SerializeField] private Image _resourceIconTwo;
    
    [Header("Result Button")]
    [SerializeField] private Button _startProducingButton;
    [SerializeField] private Text _startProducingLabel;
    [SerializeField] private Image _result;
    
    private List<ResourceSettings> _resourceIcons;
    
    private int _currentOneRecourseIndex = 0;
    private int _currentTwoRecourseIndex = 0;
    private CraftItem _currentCraftItem;
    private Building _currentBuilding;
    private bool _isStarted = false;
    private readonly string _startText = "Start";
    private readonly string _stopText = "Stop";

    private void Awake() {
        _changeResourceButtonOne.onClick.AddListener(OnChangeOneResourceClick);
        _changeResourceButtonTwo.onClick.AddListener(OnChangeTwoResourceClick);
        _startProducingButton.onClick.AddListener(OnStartClick);
        EventsHolder.CraftStopped += OnCraftStopped;
        SetStartIcon();
    }

    private void Update() {
        if (_currentCraftItem != null) {
            CheckCraft(_currentCraftItem);
        }
    }

    private void OnDestroy() {
        _changeResourceButtonOne.onClick.RemoveListener(OnChangeOneResourceClick);
        _changeResourceButtonTwo.onClick.RemoveListener(OnChangeTwoResourceClick);
        _startProducingButton.onClick.RemoveListener(OnStartClick);
        EventsHolder.CraftStopped -= OnCraftStopped;
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
    
    private void SetStartIcon() {
        _resourceIcons = PlayerData.Instance.ResourceData.ResourceIcons;
        SetResourceOneIcon();
        SetResourceTwoIcon();
    }
    
    private void OnChangeOneResourceClick() {
        _currentOneRecourseIndex++;
        if (_currentOneRecourseIndex > _resourceIcons.Count - 1)
            _currentOneRecourseIndex = 0;
        SetResourceOneIcon();
    }
    
    private void OnChangeTwoResourceClick() {
        _currentTwoRecourseIndex++;
        if (_currentTwoRecourseIndex > _resourceIcons.Count - 1)
            _currentTwoRecourseIndex = 0;
        SetResourceTwoIcon();
    }
    
    private void SetResourceOneIcon() {
        _resourceIconOne.sprite = _resourceIcons[_currentOneRecourseIndex].Icon;
        CheckCraft();
    }
    
    private void SetResourceTwoIcon() {
        _resourceIconTwo.sprite = _resourceIcons[_currentTwoRecourseIndex].Icon;
        CheckCraft();
    }

    private void OnCraftStopped(TypeResource typeResource) {
        if (_currentCraftItem.CraftResource == typeResource) {
            SetStartButton();
        }
    }

    private void CheckCraft(CraftItem craftItem) {
        var isEnough = PlayerData.Instance.CheckCountResources(craftItem);
        if (!_isStarted) {
            _startProducingButton.interactable = isEnough;    
        }
    }

    private void CheckCraft() {
        var firstRes = PlayerData.Instance.CraftData.CraftItems.FirstOrDefault(i => 
            i.NeedFirstResource.TypeResource == _resourceIcons[_currentOneRecourseIndex].TypeResource 
            && i.NeedSecondResource.TypeResource == _resourceIcons[_currentTwoRecourseIndex].TypeResource 
            || i.NeedFirstResource.TypeResource == _resourceIcons[_currentTwoRecourseIndex].TypeResource 
            && i.NeedSecondResource.TypeResource == _resourceIcons[_currentOneRecourseIndex].TypeResource);
        
        if (firstRes != null) {
            
         var iconItem = PlayerData.Instance.ResourceData.CraftIcons.FirstOrDefault(i =>
                    i.TypeResource == firstRes.CraftResource);
         _result.sprite = iconItem.Icon;

         var isEnough = PlayerData.Instance.CheckCountResources(firstRes);

         _startProducingButton.interactable = isEnough;
         _currentCraftItem = firstRes;
        }
        else {
            _result.sprite = PlayerData.Instance.ResourceData.EmptyIcon;
            _startProducingButton.interactable = false;
        }
    }

    private void OnStartClick() {
        EventsHolder.RemoveResourcesToCraft(_currentCraftItem.NeedFirstResource, _currentCraftItem.NeedSecondResource);
        EventsHolder.SetStartProducingClick(_currentBuilding, _currentCraftItem.CraftResource);
        ChangeButton();
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
        _changeResourceButtonOne.interactable = true;
        _changeResourceButtonTwo.interactable = true;
    }
    
    private void SetStopButton() {
        _isStarted = true;
        _startProducingLabel.text = _stopText;
        _changeResourceButtonOne.interactable = false;
        _changeResourceButtonTwo.interactable = false;
    }
}