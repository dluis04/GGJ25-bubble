using System.Collections;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;

    [SerializeField] private Transform _bubblePrefab;
    [SerializeField] private Vector3 _bubbleDirection;

    private void Start()
    {
        StartCoroutine(SpawnBubble());
    }

    private IEnumerator SpawnBubble()
    {

        yield return new WaitForSeconds(_spawnCooldown);
    }



}
