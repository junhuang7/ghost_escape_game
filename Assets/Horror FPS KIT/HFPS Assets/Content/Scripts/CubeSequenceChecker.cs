using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSequenceChecker : MonoBehaviour
{
    public GameObject HEROPLAYER;
    public GameObject[] cubes;
    public float detectionDistance = 2.0f;

    private int[] targetSequence = { 6, 4, 5, 7 };
    private List<int> visitedSequence = new List<int>();
    private Renderer[] cubeRenderers;

    private void Start()
    {
        cubeRenderers = new Renderer[cubes.Length];
        for (int i = 0; i < cubes.Length; i++)
        {
            // Initialize renderers
            cubeRenderers[i] = cubes[i].GetComponent<Renderer>();

            // Set up the text on top of cubes
            GameObject textObj = new GameObject($"CubeText{i}");
            textObj.transform.SetParent(cubes[i].transform);
            textObj.transform.localPosition = new Vector3(0, 0.7f, 0);
            TextMesh textMesh = textObj.AddComponent<TextMesh>();
            textMesh.text = i.ToString();
            textMesh.alignment = TextAlignment.Center;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.fontSize = 500;
            textMesh.characterSize = 0.02f;
            textMesh.color = Color.black;
        }
    }

    private void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (Vector3.Distance(HEROPLAYER.transform.position, cubes[i].transform.position) < detectionDistance)
            {
                if (System.Array.Exists(targetSequence, element => element == i))
                {
                    ChangeColorTemporarily(i, Color.red, 1f);

                    // Record the visit
                    if (!visitedSequence.Contains(i)) // Avoid adding the same cube multiple times
                        visitedSequence.Add(i);
                    
                    // Check if the last four visits match the target sequence
                    if (visitedSequence.Count >= 4 
                        && visitedSequence[visitedSequence.Count - 4] == targetSequence[0] 
                        && visitedSequence[visitedSequence.Count - 3] == targetSequence[1]
                        && visitedSequence[visitedSequence.Count - 2] == targetSequence[2]
                        && visitedSequence[visitedSequence.Count - 1] == targetSequence[3])
                    {
                        ChangeColorOfSequenceCubes(Color.green);
                        visitedSequence.Clear(); // Clear the sequence after matching
                    }
                }
            }
        }
    }

    private void ChangeColorTemporarily(int cubeIndex, Color color, float duration)
    {
        StartCoroutine(ChangeCubeColorTemporarily(cubeRenderers[cubeIndex], color, duration));
    }

    private IEnumerator ChangeCubeColorTemporarily(Renderer cubeRenderer, Color color, float duration)
    {
        Color originalColor = cubeRenderer.material.color;
        cubeRenderer.material.color = color;
        yield return new WaitForSeconds(duration);
        if(cubeRenderer.material.color == color) // Only revert the color if it hasn't changed in the meantime
            cubeRenderer.material.color = originalColor;
    }

    private void ChangeColorOfSequenceCubes(Color color)
    {
        foreach (int index in targetSequence)
        {
            cubeRenderers[index].material.color = color;
        }
    }
}
