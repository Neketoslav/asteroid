using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class BuilderBullet
{
    public static GameObject SetName(this GameObject gameObject, string name)
    {
        gameObject.name = name;
        gameObject.tag = "Bullet";
        return gameObject;
    }

    public static GameObject AddTransform(this GameObject gameObject, Transform transform)
    {
        var component = gameObject.GetOrAddComponent<Transform>();
        component.transform.position = transform.position;
        return gameObject;
    }

    public static GameObject AddRigidbody(this GameObject gameObject, float mass, float gravity)
    {
        var component = gameObject.GetOrAddComponent<Rigidbody>();
        component.mass = mass;
        component.useGravity = false;
        return gameObject;
    }

    public static GameObject AddBoxCollider(this GameObject gameObject)
    {
        var component = gameObject.GetOrAddComponent<BoxCollider>();
        component.isTrigger = true;
        return gameObject;
    }
    public static GameObject AddScript(this GameObject gameObject)
    {
        var component = gameObject.GetOrAddComponent<Bullet>();
        return gameObject;
    }


    public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
    {
        var component = gameObject.GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
        component.sortingOrder = 1;
        return gameObject;
    }
    private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var result = gameObject.GetComponent<T>();
        if (!result)
        {
            result = gameObject.AddComponent<T>();
        }
        return result;
    }
}
