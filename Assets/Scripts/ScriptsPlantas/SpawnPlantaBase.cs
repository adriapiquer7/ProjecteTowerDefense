using System;
using TMPro;
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
    [SerializeField]
    private TextMeshProUGUI _moneyText;

    private SOPlantaBase _plantToBuild;

    private bool _building = false;
    [SerializeField]
    private SOInt _money;
    public event Action<int> OnDisplayMoney;    
    public event Action<SOPlantaBase[]> OnDisplayPlantas;
    int[,] jardin = new int[5, 18];
    
    private TileMapManager _tilemapManager;
    private void Awake()
    {
        _inputactions = new InputSystem_Actions();
        _tilemapManager = GetComponent<TileMapManager>();

        PlantaBaseBehaviour.OnDead += PlantaDestroyed;
    }

    void Start()
    {
        DisplayMoney(_money.Value);
        OnDisplayPlantas?.Invoke(_plantas);
    }

    void OnEnable()
    {
        _money.OnValueChanged += OnDisplayMoney;
        _inputactions.UI.Enable();
    }

    void OnDisable()
    {
        _money.OnValueChanged -= OnDisplayMoney;
        _inputactions.UI.Disable();
        PlantaBaseBehaviour.OnDead -= PlantaDestroyed;
    }

    void Update()
    {
        if(_building)
            GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition);
    }

    public void OnBuild(SOPlantaBase planta)
    {
        if(_money.Value<=planta.Cost)
            return;
        
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
                if (!TryPurchase(_plantToBuild))
                {
                    OnCancelBuilding(default);
                    return;
                }
                GameObject planta = Instantiate(_prefabPlanta);
                planta.GetComponent<PlantaBaseBehaviour>().Iniciar(posicioSpawn, _plantToBuild);
                jardin[cellPosition.y*-1,cellPosition.x]=1;
                
                OnCancelBuilding(default);
            }
        }
    }

    private void PlantaDestroyed(Vector3 position)
    {
        Vector3Int cellPosition = _tilemap.WorldToCell(position);
        Debug.Assert(jardin[cellPosition.y*-1,cellPosition.x] == 1, $"PlantaDestroyed coordinates error at [{cellPosition.y},{cellPosition.x}]");
        jardin[cellPosition.y*-1,cellPosition.x]=0;
    }


    private void GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition)
    {
        Vector2 mousePosition = _inputactions.UI.Point.ReadValue<Vector2>();
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        cellPosition = _tilemap.WorldToCell(worldPoint);
        worldPosition = _tilemap.GetCellCenterWorld(cellPosition);
        Debug.Log(cellPosition.y);
        Debug.Log(cellPosition.x);
    }

    public bool TryPurchase(SOPlantaBase item)
    {
        if (item.Cost <= _money.Value)
        {
            _money.Value -= item.Cost;
            return true;
        }

        return false;
    }
    private void DisplayMoney(int money)
    {
        _moneyText.text = money.ToString();
    }
}
