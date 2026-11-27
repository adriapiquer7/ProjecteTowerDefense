using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnZombieBase : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;

    [SerializeField] private GameObject _prefabZombie;
    [SerializeField] private SOZombiesItems[] _zombies;

    [SerializeField] private ZombieScripts[] _zombiRonda;

    [SerializeField] private int _zombieMax = 20;

    private int _contZombie = 0;

    private int _totalZombie = 30;

    private float _time = 0;

    private float _tempsEntreZombies = 20f;

    private Vector3Int posicio;

    [SerializeField]
    private TextMeshProUGUI _hasGuanyat;

    [SerializeField]
    private TextMeshProUGUI _textEnemigos;


    private void CrearZombies()
    {
    
        _contZombie++;

        if(_zombies == null || _zombies.Length == 0)
        {
            Debug.LogWarning("No hay ScriptableObjects asignados en _zombies.");
            return;
        }

        Vector3 transform = new Vector3(18, Random.Range(1, -4), 0);

        posicio = GetCellFromObject(transform);

        int op = Random.Range(0,_zombies.Length);
        GameObject zombie = Instantiate(_prefabZombie);
        zombie.GetComponent<ZombieScripts>().Iniciar(posicio ,_zombies[op]);
        if (_tempsEntreZombies >= 4)
        {
            _tempsEntreZombies-=1f;
        }
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

    public void EnemicKO()
    {
        
     _contZombie--;
     _totalZombie--;

    _textEnemigos.text = "Enemigos eliminados:"+ _totalZombie--;

    if(_totalZombie == 0)
        {
            
            _hasGuanyat.enabled = true;

        }


    }

}
