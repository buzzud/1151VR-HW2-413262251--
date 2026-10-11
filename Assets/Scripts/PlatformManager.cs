
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platforms = new GameObject[2];

    private Vector2[] positions =
    {
        new Vector2(-4.5f, -4.2f),
        new Vector2(5f, -4.2f)
    };

    void Start()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            if (platforms[i] == null)
            {
                Debug.LogError("平台尚未指定！");
                continue;
            }

            platforms[i].transform.position =
                new Vector3(
                    positions[i].x,
                    positions[i].y,
                    0f
                );

            platforms[i].transform.localScale =
                new Vector3(7f, 1f, 1f);
        }
    }
}
