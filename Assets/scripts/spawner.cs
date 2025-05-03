using UnityEngine;

public class spawner : MonoBehaviour{

    public GameObject[] Enemy ;

    public float range = 30;
    public int cantidad = 10;

    void Start()    {    
        for (int i = 0;i<cantidad;i++){
            Vector3 pos = randomPonintInCircle(transform.position,range);
            Quaternion rot = Quaternion.identity;
            Instantiate(Enemy[dize(Enemy.Length)], pos ,rot);
        }         
    }

    void Update()    {    
    }

    Vector3 randomPonintInCircle(Vector3 Centro, float radio){
        float r = Random.Range(0,radio);
        float a = Random.Range(0, 2 * Mathf.PI);

        float x = r * Mathf.Cos(a);
        float z = r * Mathf.Sin(a);
        float y = 1;
        return Centro + new Vector3 (x,y,z);
    }

    int dize(int max){
        return (int)Random.Range(0,max);

    }


    void OnDrawGizmos() {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }


}
