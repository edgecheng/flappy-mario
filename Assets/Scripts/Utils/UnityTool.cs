using UnityEngine;

public static class UnityTool
{
    public static GameObject FindGameObject(string name)
    {
        GameObject target = GameObject.Find(name);

        if (target == null)
        {
            Debug.LogError("Can't find [" + name + "] GameObject");
        }

        return target;
    }

    public static GameObject FindGameObjectWithTag(string tag)
    {
        GameObject target = GameObject.FindGameObjectWithTag(tag);

        if (target == null)
        {
            Debug.LogError("Can't find GameObject with tag [" + tag + "]");
        }

        return target;
    }

    public static GameObject[] FindGameObjectsWithTag(string tag)
    {
        GameObject[] target = GameObject.FindGameObjectsWithTag(tag);

        if (target == null)
        {
            Debug.LogError("Can't find GameObjects with tag [" + tag + "]");
        }

        return target;
    }

    public static GameObject FindChildGameObject(GameObject container, string name, bool includeInactive = true)
    {
        if (container == null)
        {
            return null;
        }

        Transform transform = null;

        if (container.name.Equals(name))
        {
            transform = container.transform;
        }
        else
        {
            Transform[] children = container.transform.GetComponentsInChildren<Transform>(includeInactive);

            foreach (Transform child in children)
            {
                if (child.name.Equals(name))
                {
                    if (transform == null)
                    {
                        transform = child;
                    }
                    else
                    {
                        Debug.LogWarning("Find duplicated GameObject name [" + name + "] under [" + container.name + "]");
                    }
                }
            }
        }

        if (transform == null)
        {
            Debug.LogError("Can't find [" + name + "] GameObject under [" + container.name + "]");
            return null;
        }

        return transform.gameObject;
    }
}
