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

    private void CrearZombies()
    {
        if(_zombieMax > _contZombie)
        {

            _contZombie++;

            int posY = Random.Range(-2, 3);

            Vector3 posZombie = new Vector3(-2, posY, 0);
            


            if(_zombies == null || _zombies.Length == 0)
            {
                Debug.LogWarning("No hay ScriptableObjects asignados en _zombies.");
                return;
            }

                int op = Random.Range(0,_zombies.Length);
                Quaternion rotar = new Quaternion(0, 0, 0, 0);
                GameObject zombie = Instantiate(_prefabZombie, posZombie, rotar);
                zombie.GetComponent<ZombieBaseBehavior>().Iniciar(_zombies[op]);

        }
        

        
    }

    void Update()
    {
        _time += Time.deltaTime;

        if(_time >= _tempsEntreZombies)
        {
            CrearZombies();
            _time -= _tempsEntreZombies;
        }

    }
}
