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

    void Awake()
    {
        Debug.Log(instance);
        views.Add(View.Map, mapView__);
        views.Add(View.HeroTab, heroTabView__);
        views.Add(View.Fight, fightView__);

        viewStack.Push((View.Map, views[View.Map]));
        View_Render();
    }


    public enum View { Map, HeroTab, Fight }
    private readonly HashSet<View> rootViews = new() { View.Map, View.Fight };
    private readonly Stack<(View view, Transform transform)> viewStack = new();
    public void View_Open(View view)
    {
        if(view == viewStack.Peek().view)
            return;
        if(rootViews.Contains(view))
            viewStack.Clear();
        viewStack.Push((view, views[view]));

        View_Render();
    }
    public void View_Return()
    {
        if(viewStack.Count <= 1)
            return;
        viewStack.Pop();

        View_Render();
    }
    private void View_Render()
    {
        foreach(var view in viewStack)
            view.transform.gameObject.SetActive(false);
        viewStack.Peek().transform.gameObject.SetActive(true);
    }
}
