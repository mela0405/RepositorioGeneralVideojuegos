using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class SkyboxController : MonoBehaviour
{
    [Header("Materiales de Skybox")]
    public Material skyboxDia;
    public Material skyboxNoche;

    [Header("Estado inicial")]
    public bool esDeNoche = false;

    private void Update()
    {
        if (PresionoTeclaN())
        {
            AlternarSkybox();
        }
    }

    private bool PresionoTeclaN()
    {
#if ENABLE_INPUT_SYSTEM
        return Keyboard.current != null && Keyboard.current.nKey.wasPressedThisFrame;
#elif ENABLE_LEGACY_INPUT_MANAGER
        return Input.GetKeyDown(KeyCode.N);
#else
        return false;
#endif
    }

    private void AlternarSkybox()
    {
        esDeNoche = !esDeNoche;

        if (esDeNoche)
        {
            RenderSettings.skybox = skyboxNoche;
        }
        else
        {
            RenderSettings.skybox = skyboxDia;
        }

        DynamicGI.UpdateEnvironment();

        Debug.Log("Skybox cambiado a: " + (esDeNoche ? "Noche" : "Dia"));
    }
}
