using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smootthTime;
    public GameObject follow;
    public Vector2 minCamPos, maxCamPos;

    private Vector2 velocity;

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x,
            follow.transform.position.x, ref velocity.x, smootthTime);
        float posY = Mathf.SmoothDamp(transform.position.y, 
            follow.transform.position.y, ref velocity.y, smootthTime);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z); 
    }
}
