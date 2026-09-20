# Декомпиляция Topomatic.RoadSigns.DwgRoadSignStand (write-стойка знака на плане)

> Источник: monodis --method Topomatic.RoadSigns.dll (Development/Out/Bin, эталон), дата 2026-09-20.
> Статус: [DECOMP]. Имена методов ДО декомпиляции обфусцированы частично;
> ниже — только НЕ-обфусцированные write-имена (честно, без выдумок).

## typedef (ancэталон; монодис --typedef)

16: Topomatic.RoadSigns.DwgRoadSignStand (flist=13, mlist=67)

## write-методы ([DECOMP]; instance, без get_/set_/ctor/служебных)

```
instance default void OnAssign (class [Topomatic.Dwg]Topomatic.Dwg.Entities.DwgEntity source)
instance default void OnLoadFromStg (class [Topomatic.Stg]Topomatic.Stg.StgNode node)
instance default void OnSaveToStg (class [Topomatic.Stg]Topomatic.Stg.StgNode node)
instance default void SaveTo (class [Topomatic.Stg]Topomatic.Stg.StgNode node)
instance default void LoadFrom (class [Topomatic.Stg]Topomatic.Stg.StgNode node)
instance default class [Topomatic.Dwg]Topomatic.Dwg.Entities.DwgInsert GetSignTypedObject (class [Topomatic.Dwg]Topomatic.Dwg.Entities.DwgInsert insert)
instance default valuetype [Topomatic.Cad.Foundation]Topomatic.Cad.Foundation.BoundingBox2D GetAnnotativeBounds (float64 scale)
```

> Ловушка (честно): часть методов-«служебных» (OnBreak/OnMove/OnRotate и
> геометрия вершин) имеют ОБФУСЦИРОВАННЫЕ имена в дампе ('——'), поэтому их
> точный write-набор здесь НЕ перечислен — не выдумываем. Write-стойка на
> пикете реализуется через паттерн «знак на пикете» (roadsigns.md §«Стойка» +
> road.md §«План»): позиция InsPos + угол, масштаб Scale.
