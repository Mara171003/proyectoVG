using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
   //El objeto a invocar
    [SerializeField]
    GameObject spawningObjectPrefab;

    //Cantidad del objeto a invocar
    [SerializeField]
    int spawningAmount = 40;

    //Distancia de invocación del objeto
    [SerializeField]
    float spawningRange = 20.0F;

    //Distancia entre el objeto y el jugador
    [SerializeField]
    float spawningSafeRange = 10.0F;

    List<GameObject> spawningObjects = new List<GameObject>();

    Vector3 spawningPoint;


    void Start()
    {
        for (int i = 0; i < spawningAmount; i++)
        {
            GetSpawningPoint();
            while(Vector3.Distance(spawningPoint, Vector3.zero) < spawningSafeRange)
            {
                GetSpawningPoint();
            }
            GameObject spawningObject = Instantiate (spawningObjectPrefab, spawningPoint,
                Quaternion.Euler(Random.Range(0.0F, 360.0F), Random.Range(0.0F, 360.0F), Random.Range(0.0F, 360.0F)));

            spawningObject.transform.parent = this.transform;
            spawningObjects.Add(spawningObject);

        }
    }

    void GetSpawningPoint ()
    {
        spawningPoint = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        if (spawningPoint.magnitude > 1.0F )
        {
            spawningPoint.Normalize();
        }
        spawningPoint *= spawningRange;
    }
}
