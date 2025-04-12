using UnityEngine;

public class IABase : MonoBehaviour{

    private Stats stats;

    private GameObject player;
    void Start()    {
        stats = GetComponent<Stats>();
        player = GameObject.Find("Player");

        if (player == null){Debug.LogError("Requiere que exista un modelo de jugador llamado Player");}
        if (stats == null){Debug.LogError("Npc no contiene stats compatibles. Revisar componentes");}

    }

    public void idleState(float maxIdleTime){
        /// aqui iria idle logic
    }

    public GameObject detectPlayer(){
        Vector3 distanceVector = player.transform.position - transform.position;
        float distance = distanceVector.magnitude;
        if (distance < stats.detectRadius){
            return player;
        }
        return null;
    } 

    public bool isOnAttactRange(Vector3 targetPos){
        Vector3 distanceVector = targetPos - transform.position;
        float distance = distanceVector.magnitude;
        if (distance < stats.attactRange){
            return true;
        }
        return false;
    }

    public void moveTo(Vector3 pointToWalk){
        Vector3 distanceVector = pointToWalk - transform.position;
        distanceVector = distanceVector.normalized;
        Vector3 newPos = transform.position+ distanceVector;
        transform.Translate(newPos * Time.deltaTime * stats.speed);
    }

}
