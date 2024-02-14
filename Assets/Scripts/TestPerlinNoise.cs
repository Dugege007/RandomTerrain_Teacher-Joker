using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TestPerlinNoise : MonoBehaviour
{
    [Title("��������")]
    [LabelText("LineRenderer����")]
    public LineRenderer LineRenderer;
    [LabelText("�ڵ���")]
    public int PosCount;
    [LabelText("�߶�")]
    public float Height;

    [Title("��������")]
    [LabelText("ʹ�ð�������")]
    public bool UsePerlin;
    [LabelText("���������")]
    public float Lacunarity;
    [LabelText("ƫ�ƣ�����")]
    public float Offset;

    [Title("����")]
    [Button("��������", ButtonSizes.Medium)]
    public void GenerateLine()
    {
        LineRenderer.positionCount = PosCount;
        Vector3[] positions = new Vector3[PosCount];

        for (int i = 0; i < PosCount; i++)
        {
            float sampleHeight = 0;
            if (UsePerlin)
            {
                // ����� x ֵ��Ҫ��֤С�������ֵ����������
                // ͬ�������룬�������
                // �����ֵԽ�ӽ��������Խƽ����
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
