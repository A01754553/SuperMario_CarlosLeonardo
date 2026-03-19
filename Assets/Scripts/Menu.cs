using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
// Carlos Leonardo Gonzalez Vilchis
public class Menu : MonoBehaviour
{
    private UIDocument menu;

    private Button botonJugar;
    private Button botonAyuda;
    private Button cerrarAyuda;
    private Button botonCreditos;
    private Button cerrarCreditos;
    private Button botonSalir;

    private VisualElement menuPrincipal;
    private VisualElement panelAyuda;
    private VisualElement panelCreditos;

    private VisualElement titulo;
    private VisualElement nombre;
    private VisualElement areaCreditos;

    private Label textoCreditos;

    private float posicionY;
    private float velocidad = 0.5f;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();

        var root = menu.rootVisualElement;

        // obtener todos los elementos de la ui
        botonJugar = root.Q<Button>("BotonJugar");
        botonAyuda = root.Q<Button>("BotonAyuda");
        cerrarAyuda = root.Q<Button>("CerrarAyuda");
        botonCreditos = root.Q<Button>("BotonCreditos");
        cerrarCreditos = root.Q<Button>("CerrarCreditos");
        botonSalir = root.Q<Button>("BotonSalir");

        menuPrincipal = root.Q<VisualElement>("Menu");
        panelAyuda = root.Q<VisualElement>("PanelAyuda");
        panelCreditos = root.Q<VisualElement>("Creditos");

        titulo = root.Q<VisualElement>("Titulo");
        nombre = root.Q<VisualElement>("Nombre");
        areaCreditos = root.Q<VisualElement>("AreaCreditos");

        textoCreditos = root.Q<Label>("TextoCreditos");

        // conectar botones con funciones
        botonJugar.RegisterCallback<ClickEvent>(AbrirJugar);
        botonAyuda.RegisterCallback<ClickEvent>(AbrirAyuda);
        cerrarAyuda.RegisterCallback<ClickEvent>(CerrarAyuda);
        botonCreditos.RegisterCallback<ClickEvent>(AbrirCreditos);
        cerrarCreditos.RegisterCallback<ClickEvent>(CerrarCreditos);
    }

    void Update()
    {
        // mover texto solo cuando creditos estan activos
        if (panelCreditos.style.display == DisplayStyle.Flex)
        {
            posicionY -= velocidad;
            textoCreditos.style.top = posicionY;

            float alturaTexto = textoCreditos.resolvedStyle.height;
            float alturaArea = areaCreditos.resolvedStyle.height;

            // reinicia posicion para scroll infinito
            if (posicionY < -alturaTexto)
            {
                posicionY = alturaArea;
                textoCreditos.style.top = posicionY;
            }
        }
    }

    private void AbrirJugar(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void AbrirAyuda(ClickEvent evt)
    {
        menuPrincipal.style.display = DisplayStyle.None;
        panelAyuda.style.display = DisplayStyle.Flex;
    }

    private void CerrarAyuda(ClickEvent evt)
    {
        panelAyuda.style.display = DisplayStyle.None;
        menuPrincipal.style.display = DisplayStyle.Flex;
    }

    private void AbrirCreditos(ClickEvent evt)
    {
        // ocultar menu y mostrar creditos
        menuPrincipal.style.display = DisplayStyle.None;
        panelCreditos.style.display = DisplayStyle.Flex;

        titulo.style.display = DisplayStyle.None;
        nombre.style.display = DisplayStyle.None;
        botonSalir.style.display = DisplayStyle.None;

        // posicion inicial del scroll
        posicionY = areaCreditos.resolvedStyle.height;
        textoCreditos.style.top = posicionY;
    }

    private void CerrarCreditos(ClickEvent evt)
    {
        // regresar al menu principal
        panelCreditos.style.display = DisplayStyle.None;
        menuPrincipal.style.display = DisplayStyle.Flex;

        titulo.style.display = DisplayStyle.Flex;
        nombre.style.display = DisplayStyle.Flex;
        botonSalir.style.display = DisplayStyle.Flex;
    }
}
