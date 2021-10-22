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
    
    //�̺�Ʈ�� �ߵ��� �� ���� �ൿ���� ����
    public void EventDefinition(string eventName, Action<object> action)
    {
        //�̺�Ʈ db�� ������ �ִ��� Ȯ�� 
        if(!m_EventDatabase.ContainsKey(eventName))
        {
            m_EventDatabase.Add(eventName, new List<Action<object>>());
            
        }

        m_EventDatabase[eventName].Add(action);

    }

    //�̺�Ʈ�� �ߵ� ��Ŵ
    public void Emit(string eventName, object param)
    {
        //�ش� Ű���� �����ϴ��� Ȯ���ؾ���
       if(!m_EventDatabase.ContainsKey(eventName))
        {
            print(eventName + " �� �������� ����");
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
