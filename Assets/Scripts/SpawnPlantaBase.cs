using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SpawnPlantaBase : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    
    [Header("Input")]
    //[SerializeField] private InputActionReference _inputCrearRef;
    private InputSystem_Actions _inputactions;
    [Header("Funcionalitat")]
    [SerializeField] private GameObject _prefabPlanta;
    [SerializeField] private SOPlantaBase[] _plantas;

    private void Awake()
    {
        _inputactions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        _inputactions.UI.Enable();
        _inputactions.UI.RightClick.performed += OnCrearPlanta;
    }

    void OnDisable()
    {
        _inputactions.UI.RightClick.performed -= OnCrearPlanta;
        _inputactions.UI.Disable();
    }

    private void OnCrearPlanta(InputAction.CallbackContext context)
    {
        GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition);
        Vector3 posicioSpawn = worldPosition;
        posicioSpawn.z = -1;
        if(cellPosition.y>=-4 && cellPosition.y <= 0)
        {
            GameObject planta = Instantiate(_prefabPlanta);
            planta.GetComponent<PlantaBaseBehaviour>().Iniciar(posicioSpawn, _plantas[Random.Range(0, _plantas.Length)]);
        }
        Debug.Log($"Spawn en: {posicioSpawn}");
    }
    private void GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition)
    {
        Vector2 mousePosition = _inputactions.UI.Point.ReadValue<Vector2>();
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        cellPosition = _tilemap.WorldToCell(worldPoint);
        worldPosition = _tilemap.GetCellCenterWorld(cellPosition);
    }
}
