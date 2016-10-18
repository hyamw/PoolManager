using UnityEngine;
using System.Collections;

public class OnNotify : MonoBehaviour {

	public void OnSpawned()
    {
        Debug.LogFormat("--- OnSpawned, go:{0}", name);
    }

    public void OnDespawned()
    {
        Debug.LogFormat("--- OnDespawned, go:{0}", name);
    }
}
