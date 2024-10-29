using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    public int width = 10;   // Número de voxels em largura
    public int depth = 10;   // Número de voxels em profundidade
    public float voxelSize = 1f; // Tamanho de cada voxel

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Cor do gizmo

        // Desenha a grade de voxels
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                Vector3 position = new Vector3(x * voxelSize, 0, z * voxelSize);
                Gizmos.DrawWireCube(position, new Vector3(voxelSize, 0.1f, voxelSize)); // Desenhe uma caixa ao invés de uma esfera
            }
        }
    }
}
