using UnityEngine;

public class JiglleScript : MonoBehaviour
{
    [Range(0f, 1f)]
    public float power = 0.5f;

    [Header("Position Jiggler")]
    public bool jigglePosition = true;
    public Vector2 positionJigAmount;
    [Range(0f, 100f)]
    public float positionFrequency = 10f;
    Vector3 basePosition;
    float positionTimer;

    [Header("Rotation Jiggler")]
    public bool jiggleRotation = true;
    public Vector3 rotationJigAmount;
    [Range(0f, 100f)]
    public float rotationFrequency = 10f;
    float rotationTimer;
    Quaternion baseRotation;

    [Header("Scale Jiggler")]
    public bool jiggleScale = true;
    public Vector2 scaleJigAmount;
    [Range(0f, 100f)]
    public float scaleFrequency = 10f;
    float scaleTimer;
    Vector3 baseScale;

    private void Start()
    {
        basePosition = transform.localPosition;
        baseRotation = transform.localRotation;
        baseScale = transform.localScale;
    }

    void Update()
    {
        if (jigglePosition)
        {
            positionTimer += Time.deltaTime * positionFrequency;
            Vector3 offset = new Vector3(
                Mathf.Sin(positionTimer) * positionJigAmount.x,
                Mathf.Cos(positionTimer) * positionJigAmount.y,
                0f);
            transform.localPosition = basePosition + offset * power;
        }

        if (jiggleRotation)
        {
            rotationTimer += Time.deltaTime * rotationFrequency;
            transform.localRotation = baseRotation * Quaternion.Euler(rotationJigAmount * Mathf.Sin(rotationTimer) * power);
        }

        if (jiggleScale)
        {
            scaleTimer += Time.deltaTime * scaleFrequency;
            Vector3 scaleOffset = new Vector3(scaleJigAmount.x, scaleJigAmount.y, 0f) * Mathf.Sign(Mathf.Sin(scaleTimer)) * power;
            transform.localScale = baseScale + scaleOffset;
        }
    }
}