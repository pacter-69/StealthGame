using UnityEngine;

public class EnemyAlarm : MonoBehaviour
{
    SpriteRenderer alarmRenderer;
    public float offset;

    public void LateUpdate()
    {
        Transform parent = transform.parent;
        transform.position = parent.position + new Vector3(0, offset, 0);
        transform.rotation = Quaternion.identity;
    }

    public void PlayerDetected()
    {
        ChangeColor(Color.red);
    }

    public void PlayerLeft()
    {
        ChangeColor(new Color(0,0,0,0));
    }

    private void ChangeColor(Color color)
    {
        if (alarmRenderer == null) alarmRenderer = GetComponent<SpriteRenderer>();

        alarmRenderer.color = color;
    }
}
