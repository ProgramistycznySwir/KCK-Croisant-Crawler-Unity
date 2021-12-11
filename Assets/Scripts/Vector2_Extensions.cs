using Croisant_Crawler.Data;

/// <summary>
/// Interop methods.
/// </summary>
namespace Croisant_Crawler.UnityExtensions
{
    public static class Vector2_Extensions
    {
        public static UnityEngine.Vector2Int ToUnity(this Vector2Int vector)
            => new UnityEngine.Vector2Int(vector.x, vector.y);
        public static Vector2Int ToData(this UnityEngine.Vector2Int vector)
            => new Vector2Int(vector.x, vector.y);
        public static UnityEngine.Vector3 ToUnityVector3(this Vector2Int vector)
            => new UnityEngine.Vector3(vector.x, vector.y);
        public static UnityEngine.Vector3Int ToUnityVector3Int(this Vector2Int vector)
            => new UnityEngine.Vector3Int(vector.x, vector.y);
    }
}