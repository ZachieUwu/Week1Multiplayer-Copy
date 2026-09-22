using UnityEngine;
using Unity.Netcode;

public class LocalCameraPlayerTarget : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if(!IsOwner) return;

        CameraTopDown cameraFollow = Camera.main.GetComponent<CameraTopDown>();

        cameraFollow.SetTarget(transform);
    }


}
