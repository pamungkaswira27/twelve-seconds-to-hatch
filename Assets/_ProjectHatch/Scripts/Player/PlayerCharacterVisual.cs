using NaughtyAttributes;
using UnityEngine;

namespace ProjectHatch.Player.Character.Visual
{
    public class PlayerCharacterVisual : MonoBehaviour
    {
        [SerializeField] private GameObject _deathVfxPrefab;

        [Button]
        private void SpawnVFX()
        {
            GameObject go = Instantiate(_deathVfxPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(go, 2f);
        }
    }
}