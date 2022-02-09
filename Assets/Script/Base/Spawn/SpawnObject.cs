using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPlaces;
    [SerializeField] private List<PoolObject> _prefabs;

    private void Start()
    {
        StartSpawn();
    }
    
    private void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            foreach (var item in _spawnPlaces)
            {
                int range = Random.Range(0, _prefabs.Count );
                PoolManager.Instance.ReuseObject(_prefabs[range], item.transform.position);
                yield return new WaitForSeconds(1f);
            }
            
        }
                
    }
}
