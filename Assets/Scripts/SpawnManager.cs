using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject Map;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Map, new Vector3(-0.810000002f, 0, -0.265497923f) , new Quaternion(0, 0, 0, 1));
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
