using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour{
    private Stats playerStats;
    public TextMeshProUGUI healthDisplay;
    public RectTransform healthBar ;
    void Start()    {
        GameObject player = GameObject.Find("Player");
        if (player == null){
            Debug.LogError("GUI FUERA DE LINEA. No puso un player valido ( Debe llamarse Player). por favor programa bien!");
            return;
        }
        playerStats = player.GetComponent<Stats>();
    }

    void Update()    {
        if (playerStats == null){
            Debug.LogError("GUI FUERA DE LINEA. El jugador no posee estadisticas compatibles");
            return;
        }
        healthDisplay.text = "Vida: " + (int)playerStats.health;
        float percent = playerStats.health/playerStats.healthMax;
        healthBar.localScale = new Vector3 (percent,1,0);
    }
}
