using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeSequenceChecker : MonoBehaviour
{
    public GameObject HEROPLAYER;
    public GameObject[] cubes;
    public float detectionDistance = 2.0f;
    public TextMeshProUGUI hintText; // Assign this in the inspector
    public DoorOpenController doorOpenController; // Assign this in the inspector
    private bool secondHintShown = false;


    private int[] targetSequence = { 6, 4, 5, 7 };
    private List<int> visitedSequence = new List<int>();
    private Renderer[] cubeRenderers;
    private float startTime;

    private void Start()
    {
        cubeRenderers = new Renderer[cubes.Length];
        startTime = Time.time;

        for (int i = 0; i < cubes.Length; i++)
        {
            cubeRenderers[i] = cubes[i].GetComponent<Renderer>();
            CreateNumberOnCube(i);
        }

        ShowHint("Welcome, 10 boxes in the room, figure out what boxes are important for solving the puzzle", 3f);
        
        // Center the hintText in the screen
        RectTransform rt = hintText.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.localPosition = Vector3.zero;
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

                    if (!visitedSequence.Contains(i))
                        visitedSequence.Add(i);
                    
                    if (visitedSequence.Count >= 4 && CheckSequence())
                    {
                        ChangeColorOfSequenceCubes(Color.green);
                        StartCoroutine(ChangeAllCubesToGreenAfterDelay(10f));
                        visitedSequence.Clear();
                        // Door Open Mechanism
                        if (doorOpenController != null)
                        {
                            doorOpenController.ToggleDoor();
                        }
                        else
                        {
                            Debug.LogError("DoorOpenController not assigned!");
                        }                        
                    }
                }
            }
        }

        if (Time.time - startTime > 30f && hintText.text == "" && !secondHintShown) // After 1 minute, show the second hint
        {
            ShowHint("Now you might have noticed that four boxes are related to the game, now please visit them again in a sequence. Think about the course code of video game design, it is CS-6 what?", 5f);
            secondHintShown = true; // Set the flag to true so the hint won't be shown again
        }
    }

    private void CreateNumberOnCube(int cubeIndex)
    {
        GameObject textObj = new GameObject($"CubeText{cubeIndex}");
        textObj.transform.SetParent(cubes[cubeIndex].transform);
        textObj.transform.localPosition = new Vector3(0, 1.2f, 0);
        TextMeshPro textMeshPro = textObj.AddComponent<TextMeshPro>();
        textMeshPro.text = cubeIndex.ToString();
        textMeshPro.alignment = TextAlignmentOptions.Center;
        textMeshPro.fontSize = 10; // Adjust as needed
        textMeshPro.color = Color.black;
        textMeshPro.GetComponent<RectTransform>().sizeDelta = new Vector2(2, 2); // Adjust as needed
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
        if (cubeRenderer.material.color == color)
            cubeRenderer.material.color = originalColor;
    }

    private void ChangeColorOfSequenceCubes(Color color)
    {
        foreach (int index in targetSequence)
        {
            cubeRenderers[index].material.color = color;
        }
    }

    private IEnumerator ChangeAllCubesToGreenAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (Renderer cubeRenderer in cubeRenderers)
        {
            cubeRenderer.material.color = Color.green;
        }
    }

    public bool CheckSequence()
    {
        if (visitedSequence.Count >= 4)
        {
            int count = visitedSequence.Count;
            return visitedSequence[count - 4] == targetSequence[0] 
                && visitedSequence[count - 3] == targetSequence[1]
                && visitedSequence[count - 2] == targetSequence[2]
                && visitedSequence[count - 1] == targetSequence[3];
        }
        return false;
    }

    private void ShowHint(string message, float duration)
    {
        hintText.text = message;
        hintText.fontSize = 24; // Adjust as needed

        RectTransform rt = hintText.GetComponent<RectTransform>();
        
        // Set the anchors to stretch horizontally
        rt.anchorMin = new Vector2(0, 0.5f);
        rt.anchorMax = new Vector2(1, 0.5f);
        
        // Set the sizeDelta to adjust height
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 100); // You can adjust the height as needed
        
        
        // Optional: Add some padding
        rt.offsetMin = new Vector2(rt.offsetMin.x + 10, rt.offsetMin.y); // Left padding
        rt.offsetMax = new Vector2(rt.offsetMax.x - 10, rt.offsetMax.y); // Right padding

        StartCoroutine(ClearHintAfterDelay(duration));
    }

    private IEnumerator ClearHintAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hintText.text = "";
    }
}
