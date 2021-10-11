using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class BuilderBullet
{
    public static GameObject SetName(this GameObject gameObject, string name)
    {
        gameObject.name = name;
        return gameObject;
    }

    public static GameObject AddTransform(this GameObject gameObject, Transform transform)
    {
        var component = gameObject.GetOrAddComponent<Transform>();
        component.transform.position = transform.position;
        return gameObject;
    }

    public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float gravity)
    {
        var component = gameObject.GetOrAddComponent<Rigidbody2D>();
        component.mass = mass;
        component.gravityScale = gravity;
        return gameObject;
    }

    public static GameObject AddBoxCollider2D(this GameObject gameObject)
    {
        gameObject.GetOrAddComponent<BoxCollider2D>();
        return gameObject;
    }

    public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
    {
        var component = gameObject.GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
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
