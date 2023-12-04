using UnityEngine;
using System.Collections;

public class PlayerSpellCasting : MonoBehaviour
{
    public AudioClip spellAudioClip;
    private AudioSource audioSource;
    public GameObject ghostObject; // Reference to the ghost
    public float spellRange = 5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Check if E key is pressed
        {
            CastSpell();
        }
    }

    void CastSpell()
    {
        audioSource.PlayOneShot(spellAudioClip);
        StartCoroutine(CheckSpellEffect());
    }

    IEnumerator CheckSpellEffect()
    {
        yield return new WaitForSeconds(spellAudioClip.length); // Wait until the audio finishes playing
        CastSpellOnGhost();
    }

    private void CastSpellOnGhost()
    {
        if(ghostObject && Vector3.Distance(transform.position, ghostObject.transform.position) <= spellRange)
        {
            AIAgentChase2 ghostScript = ghostObject.GetComponent<AIAgentChase2>();
            if (ghostScript != null)
           
            {
                ghostScript.DisappearAfterSpell();
            }
        }
    }
}
