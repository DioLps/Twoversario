using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class QuestManager : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private AudioSource _audioSource;

    private NPCController npcController;

    private void Start()
    {
        npcController = GetComponentInParent<NPCController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && npcController != null)
        {
            _particleSystem.Play();
            _audioSource.Play();
            CustomScoreManager.IncreaseIndex();
            npcController.canFollow = true;
            Destroy(gameObject);
        }
    }

}
