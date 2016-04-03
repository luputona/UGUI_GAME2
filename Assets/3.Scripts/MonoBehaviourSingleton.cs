using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
{
    public int InstanceID;
    public new Transform transform { get; private set; }
    public new GameObject gameObject { get; private set; }

    static bool canCreate = true;

    private static T m_Instance = null;

    public static T getInstance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;

                if (m_Instance == null)
                {
                    if (canCreate)
                    {
                        m_Instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                    }
                    if (m_Instance == null)
                    {
                        Debug.LogError("MonoBehaviourSingleton Instance Init ERROR - " + typeof(T).ToString());
                    }
                }
            }
            else
            {
                m_Instance.Init();
            }
            return m_Instance;
        }
    }

    public void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (m_Instance == null)
        {
            transform = base.transform;
            gameObject = base.gameObject;
            InstanceID = GetInstanceID();

            m_Instance = this as T;
        }
        else
        {
            if (m_Instance != this)
            {
                DestroyImmediate(base.gameObject);
            }
        }
    }

    public void OnDestroy()
    {
        if (m_Instance == this)
        {
            m_Instance = null;
        }
    }

    void OnApplicationQuit()
    {
        canCreate = false;
        m_Instance = null;
    }
}

public class Singleton_OBJ<T> where T : class, new()
{
    private static object _syncobj = new object();
    private static volatile T m_instance = null;
    
    public static T getInstance
    {
        get
        {
            if (m_instance == null)
            {
                lock (_syncobj)
                    m_instance = new T();               
            }
            return m_instance;
        }
    }
}