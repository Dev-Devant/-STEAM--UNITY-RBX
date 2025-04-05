using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour{
    

    private Stats playerStats;
    public TextMeshProUGUI healthDisplay;
    
    void Start()    {
        GameObject player = GameObject.Find("Player");
        if (player == null){
            Debug.LogError("GUI FUERA DE LINEA. No puso un player valido ( Debe llamarse Player). por favor programa bien!");
            return;
        }

        playerStats = player.GetComponent<Stats>();
        healthDisplay.text = "AAAAAAAA";
    }

    void Update()    {
        if (playerStats == null){
            Debug.LogError("GUI FUERA DE LINEA. El jugador no posee estadisticas compatibles");
            return;
        }
    }


}
