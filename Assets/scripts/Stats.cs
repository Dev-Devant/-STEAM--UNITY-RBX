using UnityEngine;

public class Stats : MonoBehaviour{
    /// <summary>
    /// Variables de salud
    /// </summary>
    public float health = 100;
    public float healthRegen = 10;
    public float healthMax = 100;
    public float pasiveHealColdown = 30;

    public bool canHealSelf = false;
    public bool graveWhonts = false;
    public bool alive = true;
    /// <summary>
    /// Variables de daño
    /// </summary>
    public float damage = 30;
    public float coldDawn = 3;

    /// <summary>
    /// Variables de movimiento
    /// </summary>
    
    public float speed = 10;
    public float attactRange = 1.0f;
    public float detectRadius = 10;

    public float patrolRadius = 10;
       
    /// <summary>
    /// Variables de comportamiento
    /// </summary>

    public bool hostileToPlayer = true;
    public bool canAttact = false;

    /// <summary>
    /// Variables de control para las mecanicas
    /// </summary>
    
    private float coldDawnTimer = 0;
    private float pasiveHealTimer = 0;


    void Start() {
        
    }

    void Update()    {
        pasiveHeal();
        damageControl();
    }

    private void pasiveHeal(){
        if (!alive || !canHealSelf || health > healthMax){return;}
        if(pasiveHealTimer < pasiveHealColdown){return;}
        health += healthRegen * Time.deltaTime;
        if(health > healthMax){; health = healthMax;}        
    }

    private void damageControl(){
        if(canAttact){
            if(coldDawnTimer > 0 ){
                coldDawnTimer -= Time.deltaTime;
            } else{
                canAttact = false;
                coldDawnTimer = coldDawn;  
            }
        }
    }

    public void takeDamage(float dealDamage){
        if (!alive || dealDamage < 0){return;}
        health -= dealDamage;
        if(health <= 0){ alive = false; health = 0;}
        pasiveHealTimer = 0;
        if(pasiveHealTimer < pasiveHealColdown){
            pasiveHealTimer += Time.deltaTime;
        }
    }
}
