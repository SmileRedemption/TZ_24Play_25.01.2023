using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace ExtraAssets.Scripts.PoolOfObject
{
    public abstract class ObjectsPool<T> : MonoBehaviour
        where T : MonoBehaviour, ISpawnable
    {
        [SerializeField] private int _capacity;
        [SerializeField] private Transform _container;

        private readonly List<T> _pool = new();

        private T Create(T prefab, Vector2 position) => Instantiate(prefab, position, Quaternion.identity);

        protected void Initialize(T prefab)
        {
            for (var i = 0; i < _capacity; i++)
            {
                var spawned = Create(prefab, _container.position);
                spawned.TurnOff();

                _pool.Add(spawned);
            }
        }

        protected void Initialize(T[] prefabs)
        {
            var countOfPrefab = prefabs.Length;

            for (var i = 0; i < _capacity; i++)
            {
                var prefab = prefabs[i % countOfPrefab];
                var spawned = Instantiate(prefab, _container.transform);
                spawned.TurnOff();

                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out T objectOfPool)
        {
            objectOfPool = _pool
                .Where(element => element.gameObject.activeSelf == false)
                .RandomElement();
            return objectOfPool != null;
        }
    }

    internal static class Extensions
    {
        public static T RandomElement<T>(this IEnumerable<T> source)
        {
            var current = default(T);
            var count = 0;

            var random = new Random();

            foreach (var element in source)
            {
                count++;

                if (random.Next(count) == 0)
                {
                    current = element;
                }
            }

            return current;
        }
    }
}