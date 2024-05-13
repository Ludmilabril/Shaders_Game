using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public List<MeshRenderer> PlantsMeshes;
    public float TimeToGrow = 5;
    public float RefreshRate = 0.05f;
    [Range(0f, 1f)]
    public float minGrow = 0.02f;
    [Range(0f, 1f)]
    public float maxGrow = 0.09f;

    private List<Material> GrowPlantMat = new List<Material>();
    private bool FullGrow;

    private void Start()
    {
        for (int i = 0; i < PlantsMeshes.Count; i++)
        {
            for(int j = 0; j < PlantsMeshes[i].materials.Length;j++)
            {
                if (PlantsMeshes[i].materials[j].HasProperty("Grow_"))
                {
                    PlantsMeshes[i].materials[j].SetFloat("Grow_",minGrow);
                    GrowPlantMat.Add(PlantsMeshes[i].materials[j]);
                }
            }    
        }
    }

    private void Update()
    {
        for (int i = 0; i < GrowPlantMat.Count; i++)
        {
            StartCoroutine(GrowPlants(GrowPlantMat[i]));
        }  
    }

    IEnumerator GrowPlants(Material mat)
    {
        float growValue = mat.GetFloat("Grow_");

        if (!FullGrow)
        {
            while (growValue < maxGrow)
            {
                growValue+=1/(TimeToGrow/RefreshRate);
                mat.SetFloat("Grow_", growValue);

                yield return new WaitForSeconds (RefreshRate);
            }
        }
        else
        {
            while (growValue > minGrow)
            {
                growValue -= 1 / (TimeToGrow / RefreshRate);
                mat.SetFloat("Grow_", growValue);

                yield return new WaitForSeconds(RefreshRate);
            }
        }

        if (growValue >= maxGrow)
        {
            FullGrow = true;
        }
        else FullGrow = false;
    }
}
