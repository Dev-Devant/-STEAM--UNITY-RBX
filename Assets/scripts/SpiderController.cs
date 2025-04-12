using Unity.VisualScripting;
using UnityEngine;

public class SpiderController : MonoBehaviour{

    private Stats stats;
    private IABase IA;

    void Start()    {
        stats = GetComponent<Stats>();
        IA = GetComponent<IABase>();
        if (IA == null){Debug.LogError("No contiene IA base disponible");}
        if (stats == null){Debug.LogError("Npc no contiene stats compatibles. Revisar componentes");}
    }

    void Update()    {
        GameObject detected = IA.detectPlayer();

        if (detected != null){
            if(IA.isOnAttactRange(detected.transform.position)){
                if(!stats.canAttact){
                    detected.GetComponent<Stats>().takeDamage(stats.damage);
                    stats.canAttact = true;
                }
            }else{
                IA.moveTo(detected.transform.position);
            }
        }

    }
}
