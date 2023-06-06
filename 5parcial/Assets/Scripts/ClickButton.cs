using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    public Button boton;
    public List<GameObject> objetos;
    private int indiceActual;

    private void Start()
    {
        boton.onClick.AddListener(CambiarEstado);
        indiceActual = 0;
        CambiarEstado();
    }

    private void CambiarEstado()
    {
        // Apagar el objeto actual
        objetos[indiceActual].SetActive(false);

        // Incrementar el índice
        indiceActual++;
        if (indiceActual >= objetos.Count)
        {
            indiceActual = 0;
        }

        // Encender el siguiente objeto
        objetos[indiceActual].SetActive(true);
    }
}
