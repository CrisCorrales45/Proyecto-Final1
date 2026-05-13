using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    private Rigidbody2D rb;
    private bool enElSuelo;

    // Variables para la animación
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Le decimos al código que busque los componentes en el personaje
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 1. Movimiento Horizontal
        float movimientoX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);

        // --- ANIMACIÓN Y DIRECCIÓN ---
        // Le mandamos al Animator la velocidad a la que nos movemos (Mathf.Abs lo vuelve siempre positivo)
        animator.SetFloat("Speed", Mathf.Abs(movimientoX));

        // Si nos movemos a la derecha, no volteamos el sprite
        if (movimientoX > 0)
        {
            spriteRenderer.flipX = false;
        }
        // Si nos movemos a la izquierda, volteamos el sprite
        else if (movimientoX < 0)
        {
            spriteRenderer.flipX = true;
        }

        // 2. Salto
        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            enElSuelo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        // Esto hará que Unity imprima en la consola qué es lo que estamos pisando
        Debug.Log("Estoy tocando: " + colision.gameObject.name + " con el tag: " + colision.gameObject.tag);

        if (colision.gameObject.CompareTag("Ground"))
        {
            enElSuelo = true;
            Debug.Log("¡Puedo saltar!"); // Nos avisa si reconoció el suelo
        }
    }
}