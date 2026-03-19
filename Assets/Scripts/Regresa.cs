using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
// Carlos Leonardo Gonzalez Vilchis
public class Regresa : MonoBehaviour
{
    private UIDocument menu;
    private Button botonRegresa;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonRegresa = root.Q<Button>("BotonRegresar");
        botonRegresa.clicked += Regresar;
    }


    void OnDisable()
    {
        botonRegresa.clicked -= Regresar;
    }

    void Regresar()
    {
        SceneManager.LoadScene("Menu");
    }
}
