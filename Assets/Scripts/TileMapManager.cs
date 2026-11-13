using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;

    [SerializeField]
    private GameObject _editGameObject;

    private InputSystem_Actions _inputactions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _inputactions = new InputSystem_Actions();

        _inputactions.UI.Enable();
    }

    void Update()
    {
        GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition);
        if(cellPosition.y>=-4 && cellPosition.y <= 0)
        {
            worldPosition.z = 0;
            _editGameObject.transform.position = worldPosition;
        }
        //Debug.Log($"{worldPosition} - {cellPosition}");
    }

    private void GetTileAtCurrentPointerPosition(out Vector3 worldPosition, out Vector3Int cellPosition)
    {
        Vector2 mouseViewportCoordinates = _inputactions.UI.Point.ReadValue<Vector2>();
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mouseViewportCoordinates);
        cellPosition = _tilemap.WorldToCell(worldPoint);
        worldPosition = _tilemap.GetCellCenterWorld(cellPosition);
    }
}
