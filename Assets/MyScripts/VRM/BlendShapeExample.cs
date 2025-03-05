using UnityEngine;
using System.Collections;

public class BlendShapeExample : MonoBehaviour
{

    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    float blendOne = 0f;
    float blendTwo = 0f;
    float blendSpeed = 1f;
    bool blendOneFinished = false;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
        blendShapeCount = skinnedMesh.blendShapeCount;
        Debug.Log(blendShapeCount);
    }

    void Update()
    {
        if (blendShapeCount > 2)
        {

            if (blendOne < 100f)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, blendOne);
                Debug.Log(blendOne);
                blendOne += blendSpeed;
            }
            else
            {
                blendOneFinished = true;
            }

            if (blendOneFinished == true && blendTwo < 100f)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(1, blendTwo);
                blendTwo += blendSpeed;
                Debug.Log(blendTwo);
            }

        }
    }
}
