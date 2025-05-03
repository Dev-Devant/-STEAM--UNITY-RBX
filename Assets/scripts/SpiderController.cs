using Unity.VisualScripting;
using UnityEngine;

public class SpiderController : MonoBehaviour{

    private Stats stats;
    private IABase IA;

    private Vector3 pointToWalk;
    private float TimerToWalk;

    private bool canPatrol = true;

    void Start()    {
        stats = GetComponent<Stats>();
        IA = GetComponent<IABase>();
        if (IA == null){Debug.LogError("No contiene IA base disponible");}
        if (stats == null){Debug.LogError("Npc no contiene stats compatibles. Revisar componentes");}
        pointToWalk = randomPonintInCircle(transform.position,stats.patrolRadius);

        IA.moveTo(pointToWalk);

    }

    void Update()    {
        GameObject detected = IA.detectPlayer();

        if (detected != null){
            canPatrol = false;
            pointToWalk = randomPonintInCircle(transform.position,stats.patrolRadius);

            if(IA.isOnAttactRange(detected.transform.position)){
                if(!stats.canAttact){
                    detected.GetComponent<Stats>().takeDamage(stats.damage);
                    stats.canAttact = true;
                }
            }else{
                IA.moveTo(detected.transform.position);
            }
        } else{            
            canPatrol = true;
        }

        if (canPatrol){
            float dist = (transform.position - pointToWalk).magnitude;
            
            if (dist < 1){
                canPatrol = false;
            }else{
                IA.moveTo(pointToWalk);
            }          

        }

    }


    Vector3 randomPonintInCircle(Vector3 Centro, float radio){
        float r = Random.Range(0,radio);
        float a = Random.Range(0, 2 * Mathf.PI);

        float x = r * Mathf.Cos(a);
        float z = r * Mathf.Sin(a);
        float y = 1;
        return Centro + new Vector3 (x,y,z);
    }


}
