using UnityEngine;

public static class UITool
{
    public static string CanvasRoot
    {
        get
        {
            return canvasRoot;
        }

        set
        {
            if (!value.Equals(canvasRoot))
            {
                canvasRoot = value;
            }
        }
    }

    private static string canvasRoot = "Canvas";

    private static GameObject mCanvas;

    public static GameObject FindUIGameObject(string name, bool includeInactive = true)
    {
        return UnityTool.FindChildGameObject(GetCanvas(), name, includeInactive);
    }

    public static GameObject FindUIGameObject(GameObject container, string name, bool includeInactive = true)
    {
        return UnityTool.FindChildGameObject(container, name, includeInactive);
    }

    public static T GetUIComponent<T>(string name, bool includeInactive = true) where T : Component
    {
        return GetUIComponent<T>(GetCanvas(), name, includeInactive);
    }

    public static T GetUIComponent<T>(GameObject container, string name, bool includeInactive = true) where T : Component
    {
        GameObject child = UnityTool.FindChildGameObject(container, name, includeInactive);

        if (child == null)
        {
            return null;
        }

        T component = child.GetComponent<T>();

        if (component == null)
        {
            Debug.LogError("[" + name + "] GameObject is not type of [" + typeof(T) + "]");
            return null;
        }

        return component;
    }

    private static GameObject GetCanvas()
    {
        if (mCanvas == null)
        {
            mCanvas = UnityTool.FindGameObject(canvasRoot);
        }

        return mCanvas;
    }
}
