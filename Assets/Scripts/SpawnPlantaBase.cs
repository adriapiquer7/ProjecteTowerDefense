using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SpawnPlantaBase : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    
    [Header("Input")]
    [SerializeField] private InputActionReference _inputCrearRef;
    private InputSystem_Actions _inputactions;
    [Header("Funcionalitat")]
    [SerializeField] private GameObject _prefabPlanta;
    [SerializeField] private SOPlantaBase[] _plantas;

    private void Awake()
    {
        _inputCrearRef.action.performed += OnCrearPlanta;
        _inputactions = new InputSystem_Actions();
        _inputactions.UI.Enable();
    }

    private void OnDestroy()
    {
        _inputCrearRef.action.performed -= OnCrearPlanta;
    }
     void Update()
    {
        GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition);
    }

    private void OnCrearPlanta(InputAction.CallbackContext context)
    {
        GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition);
        Vector3 posicioSpawn = cellPosition;
        posicioSpawn.z = 0;

        GameObject planta = Instantiate(_prefabPlanta);
        planta.GetComponent<PlantaBaseBehaviour>().Iniciar(posicioSpawn, _plantas[Random.Range(0, _plantas.Length)]);
    }
    private void GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition)
    {
        Vector2 mouseViewportCoordinates = _inputactions.UI.Point.ReadValue<Vector2>();
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mouseViewportCoordinates);
        cellPosition = _tilemap.WorldToCell(worldPoint);
        worldPosition = _tilemap.GetCellCenterWorld(cellPosition);
    }
}
