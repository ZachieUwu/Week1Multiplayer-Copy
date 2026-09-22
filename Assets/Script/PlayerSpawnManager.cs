using UnityEngine;
using Unity.Netcode;

public class PlayerSpawnManager : NetworkBehaviour
{
    private static int nextSpawnIndex;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;

        GameObject[] spawnPointsObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Transform selectedSpawnPoint = spawnPointsObjects[nextSpawnIndex].transform;
        CharacterController characterController = GetComponent<CharacterController>();
        characterController.enabled = false;

        transform.position = selectedSpawnPoint.position;
        characterController.enabled = true;
        nextSpawnIndex++;

        if(nextSpawnIndex >= spawnPointsObjects.Length)
        {
            nextSpawnIndex = 0;
        }
    }
}
