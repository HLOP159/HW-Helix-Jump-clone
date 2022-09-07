using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformsPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatform;
    public int MaxPlatform;
    public float DistanceBetwenPlatform;
    public Transform FinishPlatform;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);

        int platformCount = RandomRange(random, MinPlatform, MaxPlatform + 1);

        for (int i = 0; i < platformCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformsPrefabs.Length);
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformsPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }

        FinishPlatform.localPosition = CalculatePlatformPosition(platformCount);

        CylinderRoot.localScale = new Vector3(1, platformCount * DistanceBetwenPlatform + ExtraCylinderScale, 1);
    }

    private int RandomRange( Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int lenght = maxExclusive - min;
        number %= lenght;
        return min + number;
    }
    
    private float RandomRange(Random random, float min, float max)
    {
        float t = (float) random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetwenPlatform * platformIndex, 0);
    }
}
