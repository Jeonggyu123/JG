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

    //해당 오브젝트에 상응하는 키와벨류
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
        //해당 오브젝트가 있는지 확인 , 이름이 만약 불러오고싶은 이름에 해당하는 오브젝트가 존재하지 않는다면 메세지출력 하고 종료
        if(!m_ManagedPrefabs.Exists(KeyValuePair => KeyValuePair.name == spawnObjectName))
        {
            print(spawnObjectName + " 라는 프리팹이 존재하지 않습니다");
            return null;
        }

        //해당이름이 불러오려고하는거중에 같은이름이면 불러옴
        PrefabObjectKeyValuePair foundedPrefabData = m_ManagedPrefabs.FirstOrDefault(pair => pair.name == spawnObjectName);

        //폴링할 컨테이너 마련, 해당 키값이 마련이 됬는지 확인
        if(!m_ObjectPool.ContainsKey(spawnObjectName))
        {
            m_ObjectPool.Add(spawnObjectName, new List<GameObject>());
        }
        //오브젝트 풀에 게임오브젝트중에 비활성화가 된 게임오브젝트가 있으면 반환받고 아니면 null로
        GameObject founded = m_ObjectPool[spawnObjectName].FirstOrDefault(go => !go.activeInHierarchy);

        if(founded != null)
        {
            founded.SetActive(true);
        }
        //찾아진게 없으면 만들어주는거임
        else
        {
            founded = Instantiate(foundedPrefabData.prefab);
            m_ObjectPool[spawnObjectName].Add(founded);
        }

        //포지션이랑 로테이션 지정
        if (position != default) founded.transform.position = position;
        if (rotation != default) founded.transform.rotation = rotation;

        return founded;

    }


    


   
}
