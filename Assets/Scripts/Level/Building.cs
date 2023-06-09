using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IPointerDownHandler{
    [SerializeField] private TypeBuilding _typeBuilding;
    public TypeBuilding TypeBuilding => _typeBuilding;

    private TypeResource _currentResource;
    private int _timeToCreate;

    public void Init(int timeToCrate) {
        _timeToCreate = timeToCrate;
        _currentResource = TypeResource.Tree;
    }

    public void OnPointerDown(PointerEventData eventData) {
        EventsHolder.SetBuildingClick(this);
        Debug.Log("Click");
    }
}