using UnityEngine;
public class playerController : MonoBehaviour{

    private Stats stats;


    void Start()    {
        stats = GetComponent<Stats>();
    }
    void Update()    {
        moveControl();

        if (Input.GetKeyDown(KeyCode.P)){
            dealDamageTest();
        }

    }

    private void dealDamageTest(){
        stats.takeDamage(20);
        Debug.Log("Daño realizado con exito");
    }


    private void moveControl(){
        Vector3 direccion = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) {
            direccion += -Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S)) {
            direccion += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.A)) {
            direccion += Vector3.right;
        }
        if (Input.GetKey(KeyCode.D)) {
            direccion += -Vector3.right;
        }

        Vector3 rotacion = Vector3.zero;

        if (Input.GetKey(KeyCode.Q)) {
            rotacion += -Vector3.up * 90;
        }
        if (Input.GetKey(KeyCode.E)) {
            rotacion += Vector3.up * 90;
        }
        
        float delta = Time.deltaTime;

        transform.Rotate(rotacion * delta);

        transform.Translate(direccion * stats.speed * delta);
    }

}
