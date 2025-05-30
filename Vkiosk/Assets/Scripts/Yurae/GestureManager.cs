// Unity
using UnityEngine;

// System
using System.Collections.Generic;
using System;

public enum GestureType
{
    Click,
    UpSwipe,
    DownSwipe,
    LeftSwipe,
    RightSwipe,
    Grap,
    Drop,
}

[System.Serializable]
public class Gesture
{
    Dictionary<GestureType, Action> gestureActionDict = new();

    public Gesture()
    {
        gestureActionDict[GestureType.Click] = () => ClickAction();
        gestureActionDict[GestureType.UpSwipe] = () => UpSwipeAction();
        gestureActionDict[GestureType.DownSwipe] = () => DownSwipeAction();
        gestureActionDict[GestureType.LeftSwipe] = () => LeftSwipeAction();
        gestureActionDict[GestureType.RightSwipe] = () => RightSwipeAction();
        gestureActionDict[GestureType.Grap] = () => GrapAction();
        gestureActionDict[GestureType.Drop] = () => DropAction();
    }

    public void Invoke(GestureType type)
    {
        if (gestureActionDict.TryGetValue(type, out var action)) action.Invoke();
    }

    private void ClickAction()
    {
        Debug.Log("Click!");
    }

    private void UpSwipeAction()
    {
        Debug.Log("Up Swipe!");
    }

    private void DownSwipeAction()
    {
        Debug.Log("Down Swipe!");
    }

    private void LeftSwipeAction()
    {
        Debug.Log("Left Swipe!");
    }

    private void RightSwipeAction() 
    {
        Debug.Log("Right Swipe!");
    }

    private void GrapAction()
    {
        Debug.Log("Grap!");
    }

    private void DropAction()
    {
        Debug.Log("Drop!");
    }
}

[DisallowMultipleComponent]
public class GestureManager : MonoBehaviour
{
    [SerializeField] private Gesture gesture;

    private void Start()
    {
        gesture = new Gesture();
    }

    public void UpdateGestureFromNetwork(string _gesture, Vector3 _pos)
    {
        switch (_gesture)
        {
            case "click": gesture.Invoke(GestureType.Click); break;
            case "up_swipe": gesture.Invoke(GestureType.UpSwipe); break;
            case "down_swipe": gesture.Invoke(GestureType.DownSwipe); break;
            case "left_swipe": gesture.Invoke(GestureType.LeftSwipe); break;
            case "right_swipe": gesture.Invoke(GestureType.RightSwipe); break;
            case "grap": gesture.Invoke(GestureType.Grap); break;
            case "drop": gesture.Invoke(GestureType.Drop); break;
        }
    }
}
