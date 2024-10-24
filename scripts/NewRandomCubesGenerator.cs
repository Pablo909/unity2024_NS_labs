using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewRandomCubesGenerator : MonoBehaviour
{
     List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public int numberOfObjects = 10;
    public GameObject block;
    public List<Material> materials = new List<Material>();
    //public Material[] materials = new Material[4];
    void Start()
    {
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)transform.position.x-(int)transform.localScale.x*10/2, (int)transform.localScale.x*10).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)transform.position.z-(int)transform.localScale.z*10/2, (int)transform.localScale.z*10).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));
        // *10 gdyż obiekt Plane skaluje się x10
        for(int i=0; i<numberOfObjects; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            GameObject newCube = Instantiate(this.block, pos, Quaternion.identity);
            
            int randomMaterial = UnityEngine.Random.Range(0, materials.Count);
            newCube.GetComponent<MeshRenderer>().material = materials[randomMaterial];

            objectCounter++;
            yield return new WaitForSeconds(this.delay);
            //Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            //yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
