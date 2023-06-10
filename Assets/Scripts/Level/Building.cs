using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour, IPointerDownHandler{
    public TypeBuilding TypeBuilding;
    public TypeResource CurrentResource;
    public bool IsWorking;

    protected List<TypeResource> AvailableResources;
    protected int CurrentRecourseIndex = 0;

    private void Awake() {
        EventsHolder.ProductionStarted += OnProductionStarted;
        EventsHolder.ProductionStopped += OnProductionStopped;
    }
    private void OnDestroy() {
        EventsHolder.ProductionStarted -= OnProductionStarted;
        EventsHolder.ProductionStopped -= OnProductionStopped;
    }

    public virtual void Init(TypeBuilding typeBuilding, List<TypeResource> availableRecourses, BuildingTimeCrate buildingTimeCrate) {

        TypeBuilding = typeBuilding;
        AvailableResources = availableRecourses;

        if (AvailableResources.Count > 0) {
            CurrentRecourseIndex = 0;
            CurrentResource = AvailableResources[CurrentRecourseIndex];
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        EventsHolder.SetBuildingClick(this);
    }

    protected virtual void OnProductionStarted(Building building, int currentResource) {
        if (building.Equals(this)) {
            CurrentRecourseIndex = currentResource;
        }
    }
    
    private void OnProductionStopped(TypeResource typeResource) {
        if (CurrentResource == typeResource) {
            IsWorking = false;
        }
    }

}