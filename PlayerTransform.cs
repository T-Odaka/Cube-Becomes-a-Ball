using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{

    PlayerController playerController;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject sphere = null;
    [SerializeField] GameObject cube = null;
    [SerializeField] Material sphereMaterial = default;
    [SerializeField] Material cubeMaterial = default;
    MeshFilter meshFilter;
    MeshFilter sphereMesh;

    MeshFilter cubeMesh;

    MeshRenderer meshRenderer;
    Mesh mesh;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        meshFilter = player.AddComponent<MeshFilter>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        // 各メッシュ情報の格納
        sphereMesh = sphere.GetComponent<MeshFilter>();
        cubeMesh = cube.GetComponent<MeshFilter>();

        // プレイヤーテクスチャの貼り付け
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {

        bool isSphere = playerController.JudgForm;

        if (isSphere == true)
        {
            mesh.Clear();
            mesh.vertices = sphereMesh.mesh.vertices;
            mesh.triangles = sphereMesh.mesh.triangles;
            mesh.uv = sphereMesh.mesh.uv;
            meshRenderer.material = sphereMaterial;
        }
        else
        {
            mesh.Clear();
            mesh.vertices = cubeMesh.mesh.vertices;
            mesh.triangles = cubeMesh.mesh.triangles;
            mesh.uv = cubeMesh.mesh.uv;
            meshRenderer.material = cubeMaterial;
        }
    }

}