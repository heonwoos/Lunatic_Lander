using System.Collections.Generic;
using UnityEngine;

public class MoonGenerator : MonoBehaviour
{
    private Mesh moonMesh;
    private float randomSeed;
    private float[] perlinData; // 펄린 노이즈로 만든 지형의 y좌표
    private List<int> localMaxima; // 극대값을 가지는 좌표 리스트
    private Vector3[] verticesData; // 메쉬의 점들 벡터 
    private int[] meshTriangle; // 메쉬 삼각형 만들 때 쓰이는 정수 배열
    private int moonLength = 500;

    // 펄린 노이즈 조작용 변수들
    private float perlinDensity = 0.08f;
    private float perlinMagnitude = 2.44f;
    private float perlinPower = 3f;

    public Vector2[] GetBaseCoordinates() { // 베이스들의 좌표
        int numberOfBases = localMaxima.Count;
        Vector2[] baseCoordinates = new Vector2[numberOfBases];
        for (int i = 0; i < numberOfBases; i++) {
            baseCoordinates[i] = new Vector2(localMaxima[i], perlinData[i]);
        }
        return baseCoordinates;
    }

    public Vector2 GetMoonPointZero() { // 달 지형의 시작점 구하기
        return new Vector2(localMaxima[0], perlinData[localMaxima[0]]);
    }

    void Start()
    {
        moonMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = moonMesh;
        perlinData = new float[moonLength];
        verticesData = new Vector3[moonLength * 2];
        meshTriangle = new int[(moonLength - 1) * 2 * 3];

        randomSeed = Random.Range(-100f, 100f);
        createPerlinData();
        computeLocalMaxima(perlinData);
        createMoonVertices();
        createMoonMesh();
        GetComponent<PolygonCollider2D>().points = createCollider();
    }
    float customPerlinNoise1(int x) { // 펄린 노이즈 생성기 1 (전체적인 지형의 모양)
        return Mathf.Pow(
            Mathf.Clamp(Mathf.PerlinNoise1D((x + randomSeed) * perlinDensity), 0f, 1f) * perlinMagnitude,
            perlinPower);
        }
    float customPerlinNoise2(int x){ // 펄린 노이즈 생성기 2 (지형 디테일 추가)
        return (Mathf.Clamp(Mathf.PerlinNoise1D((x + randomSeed) * perlinDensity * 3), 0f, 1f) - 0.5f) * perlinMagnitude / 4;
    }

    void createPerlinData() { // 생성된 (Y좌표로 이용될)펄린 노이즈1 저장
        for (int i = 0; i < moonLength; i++)
        {
            perlinData[i] = customPerlinNoise1(i);
        }
    }
    void createMoonVertices() { // 메쉬를 구성하는 점 생성
        float initHeight = perlinData[localMaxima[0]];
        for (int i = 0, x=0; i < moonLength * 2; i+=2)
        {
            verticesData[i] = new Vector3(x - localMaxima[0], -9 - initHeight, 0);
            verticesData[i + 1] = new Vector3(x - localMaxima[0], -3 - initHeight + perlinData[x] + customPerlinNoise2(x), 0);
            x++;
        }
        moonMesh.SetVertices(verticesData);
    }
    void createMoonMesh() { // 메쉬 생성
        for (int i = 0, j = 0; i < (moonLength-1) * 2; i+=2)
        {
            meshTriangle[j] = i;
            meshTriangle[j + 1] = i + 1;
            meshTriangle[j + 2] = i + 2;
            meshTriangle[j + 3] = i + 2;
            meshTriangle[j + 4] = i + 1;
            meshTriangle[j + 5] = i + 3;
            j += 6;
        }
        moonMesh.SetIndices(meshTriangle, MeshTopology.Triangles, 0);
    }

    void computeLocalMaxima(float[] data) { // 극대값을 갖는 지점 저장
        localMaxima = new List<int>();
        int i = 0;
        for (int x = 1; x < data.Length-1; x++)
        {
            if(data[x] > data[x-1] && data[x] > data[x+1])
            {
                localMaxima.Add(x);
                i++;
            }
        }
    }
    Vector2[] createCollider() { // 생성된 메쉬에 맞춰서 Polygon Collider2D 만들기
        Vector2[] colliderPoints = new Vector2[moonLength * 2];
        for (int i = 0, j = 0; i < moonLength; i++) {
            colliderPoints[i] = verticesData[j];
            colliderPoints[moonLength * 2 - 1 - i] = verticesData[j+1];
            j+=2;
        }
        return colliderPoints;
    }
}
