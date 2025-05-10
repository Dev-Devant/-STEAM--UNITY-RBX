using UnityEngine;
public class playerController : MonoBehaviour{

    private Stats stats;

    private Animator animator;

    public Camera cam ;
    public GameObject projectile;

    void Start()    {
        stats = GetComponent<Stats>();
        animator = GetComponent<Animator>();

    }
    void Update()    {
        moveControl();
        fireManagement ();
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
        float[] inputsAnimatiosn = {};

        bool w = Input.GetKey(KeyCode.W);
        bool s = Input.GetKey(KeyCode.S);
        bool a = Input.GetKey(KeyCode.A);
        bool d = Input.GetKey(KeyCode.D);

        if (w) {
            direccion += Vector3.forward;
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(4, 0);
        }
        if (s) {
            direccion += -Vector3.forward;
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 1);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(4, 0);
        }

        if (a) {
            direccion += -Vector3.right;
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 1);
            animator.SetLayerWeight(4, 0);
        }
        if (d) {
            direccion += Vector3.right;
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(4, 1);
        }

        if ( !(a || w || s || d) ){
            //// aaaaaaaaaaa

        }

            setAnimationWeights(inputsAnimatiosn);

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

    void setAnimationWeights(float[] inputs){
        for (int i = 0; i < inputs.Length;i++){
             animator.SetLayerWeight(i, inputs[i]);
        }
    }

    void fireManagement (){
        if(Input.GetButtonDown("Fire1")){
            Vector3 target = obtenerPuntoDeMira();
            if(target != Vector3.zero){
                GameObject shoot = Instantiate(projectile,transform.position + Vector3.forward * 2,Quaternion.identity);
                Rigidbody shootrb = shoot.GetComponent<Rigidbody>();
                Vector3 trajectory = (target -shoot.transform.position).normalized;
                float force = 50;
                shootrb.AddForce(trajectory * force,ForceMode.Impulse);


            }

        }

    }

    Vector3 obtenerPuntoDeMira(){
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit)){
            return hit.point;
        }
        return Vector3.zero;
    }


}
