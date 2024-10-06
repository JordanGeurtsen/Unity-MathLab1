using UnityEngine;

namespace GameMath.Utils
{
    public class Position : MonoBehaviour
    {
        public static float Distance2D(Vector3 a, Vector3 b)
        {
            return Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.z - b.z, 2));
        }
        
        public static Vector3 RandomPosition(Vector3 center, float minHorizontal, float maxHorizontal, float minY, float maxY)
        {
            float angle = Random.Range(0, 2 * Mathf.PI);
            float distance = Random.Range(minHorizontal, maxHorizontal);
            float x = center.x + distance * Mathf.Cos(angle);
            float z = center.z + distance * Mathf.Sin(angle);
            float y = Random.Range(minY, maxY);
            
            return new Vector3(x, y, z);
        } 
    }
}
