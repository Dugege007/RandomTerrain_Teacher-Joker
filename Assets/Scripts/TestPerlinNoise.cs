using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TestPerlinNoise : MonoBehaviour
{
    [Title("基础设置")]
    [LabelText("LineRenderer引用")]
    public LineRenderer LineRenderer;
    [LabelText("节点数")]
    public int PosCount;
    [LabelText("高度")]
    public float Height;

    [Title("柏林噪声")]
    [LabelText("使用柏林噪声")]
    public bool UsePerlin;
    [LabelText("间隔（横向）")]
    public float Lacunarity;
    [LabelText("偏移（纵向）")]
    public float Offset;

    [Title("生成")]
    [Button("生成线条", ButtonSizes.Medium)]
    public void GenerateLine()
    {
        LineRenderer.positionCount = PosCount;
        Vector3[] positions = new Vector3[PosCount];

        for (int i = 0; i < PosCount; i++)
        {
            float sampleHeight = 0;
            if (UsePerlin)
            {
                // 输入的 x 值，要保证小数点后有值（非整数）
                // 同样的输入，结果不变
                // 输入的值越接近，结果就越平滑？
                sampleHeight = Mathf.PerlinNoise((i + Offset) * Lacunarity, 0);
            }
            else
            {
                sampleHeight = Random.value;
            }
            positions[i] = new Vector3(0, sampleHeight * Height, 0.1f * i);
        }

        LineRenderer.SetPositions(positions);
    }
}
