using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    private float fov;
    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 60f;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        int rayCount = 20;
        float angle = startingAngle;
        float angleIncrease = fov/rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount+1+1]; // 1 for the origin and 1 for ray0
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];

        //Vector3 origin = Vector3.zero;
        vertices[0] = origin;
        int vertexIndex = 1;
        int traingleIndex = 0;
        for(int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance);
            if(raycastHit2D.collider == null) {
                //no hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            } else {
                //hit
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if(i > 0) {
                triangles[traingleIndex+0] = 0;
                triangles[traingleIndex+1] = vertexIndex - 1;
                triangles[traingleIndex+2] = vertexIndex;
                traingleIndex += 3;
            }
            vertexIndex += 1;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
    }
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 patrolDirection)
    {
        this.startingAngle = GetAngleFromVectorFloat(patrolDirection) + fov/2f;
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        return n;
    }
    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
