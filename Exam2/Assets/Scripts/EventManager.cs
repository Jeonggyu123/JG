using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, List<Action<object>>> m_EventDatabase;

    public static EventManager getInstance;

    private void Awake()
    {
        getInstance = this;
        m_EventDatabase = new Dictionary<string, List<Action<object>>>();
    }
    
    //이벤트가 발동할 때 행할 행동들을 정의
    public void EventDefinition(string eventName, Action<object> action)
    {
        //이벤트 db에 공간이 있는지 확인 
        if(!m_EventDatabase.ContainsKey(eventName))
        {
            m_EventDatabase.Add(eventName, new List<Action<object>>());
            
        }

        m_EventDatabase[eventName].Add(action);

    }

    //이벤트를 발동 시킴
    public void Emit(string eventName, object param)
    {
        //해당 키값이 존재하는지 확인해야함
       if(!m_EventDatabase.ContainsKey(eventName))
        {
            print(eventName + " 가 존재하지 않음");
        }
        else
        {
            if(m_EventDatabase[eventName].Count>0)
            {
                foreach (var action in m_EventDatabase[eventName])
                {
                    action.Invoke(param);
                }
            }
        }

    }

}
