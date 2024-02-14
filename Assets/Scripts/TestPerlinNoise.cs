using Sirenix.OdinInspector;
using UnityEngine;

namespace RandomTerrain
{
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
        [LabelText("����")]
        public int Seed;
        [LabelText("����")]
        public AnimationCurve Curve;
        [LabelText("���")]
        public float Lacunarity;

        [Title("����")]
        [Button("��������", ButtonSizes.Medium)]
        public void GenerateLine()
        {
            LineRenderer.positionCount = PosCount;
            Vector3[] positions = new Vector3[PosCount];
            Random.InitState(Seed);

            float randomOffset = Random.Range(0, 10000f);

            for (int i = 0; i < PosCount; i++)
            {
                float sampleHeight = 0;
                if (UsePerlin)
                {
                    // ����� x ֵ��Ҫ��֤С�������ֵ����������
                    // ͬ�������룬�������
                    // �����ֵԽ�ӽ��������Խ����
                    sampleHeight = Mathf.PerlinNoise(i * Lacunarity + randomOffset, 0);
                }
                else
                {
                    sampleHeight = Random.value;
                }

                sampleHeight = Curve.Evaluate(sampleHeight);
                positions[i] = new Vector3(0, sampleHeight * Height, 0.1f * i);
            }

            LineRenderer.SetPositions(positions);
        }
    }
}
