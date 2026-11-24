using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SpawnPlantaBase : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    
    [Header("Input")]
    private InputSystem_Actions _inputactions;
    [Header("Funcionalitat")]
    [SerializeField] private GameObject _prefabPlanta;
    [SerializeField] private SOPlantaBase[] _plantas;

    private SOPlantaBase _plantToBuild;

    private bool _building = false;

    public event Action<SOPlantaBase[]> OnDisplayPlantas;
    int[,] jardin = new int[5, 18];
    
    private TileMapManager _tilemapManager;
    private void Awake()
    {
        _inputactions = new InputSystem_Actions();
        _tilemapManager = GetComponent<TileMapManager>();
    }
    void Start()
    {
        OnDisplayPlantas?.Invoke(_plantas);
    }

    void OnEnable()
    {
        _inputactions.UI.Enable();
    }

    void OnDisable()
    {
        _inputactions.UI.Disable();
    }

    void Update()
    {
        if(_building)
            GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition);
    }

    public void OnBuild(SOPlantaBase planta)
    {
        _building = true;
        _plantToBuild = planta;
        _tilemapManager.StartBuilding(planta);
        _inputactions.UI.Click.performed += OnCrearPlanta;
        _inputactions.UI.RightClick.performed += OnCancelBuilding;
    }

    private void OnCancelBuilding(InputAction.CallbackContext context)
    {
        _building = false;
        _tilemapManager.StopBuilding();
        _inputactions.UI.Click.performed -= OnCrearPlanta;
        _inputactions.UI.RightClick.performed -= OnCancelBuilding;
    }

    private void OnCrearPlanta(InputAction.CallbackContext context)
    {
        if(context.action.ReadValue<float>()!=1.0f)
        return;
        GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition);
        Vector3 posicioSpawn = worldPosition;
        posicioSpawn.z = -2;
        if(cellPosition.y>=-4 && cellPosition.y <= 0)
        {
            if(jardin[cellPosition.y*-1, cellPosition.x] == 0)
            {
                GameObject planta = Instantiate(_prefabPlanta);
                planta.GetComponent<PlantaBaseBehaviour>().Iniciar(posicioSpawn, _plantToBuild);
                jardin[cellPosition.y*-1,cellPosition.x]=1;
                
                OnCancelBuilding(default);
            }
        }
    }
    private void GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition)
    {
        Vector2 mousePosition = _inputactions.UI.Point.ReadValue<Vector2>();
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        cellPosition = _tilemap.WorldToCell(worldPoint);
        worldPosition = _tilemap.GetCellCenterWorld(cellPosition);
    }
}
