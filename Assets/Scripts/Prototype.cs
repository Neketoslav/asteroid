using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static partial class Prototype
{
    public static T DeepCopy<T>(this T self)
    {
        if (!typeof(T).IsSerializable)
        {
            throw new ArgumentException("Должен быть сериализуемым");
        }
        if (ReferenceEquals(self, null))
        {
            return default;
        }

        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }
}


