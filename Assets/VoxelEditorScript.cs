/*using UnityEngine;
using UnityEngine.UI;

public class VoxelEditor : MonoBehaviour
{
    public GameObject voxelPrefab;  // Prefab do voxel
    public float voxelSize = 1f;    // Tamanho de cada voxel
    public Color[] voxelColors;     // Lista de cores disponíveis para os voxels
    private int selectedColorIndex = 0; // Índice da cor selecionada no painel de UI

    public Transform voxelParent;   // Para organizar todos os voxels criados
    public Text colorLabel;         // UI que exibe a cor atual do voxel

    public Text[] colorButtons;

    private Vector3 voxelPos; // Armazena a posição do voxel

    void Start()
    {
        UpdateColorLabel();
    }

    void Update()
    {
        // Adicionar voxel com clique esquerdo
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                voxelPos = GetVoxelPosition(hit.point); // Armazena a posição do voxel
                Debug.Log("Posição do voxel a ser adicionada: " + voxelPos);

                // Removemos a verificação de existência de voxel
                Debug.Log("Adicionando voxel na posição: " + voxelPos);
                AddVoxel(voxelPos);
            }
        }

        // Remover voxel com clique direito
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                RemoveVoxel(hit.transform.gameObject);
            }
        }
    }

    // Calcula a posição exata do voxel mais próximo com base no ponto clicado
    Vector3 GetVoxelPosition(Vector3 hitPoint)
    {
        float x = Mathf.Floor(hitPoint.x / voxelSize) * voxelSize;
        float y = Mathf.Floor(hitPoint.y / voxelSize) * voxelSize;
        float z = Mathf.Floor(hitPoint.z / voxelSize) * voxelSize;
        return new Vector3(x, y, z);
    }

    // Adiciona um voxel na posição especificada
    void AddVoxel(Vector3 pos)
    {
        Debug.Log("entrou");
        GameObject newVoxel = Instantiate(voxelPrefab, pos, Quaternion.identity, voxelParent);
        newVoxel.transform.localScale = Vector3.one * voxelSize;

        // Aplica a cor selecionada ao voxel
        Renderer renderer = newVoxel.GetComponent<Renderer>();
        renderer.material.color = voxelColors[selectedColorIndex];

        newVoxel.tag = "Voxel"; // Marca o voxel para identificação futura
    }

    // Remove um voxel específico
    void RemoveVoxel(GameObject voxel)
    {
        if (voxel.CompareTag("Voxel"))
        {
            Destroy(voxel);
        }
    }

    // Função chamada ao pressionar o botão de "Limpar"
    public void ClearVoxels()
    {
        foreach (Transform voxel in voxelParent)
        {
            Destroy(voxel.gameObject);
        }
    }

    // Função para mudar o tipo de voxel (cor) com base na UI
    public void SelectVoxelType(int colorIndex)
    {
        selectedColorIndex = colorIndex;
        UpdateColorLabel();
    }

    // Atualiza a exibição da cor atual selecionada
    void UpdateColorLabel()
    {
        colorLabel.text = colorButtons[selectedColorIndex].text;
        Debug.Log("Texto atualizado para: " + colorLabel.text);
    }

    // Método para visualizar o cubo de colisão no Editor (opcional)
    private void OnDrawGizmos()
    {
        if (voxelPrefab != null) // Apenas se o prefab não for nulo
        {
            Gizmos.color = Color.red;
            Vector3 halfVoxelSize = new Vector3(voxelSize * 0.5f, voxelSize * 0.5f, voxelSize * 0.5f);
            // A posição precisa ser definida como a última posição do voxelPos
            Gizmos.DrawWireCube(voxelPos, halfVoxelSize * 2); // Desenhe um cubo
        }
    }
}
*/

using UnityEngine;
using UnityEngine.UI;

public class VoxelEditor : MonoBehaviour
{
    public GameObject voxelPrefab;  // Prefab do voxel
    public float voxelSize = 1f;    // Tamanho de cada voxel
    public Color[] voxelColors;     // Lista de cores disponíveis para os voxels
    private int selectedColorIndex = 0; // Índice da cor selecionada no painel de UI

    public Transform voxelParent;   // Para organizar todos os voxels criados
    public Text colorLabel;         // UI que exibe a cor atual do voxel

    public Text[] colorButtons;

    private Vector3 voxelPos; // Armazena a posição do voxel

    void Start()
    {
        UpdateColorLabel();
    }

    void Update()
    {
        // Adicionar voxel com clique esquerdo
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                voxelPos = GetVoxelPosition(hit.point); // Armazena a posição do voxel
                Debug.Log("Posição do voxel a ser adicionada: " + voxelPos);

                Debug.Log("Adicionando voxel na posição: " + voxelPos);
                AddVoxel(voxelPos);
            }
        }

        // Remover voxel com clique direito
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                RemoveVoxel(hit.transform.gameObject);
            }
        }
    }

    // Calcula a posição exata do voxel mais próximo com base no ponto clicado
    Vector3 GetVoxelPosition(Vector3 hitPoint)
    {
        float x = Mathf.Floor(hitPoint.x / voxelSize) * voxelSize;
        float y = Mathf.Floor(hitPoint.y / voxelSize) * voxelSize; // Mantém a altura arredondada
        float z = Mathf.Floor(hitPoint.z / voxelSize) * voxelSize;
        return new Vector3(x, y, z);
    }

    // Adiciona um voxel na posição especificada
    void AddVoxel(Vector3 pos)
    {
        Debug.Log("entrou");
        GameObject newVoxel = Instantiate(voxelPrefab, pos, Quaternion.identity, voxelParent);
        newVoxel.transform.localScale = Vector3.one * voxelSize;

        // Aplica a cor selecionada ao voxel
        Renderer renderer = newVoxel.GetComponent<Renderer>();
        renderer.material.color = voxelColors[selectedColorIndex];

        newVoxel.tag = "Voxel"; // Marca o voxel para identificação futura
    }

    // Remove um voxel específico
    void RemoveVoxel(GameObject voxel)
    {
        if (voxel.CompareTag("Voxel"))
        {
            Destroy(voxel);
        }
    }

    // Função chamada ao pressionar o botão de "Limpar"
    public void ClearVoxels()
    {
        foreach (Transform voxel in voxelParent)
        {
            Destroy(voxel.gameObject);
        }
    }

    // Função para mudar o tipo de voxel (cor) com base na UI
    public void SelectVoxelType(int colorIndex)
    {
        selectedColorIndex = colorIndex;
        UpdateColorLabel();
    }

    // Atualiza a exibição da cor atual selecionada
    void UpdateColorLabel()
    {
        colorLabel.text = colorButtons[selectedColorIndex].text;
        Debug.Log("Texto atualizado para: " + colorLabel.text);
    }

    // Método para visualizar o cubo de colisão no Editor (opcional)
    private void OnDrawGizmos()
    {
        if (voxelPrefab != null) // Apenas se o prefab não for nulo
        {
            Gizmos.color = Color.red;
            Vector3 halfVoxelSize = new Vector3(voxelSize * 0.5f, voxelSize * 0.5f, voxelSize * 0.5f);
            // A posição precisa ser definida como a última posição do voxelPos
            Gizmos.DrawWireCube(voxelPos, halfVoxelSize * 2); // Desenhe um cubo
        }
    }
}
