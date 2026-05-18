using UnityEngine;
using UnityEngine.InputSystem; // Obligatoire pour le nouveau système

public class PlaneController : MonoBehaviour
{
    [Header("Propulsion")]
    public Transform propeller;
    public float propellerMultiplier = 1500f;
    public float thrustForce = 20f;

    [Header("Contrôles")]
    public float pitchSpeed = 60f;
    public float rollSpeed = 80f;

    [Header("Effets")]
    public ParticleSystem smokeParticles;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // --- 5. INPUT JUMP (Espace) ---
        // On vérifie si la touche Espace est pressée
        bool isJumpPressed = Keyboard.current.spaceKey.isPressed;
        float jumpValue = isJumpPressed ? 1.0f : 0.0f;

        if (isJumpPressed)
        {
            // 5.1 Rotation hélice
            propeller.Rotate(Vector3.forward * jumpValue * propellerMultiplier * Time.deltaTime);
            // 5.2 Force vers l'avant
            rb.AddForce(transform.forward * jumpValue * thrustForce);

            // 8.1 Particules
            if (!smokeParticles.isPlaying) smokeParticles.Play();
        }
        else
        {
            if (smokeParticles.isPlaying) smokeParticles.Stop();
        }

        // --- 6. AXE VERTICAL (Flèches Haut/Bas ou W/S) ---
        float vertical = 0;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) vertical = 1;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) vertical = -1;

        transform.Rotate(Vector3.right * vertical * pitchSpeed * Time.deltaTime);

        // --- 7. AXE HORIZONTAL (Flèches Gauche/Droite ou A/D) ---
        float horizontal = 0;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) horizontal = 1;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) horizontal = -1;

        transform.Rotate(Vector3.forward * -horizontal * rollSpeed * Time.deltaTime);
    }
}