using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnZombieBase : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;

    [SerializeField] private ZombieScripts _prefabZombie;
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


    private ZombieScripts CrearZombies()
    {
    
        _contZombie++;

        if(_zombies == null || _zombies.Length == 0)
        {
            Debug.LogWarning("No hay ScriptableObjects asignados en _zombies.");
            return null;
        }

        Vector3 transform = new Vector3(18, Random.Range(1, -4), 0);

        posicio = GetCellFromObject(transform);

        int op = Random.Range(0,_zombies.Length);
        ZombieScripts zombie = Instantiate(_prefabZombie);
        zombie.GetComponent<ZombieScripts>().Iniciar(posicio ,_zombies[op]);
        
        if (_tempsEntreZombies >= 4)
        {
            _tempsEntreZombies-=1f;
        }

        return zombie;
    }

    public Vector3Int GetCellFromObject(Vector3 target)
    {
        Vector3 worldPosition = target;
        return _tilemap.WorldToCell(worldPosition);
    }

    [SerializeField]
    private ZombieScripts z;

    private IEnumerator GenerarZombiesRutina()
    {
        while (_zombieMax > _contZombie)
        {
            z = CrearZombies();
            
            if(z != null)
            {
                LlistaZombies.Add(z);
                z.OnZombieHaMort += EnemicKO;
            }

            yield return new WaitForSeconds(_tempsEntreZombies);
        }
    }

    List<ZombieScripts> LlistaZombies = new List<ZombieScripts>();

    void Start()
    {
        StartCoroutine(GenerarZombiesRutina());
        _textEnemigos.text = "Enemigos eliminados:"+ _totalZombie;
    }

    public void EnemicKO()
    {
        
        Debug.Log("Enemc Ko");
     _totalZombie--;

    _textEnemigos.text = "Enemigos eliminados:"+ _totalZombie;

    if(_totalZombie == 0)
        {
            
            _hasGuanyat.enabled = true;

        }

    if(z._vida <= 0)
        {
            z.OnZombieHaMort -= EnemicKO;
            _contZombie--;
        }
    

    }




}
