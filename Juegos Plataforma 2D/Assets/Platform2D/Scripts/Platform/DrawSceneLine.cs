using UnityEngine;

public class DrawSceneLine : MonoBehaviour
{
    public Transform from;
    public Transform to;

    void OnDrawGizmosSelected()
    {
        if (from != null && to != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, .15f);
            Gizmos.DrawSphere(to.position, .15f);
        }
    }
}
