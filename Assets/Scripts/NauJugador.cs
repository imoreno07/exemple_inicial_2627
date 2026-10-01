using UnityEngine;
using UnityEngine.InputSystem;

public class NauJugador : MonoBehaviour
{
    float vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vel = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentJugador();
        ControlLimitsPantalla();
    }

    void ControlLimitsPantalla()
    {
        Vector3 posicioActual = transform.position;

        posicioActual.x = Mathf.Clamp(
            posicioActual.x,
            ValorsGlobals.limitEsquerraX,
            ValorsGlobals.limitDretaX
        );

        posicioActual.y = Mathf.Clamp(
            posicioActual.y,
            ValorsGlobals.LimitInferiorY,
            ValorsGlobals.limitSuperiorY
        );

        transform.position = posicioActual;
    }

    void MovimentJugador()
    {
        //Mirem si el juagdor fa el moviment horitzontal. Decidim fer server les tecles "a" i "d".
       float movimentHorizontal = Keyboard.current.aKey.isPressed ? -1f : Keyboard.current.dKey.isPressed ? 1f : 0f;
       //només 3 possibles valors per movimentHorizontal:
       // -1 (esquerra), 0 (quiet) o 1 (dreta)

       float movimentVertical = Keyboard.current.sKey.isPressed ? -1f : Keyboard.current.wKey.isPressed ? 1f : 0f;

       //Vector3: té tres components o numeros: el x, el y i el z. L'ordre és (x, y, z).
       Vector3 vectorDesplacament = new Vector3(movimentHorizontal, movimentVertical, 0);

       //Per assegurar-nos que la direccio no afecta la velocitat, normalitzem el vectorDesplacament.
       vectorDesplacament = vectorDesplacament.normalized;

       //Movem l'objecte segons: 1) la direccio (vectorDesplacament) i 2) la velocitat (vel).
       Vector3 nouDesplacament = new Vector3(
        vel * vectorDesplacament.x * Time.deltaTime,
        vel * vectorDesplacament.y * Time.deltaTime,
        0f
       );

        //transform.position: es la posicio de l'objecte que te assignat aquest script.
        transform.position += nouDesplacament;
    }
}
