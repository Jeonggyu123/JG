using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    public static ObjectPoolManager getInstance;

    public List<PrefabObjectKeyValuePair> m_ManagedPrefabs;

    private Dictionary<string, List<GameObject>> m_ObjectPool;

    //�ش� ������Ʈ�� �����ϴ� Ű�ͺ���
    [Serializable]
    public struct PrefabObjectKeyValuePair
    {
        public string name;
        public GameObject prefab;
    }
    private void Awake()
    {
        getInstance = this;
        m_ObjectPool = new Dictionary<string, List<GameObject>>();
    }
    
    public GameObject Spawn(string spawnObjectName, Vector3 position = default, Quaternion rotation = default)
    {
        //�ش� ������Ʈ�� �ִ��� Ȯ�� , �̸��� ���� �ҷ�������� �̸��� �ش��ϴ� ������Ʈ�� �������� �ʴ´ٸ� �޼������ �ϰ� ����
        if(!m_ManagedPrefabs.Exists(KeyValuePair => KeyValuePair.name == spawnObjectName))
        {
            print(spawnObjectName + " ��� �������� �������� �ʽ��ϴ�");
            return null;
        }

        //�ش��̸��� �ҷ��������ϴ°��߿� �����̸��̸� �ҷ���
        PrefabObjectKeyValuePair foundedPrefabData = m_ManagedPrefabs.FirstOrDefault(pair => pair.name == spawnObjectName);

        //������ �����̳� ����, �ش� Ű���� ������ ����� Ȯ��
        if(!m_ObjectPool.ContainsKey(spawnObjectName))
        {
            m_ObjectPool.Add(spawnObjectName, new List<GameObject>());
        }
        //������Ʈ Ǯ�� ���ӿ�����Ʈ�߿� ��Ȱ��ȭ�� �� ���ӿ�����Ʈ�� ������ ��ȯ�ް� �ƴϸ� null��
        GameObject founded = m_ObjectPool[spawnObjectName].FirstOrDefault(go => !go.activeInHierarchy);

        if(founded != null)
        {
            founded.SetActive(true);
        }
        //ã������ ������ ������ִ°���
        else
        {
            founded = Instantiate(foundedPrefabData.prefab);
            m_ObjectPool[spawnObjectName].Add(founded);
        }

        //�������̶� �����̼� ����
        if (position != default) founded.transform.position = position;
        if (rotation != default) founded.transform.rotation = rotation;

        return founded;

    }


    


   
}
