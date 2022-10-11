using UnityEngine;

public class PlayerMoveForce : MonoBehaviour
{
    private CharacterController controller;
    private GameObject camara;

    [Header("Estadisticas normales")]
    [SerializeField] private float velocidad;
    [SerializeField] private float alturaDeSalto;
    [SerializeField] private float tiempoAlGirar;

    [Header("Datos sobre el suelo")]
    [SerializeField] private Transform detectaSuelo;
    [SerializeField] private float distanciaSuelo;
    [SerializeField] private LayerMask mascaraSuelo;

    float velocidadGiro;
    float gravedad = -9.81f;
    Vector3 velocity;
    bool tocarSuelo;

    Animator playerAnimator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        tocarSuelo = Physics.CheckSphere(detectaSuelo.position, distanciaSuelo, mascaraSuelo);

        if(tocarSuelo && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && tocarSuelo)
        {
            velocity.y = Mathf.Sqrt(alturaDeSalto * -2 * gravedad);
        }

        velocity.y += gravedad * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        if(direccion.magnitude <= 0)
        {
            playerAnimator.SetFloat("Movements", 0, 0.1f, Time.deltaTime);
        }
        

        if(direccion.magnitude >= 0.1f)
        {
            float objetivoAngulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.transform.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, objetivoAngulo, ref velocidadGiro, tiempoAlGirar);
            transform.rotation = Quaternion.Euler(0, angulo, 0);

            Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
            controller.Move(mover.normalized * velocidad * Time.deltaTime);
            playerAnimator.SetFloat("Movements", 1, 0.1f, Time.deltaTime);
        }
    }
}
    