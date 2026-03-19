using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private UIDocument menu;

    private Button botonJugar;
    private Button botonAyuda;
    private Button cerrarAyuda;

    private VisualElement menuPrincipal;
    private VisualElement panelAyuda;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();

        var root = menu.rootVisualElement;

        botonJugar = root.Q<Button>("BotonJugar");
        botonAyuda = root.Q<Button>("BotonAyuda");
        cerrarAyuda = root.Q<Button>("CerrarAyuda");

        menuPrincipal = root.Q<VisualElement>("Menu");
        panelAyuda = root.Q<VisualElement>("PanelAyuda");

        botonJugar.RegisterCallback<ClickEvent>(AbrirJugar);
        botonAyuda.RegisterCallback<ClickEvent>(AbrirAyuda);
        cerrarAyuda.RegisterCallback<ClickEvent>(CerrarAyuda);
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
}
