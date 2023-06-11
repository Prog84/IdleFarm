using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour, IPointerDownHandler{
    public TypeBuilding TypeBuilding;
    public TypeResource CurrentResource;
    public bool IsWorking;

    protected List<RecourseItem> AvailableResources;
    protected int CurrentRecourseIndex = 0;

    private void Awake() {
        EventsHolder.ProductionStarted += OnProductionStarted;
    }

    private void OnDestroy() {
        EventsHolder.ProductionStarted -= OnProductionStarted;
    }

    public virtual void Init(TypeBuilding typeBuilding, List<RecourseItem> availableRecourses,
        BuildingTimeCrate buildingTimeCrate) {
        TypeBuilding = typeBuilding;
        AvailableResources = availableRecourses;

        if (AvailableResources.Count > 0) {
            CurrentRecourseIndex = 0;
            CurrentResource = AvailableResources[CurrentRecourseIndex].TypeResource;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        EventsHolder.SetBuildingClick(this);
    }

    protected virtual void OnProductionStarted(Building building, TypeResource currentResource) {
        if (building.Equals(this)) {
            for (int i = 0; i < AvailableResources.Count; i++) {
                if (AvailableResources[i].TypeResource == currentResource) {
                    CurrentRecourseIndex = i;
                }
            }
        }
    }

    protected virtual void SetCurrentResource(TypeResource currentResource) {
        for (int i = 0; i < AvailableResources.Count; i++) {
            if (AvailableResources[i].TypeResource == currentResource) {
                CurrentRecourseIndex = i;
            }
        }

        CurrentResource = AvailableResources[CurrentRecourseIndex].TypeResource;
    }
}