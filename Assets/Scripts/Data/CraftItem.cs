using System;
using System.Collections.Generic;

[Serializable]
public class CraftItem{
    public RecourseItem NeedFirstResource;
    public RecourseItem NeedSecondResource;
    public TypeResource CraftResource;
}