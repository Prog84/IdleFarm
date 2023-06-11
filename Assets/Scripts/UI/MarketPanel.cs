using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MarketPanel : MonoBehaviour{
    [SerializeField] private Button _changeResourceButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Image _resourceIcon;
    [SerializeField] private Text _price;

    private List<ResourceSettings> _resourceItems = new List<ResourceSettings>();
    private Building _currentBuilding;
    private int _currentRecourseIndex = 0;

    private void Awake() {
        _changeResourceButton.onClick.AddListener(OnChangeResourceClick);
        _sellButton.onClick.AddListener(OnSellClick);
    }

    private void OnDestroy() {
        _changeResourceButton.onClick.RemoveListener(OnChangeResourceClick);
        _sellButton.onClick.RemoveListener(OnSellClick);
    }

    public void Init(Building building) {
        _currentBuilding = building;
        SetStartRecourse();
    }

    private void SetStartRecourse() {
        foreach (var resource in PlayerData.Instance.ResourceData.ResourceIcons) {
            _resourceItems.Add(resource);
        }

        foreach (var resource in PlayerData.Instance.ResourceData.CraftIcons) {
            _resourceItems.Add(resource);
        }

        for (int i = 0; i < _resourceItems.Count; i++) {
            if (_resourceItems[i].TypeResource == _currentBuilding.CurrentResource) {
                _currentRecourseIndex = i;
                SetResource();
            }
        }
    }

    private void SetResource() {
        _resourceIcon.sprite = _resourceItems[_currentRecourseIndex].Icon;
        var itemResource = PlayerData.Instance.ResourceData.ResourceIcons.FirstOrDefault(r =>
            r.TypeResource == _resourceItems[_currentRecourseIndex].TypeResource);

        if (itemResource != null) {
            _price.text = itemResource.price.ToString();
        }
        else {
            var itemCraft = PlayerData.Instance.ResourceData.CraftIcons.FirstOrDefault(r =>
                r.TypeResource == _resourceItems[_currentRecourseIndex].TypeResource);
            if (itemCraft != null) {
                _price.text = itemCraft.price.ToString();
            }
        }
    }

    private void OnChangeResourceClick() {
        _currentRecourseIndex++;
        if (_currentRecourseIndex > _resourceItems.Count - 1)
            _currentRecourseIndex = 0;
        SetResource();
    }

    private void OnSellClick() {
        EventsHolder.SellProduct(_resourceItems[_currentRecourseIndex]);
    }
}