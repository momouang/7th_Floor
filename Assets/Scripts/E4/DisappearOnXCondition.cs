using UnityEngine;

public class DisappearOnXCondition : MonoBehaviour
{
    public Transform referenceObject; // �ο�����
    public Transform[] objectsToCompare; // ��Ҫ�Ƚϵ���������

    public bool okok = false;

    void Update()
    {
        float referenceX = referenceObject.position.x; // ��ȡ�ο������X����������

        // ��������Ҫ�Ƚϵ�����
        foreach (var obj in objectsToCompare)
        {
            // ���ÿ�������X�����������Ƿ���ڲο������X������
            if ((obj.position.x > referenceX) && (okok))
            {
                obj.gameObject.SetActive(false); // ����ǣ������ظ�����
            }
        }
    }

    public void Oknow()
    {
        okok = true;
    }
}