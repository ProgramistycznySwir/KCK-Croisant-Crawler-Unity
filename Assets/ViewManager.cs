using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    /// Singleton.
    public static ViewManager instance { get; private set; }
    public ViewManager() => instance = this;

    public Dictionary<View, Transform> views = new();

    public Transform mapView__;
    public Transform heroTabView__;
    public Transform fightView__;


    public enum View { Map, HeroTab, Fight }
    private readonly HashSet<View> rootViews = new() { View.Map, View.Fight };
    private readonly Stack<(View view, Transform transform)> viewStack = new();

    public (View view, Transform transform) CurrentView => viewStack.Peek();

    void Awake()
    {
        views.Add(View.Map, mapView__);
        views.Add(View.HeroTab, heroTabView__);
        views.Add(View.Fight, fightView__);

        viewStack.Push((View.Map, views[View.Map]));
        View_Render();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(CurrentView.view == View.HeroTab)
                View_Return();
            else
                View_Open(View.HeroTab);
        }
    }
    public void View_Open(View view)
    {
        if(view == CurrentView.view)
            return;
        if(rootViews.Contains(view))
            viewStack.Clear();
        viewStack.Push((view, views[view]));

        View_Render();
    }
    public void View_Open_Map()
        => View_Open(View.Map);
    public void View_Open_HeroTab()
        => View_Open(View.HeroTab);
    public void View_Open_Fight()
        => View_Open(View.Fight);
    public void View_Return()
    {
        if(viewStack.Count <= 1)
            return;
        viewStack.Pop();

        View_Render();
    }
    private void View_Render()
    {
        foreach(var view in views.Values)
            view.gameObject.SetActive(false);
        viewStack.Peek().transform.gameObject.SetActive(true);
    }
}
