using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class MeshBase : MonoBehaviour
{
    public Mesh mesh;

    private Vector3[] vertices;
    private int[] triangles;

    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
        this.GetComponentInParent<MeshCollider>().sharedMesh = mesh;
    }

    private void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3 (0,0,0),
            new Vector3 (2,0,0),
            new Vector3 (1,1,0)
        };

        triangles = new int[]
        {
            0,1,2
        };
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}