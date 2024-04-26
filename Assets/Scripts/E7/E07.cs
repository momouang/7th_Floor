using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E07 : MonoBehaviour
{
    public Transform door1;
    public Transform door2;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    public GameObject ribbt1;
    public GameObject ribbt2;
    public GameObject ribbt3;
    public GameObject ribbt4;
    public GameObject ribbt5;
    public GameObject ribbt6;
    public GameObject ribbt7;
    public GameObject Bunny;

    public bool okok = false;

    public GameObject airwall;

    public Light lightToControl;  // Assign this through the Inspector
    private float totalTime = 8.9f;
    private int flickerCount = 12;
    private float minOffDuration = 0.1f; // �ص���̳���ʱ��
    private float maxOffDuration = 0.5f; // �ص������ʱ��
    private float maxOnDuration = 0.8f; // ���������ʱ��
    private float minInterval = 0.2f;

    public Camera cameraToAdjust; // Ҫ���������
    private float initialFOV;
    private float increaseDuration = 8.9f;
    private float normalizeDuration = 0.5f;
    private float targetFOV;

    // Start is called before the first frame update

    private void Start()
    {
        initialFOV = cameraToAdjust.fieldOfView;
        targetFOV = initialFOV + 8;

    }
    private void OnTriggerEnter(Collider other)
    {
        // �����ײ�Ķ����Ƿ������
        if (other.CompareTag("Player")) // ȷ����Ҷ����Tag����Ϊ"Player"
        {
           
            PerformAction();
        }
    }

    public void PerformAction()
    {
        if (!okok)
        {
            StartCoroutine(ChangeFOV());
            StartCoroutine(FlickerLight());
            audioSource3.Play();
            ribbt1.SetActive(true);
            Invoke("OpenDoor", 0.5f);
            Invoke("CloseDoor", 1f);
            Invoke("time2", 1.5f);
            Invoke("OpenDoor", 1.7f);
            Invoke("CloseDoor", 2.2f);
            Invoke("time3", 2.7f);
            Invoke("OpenDoor", 2.9f);
            Invoke("CloseDoor", 3.4f);
            Invoke("time4", 3.9f);
            Invoke("OpenDoor", 4.1f);
            Invoke("CloseDoor", 4.6f);
            Invoke("time5", 5.1f);
            Invoke("OpenDoor", 5.3f);
            Invoke("CloseDoor", 5.8f);
            Invoke("time6", 6.3f);
            Invoke("OpenDoor", 6.5f);
            Invoke("CloseDoor", 7f);
            Invoke("time7", 7.5f);
            Invoke("OpenDoor", 7.7f);
            Invoke("CloseDoor", 8.2f);
            Invoke("allD", 8.7f);
            Invoke("OpenDoor3", 10.2f);
            Invoke("OpenDoor", 10.7f);
            okok = true;
        }     
    }

    public void time2()
    {
        ribbt2.SetActive(true);
    }

    public void time3()
    {
        ribbt3.SetActive(true);
    }

    public void time4()
    {
        ribbt4.SetActive(true);
    }

    public void time5()
    {
        ribbt5.SetActive(true);
    }

    public void time6()
    {
        ribbt6.SetActive(true);
    }

    public void time7()
    {
        ribbt7.SetActive(true);
    }

    public void allD()
    {
        ribbt1.SetActive(false);
        ribbt2.SetActive(false);
        ribbt3.SetActive(false);
        ribbt4.SetActive(false);
        ribbt5.SetActive(false);
        ribbt6.SetActive(false);
        ribbt7.SetActive(false);
        airwall.SetActive(false);
        Bunny.SetActive(true);
    }

    public void OpenDoor3()
    {
        audioSource3.Play();

    }

    public void OpenDoor()
    {
        StartCoroutine(DoorPositions1());
        audioSource1.Play();

    }

    public void CloseDoor()
    {
        StartCoroutine(DoorPositions2());
        audioSource2.Play();
    }

    IEnumerator DoorPositions1()
    {
        float duration = 0.5f; // ��������ʱ�䣬1��
        float elapsed = 0.0f; // �Ѿ�����ʱ��
        float distance = 1.04f; // �ƶ��ľ���

        Vector3 door1StartPosition = door1.position; // Door1��ʼλ��
        Vector3 door2StartPosition = door2.position; // Door2��ʼλ��

        Vector3 door1EndPosition = new Vector3(door1StartPosition.x, door1StartPosition.y, door1StartPosition.z + distance);
        Vector3 door2EndPosition = new Vector3(door2StartPosition.x, door2StartPosition.y, door2StartPosition.z - distance);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime; // �����ѹ�ʱ��
            float fraction = elapsed / duration; // ������ɵĲ���

            // ʹ��Lerp���Բ�ֵ���㵱ǰλ��
            door1.position = Vector3.Lerp(door1StartPosition, door1EndPosition, fraction);
            door2.position = Vector3.Lerp(door2StartPosition, door2EndPosition, fraction);

            yield return null;
        }

        // ȷ����ѭ������ʱ�ŵ�λ�þ�ȷ����
        door1.position = door1EndPosition;
        door2.position = door2EndPosition;
    }

    IEnumerator DoorPositions2()
    {
        float duration = 0.5f; // ��������ʱ�䣬1��
        float elapsed = 0.0f; // �Ѿ�����ʱ��
        float distance = 1.04f; // �ƶ��ľ���

        Vector3 door1StartPosition = door1.position; // Door1��ʼλ��
        Vector3 door2StartPosition = door2.position; // Door2��ʼλ��

        Vector3 door1EndPosition = new Vector3(door1StartPosition.x, door1StartPosition.y, door1StartPosition.z - distance);
        Vector3 door2EndPosition = new Vector3(door2StartPosition.x, door2StartPosition.y, door2StartPosition.z + distance);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime; // �����ѹ�ʱ��
            float fraction = elapsed / duration; // ������ɵĲ���

            // ʹ��Lerp���Բ�ֵ���㵱ǰλ��
            door1.position = Vector3.Lerp(door1StartPosition, door1EndPosition, fraction);
            door2.position = Vector3.Lerp(door2StartPosition, door2EndPosition, fraction);

            yield return null;
        }

        // ȷ����ѭ������ʱ�ŵ�λ�þ�ȷ����
        door1.position = door1EndPosition;
        door2.position = door2EndPosition;
    }

    IEnumerator FlickerLight()
    {
        float timeRemaining = totalTime;
        lightToControl.enabled = true; // ȷ����ʼ״̬���ǿ���
        float lastActionTime = 0.0f; // ��¼��һ�ζ�����ʱ��

        for (int i = 0; i < flickerCount - 1; i++) // ���һ���л��󱣳ֿ���״̬������ѭ��������1
        {
            float nextActionDuration = lightToControl.enabled ? Random.Range(minInterval, maxOnDuration) : Random.Range(minOffDuration, maxOffDuration);
            float maxNextActionTime = Mathf.Max(minInterval, timeRemaining - nextActionDuration - minInterval * (flickerCount - i - 1));
            float nextActionTime = Random.Range(minInterval, maxNextActionTime);

            // �ȴ����´��л�
            yield return new WaitForSeconds(nextActionTime);
            lightToControl.enabled = !lightToControl.enabled; // �л��ƹ�״̬

            // ����ʣ��ʱ��
            timeRemaining -= (nextActionTime + nextActionDuration);
            lastActionTime = Time.time;
        }

        // ȷ�������ǿ��ŵ�
        if (!lightToControl.enabled)
        {
            lightToControl.enabled = true;
            yield return new WaitForSeconds(totalTime - (Time.time - lastActionTime)); // �ȴ�ʣ��ʱ��
        }
    }

    IEnumerator ChangeFOV()
    {
        float timeElapsed = 0f;

        // ����FOV
        while (timeElapsed < increaseDuration)
        {
            cameraToAdjust.fieldOfView = Mathf.Lerp(initialFOV, targetFOV, timeElapsed / increaseDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        cameraToAdjust.fieldOfView = targetFOV;

        // �ָ�ԭʼFOV
        float normalizeElapsed = 0f;
        while (normalizeElapsed < normalizeDuration)
        {
            float t = normalizeElapsed / normalizeDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);  // Ease OutЧ��
            cameraToAdjust.fieldOfView = Mathf.Lerp(targetFOV, initialFOV, t);
            normalizeElapsed += Time.deltaTime;
            yield return null;
        }

        cameraToAdjust.fieldOfView = initialFOV;
    }
}
