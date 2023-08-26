using UnityEditor;
using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(menuName = "SO/Player skin")]
    public class PlayerSkinSo : ScriptableObject
    {
        [field:SerializeField] public int Id { get; private set; }
        [field:SerializeField] public GameObject PlayerModel { get; private set; }
        [field:SerializeField] public Avatar Avatar { get; private set; }
    }
}