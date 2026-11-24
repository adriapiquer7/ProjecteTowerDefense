using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnZombieBase : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;

    [SerializeField] private GameObject _prefabZombie;
    [SerializeField] private SOZombiesItems[] _zombies;

    [SerializeField] private int _zombieMax = 20;

    private int _contZombie = 0;

    private float _time = 0;

    private float _tempsEntreZombies = 20f;

    private Vector3Int posicio;


    private void CrearZombies()
    {
    

        _contZombie++;



        if(_zombies == null || _zombies.Length == 0)
        {
            Debug.LogWarning("No hay ScriptableObjects asignados en _zombies.");
            return;
        }

        Vector3 transform = new Vector3(16, 0, 1);

        posicio = GetCellFromObject(transform);

        int op = Random.Range(0,_zombies.Length);
        GameObject zombie = Instantiate(_prefabZombie);
        zombie.GetComponent<ZombieScripts>().Iniciar(posicio ,_zombies[op]);

    
        
    }

    public Vector3Int GetCellFromObject(Vector3 target)
    {
        Vector3 worldPosition = target;
        return _tilemap.WorldToCell(worldPosition);
    }

    private IEnumerator GenerarZombiesRutina()
    {
        while (_zombieMax > _contZombie)
        {
            CrearZombies();

            yield return new WaitForSeconds(_tempsEntreZombies);
        }
    }

    void Start()
    {
        
        StartCoroutine(GenerarZombiesRutina());

    }

}
