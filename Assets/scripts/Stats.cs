using UnityEngine;

public class Stats : MonoBehaviour{

    public float health = 100;
    public float healthRegen = 10;
    public float healthMax = 100;
    public bool canHealSelf = false;
    public bool graveWhonts = false;

    public float damage = 30;

    public bool alive = true;
    void Start() {
        
    }

    void Update()    {
        pasiveHeal();
    }

    private void pasiveHeal(){
        if (!alive || !canHealSelf || health > healthMax){return;}
        health += healthRegen * Time.deltaTime;
        if(health > healthMax){; health = healthMax;}
    }


    public void takeDamage(float dealDamage){
        if (!alive || dealDamage < 0){return;}
        health -= dealDamage;
        if(health <= 0){ alive = false; health = 0;}
    }
}
