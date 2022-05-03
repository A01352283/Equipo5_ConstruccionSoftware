using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generic class to store refrences to the scriptable objects
public class ScriptableObjectDB<T> : MonoBehaviour where T : ScriptableObject //Only ScriptableObjects can be passed
{
    static Dictionary<string, T> objects;

    public static void Init(){
        objects = new Dictionary<string, T>();

        var objectArray = Resources.LoadAll<T>("");

        foreach (var obj in objectArray){
            if (objects.ContainsKey(obj.name)){
                Debug.LogError($"There are no two objs with the name {obj.name}");
                continue;
            }

            objects[obj.name] = obj;
        }
    }

    public static T GetObjectByName(string name){
        if (!objects.ContainsKey(name)){
            Debug.LogError($"Object with the name {name} not found in the database");
            return null;
        }

        return objects[name];
    }
}
