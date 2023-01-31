using System.Collections;
using UnityEngine;

namespace ExtraAssets.Scripts.PoolOfObject
{
    public class TrackSpawner : ObjectsPool<Track>
    {
        [SerializeField] private Track[] _possibleTrackToSpawnTemplate;
        [SerializeField] private Transform _pointToSpawn;
        [SerializeField] private CubeForPickupPool _cubeForPickupPool;
        [SerializeField] private float _delayOfSpawn;
    
        private void Awake()
        {
            Initialize(_possibleTrackToSpawnTemplate);
        }

        private void Start()
        {
            Spawn();
            Spawn();
            StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(_delayOfSpawn);
                Spawn();
            }
        }
    
        private void Spawn()
        {
            if (TryGetObject(out Track track))
            {
                SetTrack(track);
            }
        }

        private void SetTrack(Track track)
        {
            track.Initialize(_cubeForPickupPool);
        
            track.transform.position = _pointToSpawn.position;
            track.Restart();
            track.TurnOn();
        
            _pointToSpawn.position = track.SpawnPoint;
        }
    }
}