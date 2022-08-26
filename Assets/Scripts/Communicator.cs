using System.Collections;
using System.Collections.Generic;
using System;

public class Communicator
{
    private int count = 0;
    private List<Action> actionList = new List<Action>();

    public void AddListener(Action action)
    {
        if(actionList.Contains(action))
        {
        return;
        }
        actionList.Add(action);
        count = actionList.Count;
    }

    public void Invoke()
    {
        for(int i = count - 1; 0 <= i; i--)
        {
        actionList[i].Invoke();
        }
    }

    public void RemoveListener(Action action)
    {
        actionList.Remove(action);
        count = actionList.Count;
    }
    public void Clear()
    {
        for(int i = 0; i < count; i++)
        {
        actionList[i] = null;
        }
        actionList.Clear();
        count = 0;
    }
    }

    public class Communicator<T>
    {
    private int count = 0;
    private List<Action<T>> actionList = new List<Action<T>>();

    public void AddListener(Action<T> action)
    {
        if(actionList.Contains(action))
        {
        return;
        }
        actionList.Add(action);
        count = actionList.Count;
    }

    public void Invoke(T parameter1)
    {
        for(int i = count - 1; 0 <= i; i--)
        {
        actionList[i].Invoke(parameter1);
        }
    }

    public void RemoveListener(Action<T> action)
    {
        actionList.Remove(action);
        count = actionList.Count;
    }

    public void Clear()
    {
        for(int i = 0; i < count; i++)
        {
        actionList[i] = null;
        }
        actionList.Clear();
        count = 0;
    }
    }

    public class Communicator<T, T2>
    {
    private int count = 0;
    private List<Action<T, T2>> actionList = new List<Action<T, T2>>();

    public void AddListener(Action<T, T2> action)
    {
        if(actionList.Contains(action))
        {
        return;
        }
        actionList.Add(action);
        count = actionList.Count;
    }

    public void Invoke(T parameter1, T2 parameter2)
    {
        for(int i = count - 1; 0 <= i; i--)
        {
        actionList[i].Invoke(parameter1, parameter2);
        }
    }

    public void RemoveListener(Action<T, T2> action)
    {
        actionList.Remove(action);
        count = actionList.Count;
    }
    public void Clear()
    {
        for(int i = 0; i < count; i++)
        {
        actionList[i] = null;
        }
        actionList.Clear();
        count = 0;
    }
    }
    public class Communicator<T, T2, T3>
    {
    private int count = 0;
    private List<Action<T, T2, T3>> actionList = new List<Action<T, T2, T3>>();

    public void AddListener(Action<T, T2, T3> action)
    {
        if(actionList.Contains(action))
        {
        return;
        }
        actionList.Add(action);
        count = actionList.Count;
    }

    public void Invoke(T parameter1, T2 parameter2, T3 parameter3)
    {
        for(int i = count - 1; 0 <= i; i--)
        {
        actionList[i].Invoke(parameter1, parameter2, parameter3);
        }
    }

    public void RemoveListener(Action<T, T2, T3> action)
    {
        actionList.Remove(action);
        count = actionList.Count;
    }

    public void Clear()
    {
        for(int i = 0; i < count; i++)
        {
        actionList[i] = null;
        }
        actionList.Clear();
        count = 0;
    }
    }

    public class Communicator<T, T2, T3, T4>
    {
    private int count = 0;
    private List<Action<T, T2, T3, T4>> actionList = new List<Action<T, T2, T3, T4>>();

    public void AddListener(Action<T, T2, T3, T4> action)
    {
        if(actionList.Contains(action))
        {
        return;
        }
        actionList.Add(action);
        count = actionList.Count;
    }

    public void Invoke(T parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        for(int i = count - 1; 0 <= i; i--)
        {
        actionList[i].Invoke(parameter1, parameter2, parameter3, parameter4);
        }
    }

    public void RemoveListener(Action<T, T2, T3, T4> action)
    {
        actionList.Remove(action);
        count = actionList.Count;
    }

    public void Clear()
    {
        for(int i = 0; i < count; i++)
        {
        actionList[i] = null;
        }
        actionList.Clear();
        count = 0;
    }
}