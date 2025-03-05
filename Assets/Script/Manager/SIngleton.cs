using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class SIngleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if(instance == null)
                {
                    GameObject newObject = new GameObject(typeof(T).Name, typeof(T));
                    instance = newObject.GetComponent<T>();
                }
            }

            return instance;
        }
    }

    public void Awake()
    {
        // DontDestoryOnLoad(gameobject);
        // 필요할때 InitializeManager에서 해주기

        InitializeManager();
    }

    protected abstract void InitializeManager();
}
