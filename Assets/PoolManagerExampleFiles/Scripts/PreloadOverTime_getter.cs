using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

public class PreloadOverTime_getter : MonoBehaviour {

    public float intervalTime = 1f;
    public int count = 5;
    public string poolName = "";
    public Transform prefab = null;
    private List<Transform> useObjList;

	// Use this for initialization
	void Start () {
        useObjList = new List<Transform>(count);
        StartCoroutine(Getter());
	}
	
    IEnumerator Getter()
    {
        SpawnPool sp = PoolManager.Pools[poolName];
        for (int i = 0; i < count; ++i)
        {
            Transform tf = sp.Spawn(prefab, transform.position, Quaternion.identity, transform);
            useObjList.Add(tf);
            yield return new WaitForSeconds(intervalTime);
        }

        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        SpawnPool sp = PoolManager.Pools[poolName];
        foreach(var tf in useObjList)
        {
            sp.Despawn(tf, sp.transform);
            yield return new WaitForSeconds(intervalTime);
        }
        useObjList.Clear();

        StartCoroutine(Getter());
    }

}
