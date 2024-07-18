using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DestinationFinder : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private NavMeshAgent navAngent;

    public IPositionable positionable;

    private Vector3 targetPos;
    private Transform originTransform;

    private void Start()
    {
        positionable = new Positionable();
        originTransform = this.transform;
        lineRenderer = GetComponent<LineRenderer>();

    }

    private void Update()
    {
        if (!positionable.GetCheckPoint())
        {
            Debug.Log("�� ã�� ��" + positionable.GetCheckPoint() + " " + positionable.GetWayCount());
            InitNaviManager(originTransform, positionable.GetWayPointPosition(positionable.GetWayCount()), 0.1f);
        }
        /*else
        {
            TODO : ���߿� ���� ���ö��� ���� ��� �߰� ���� �Ʒ��� �������� ���� ����(������ VR ��� ���Ҷ�)
            lineRenderer.gameObject.SetActive(false);
        }*/
    }

    public void InitNaviManager(Transform trans, Vector3 pos, float updateDelay)
    {
        SetOriginTransform(trans);
        SetDestination(pos);
        
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.positionCount = 0;

        //���̴� �����̸��� �ּҷ� ������ �;� ã��
        //Material mat = new Material(Shader.Find("Unlit/Ani2"));
        //mat.SetColor("_BaseColor", Color.green);
        //lineRenderer.material = mat;

        navAngent = GetComponent<NavMeshAgent>();
        navAngent.isStopped = true;
        navAngent.radius = 1.0f;
        navAngent.height = 1.0f;

        StartCoroutine(UpdateNavi(updateDelay));
    }

    private IEnumerator UpdateNavi(float updateDelay)
    {
        WaitForSeconds delay = new WaitForSeconds(updateDelay);
        while (true)
        {
            transform.position = originTransform.position;
            navAngent.SetDestination(targetPos);
            Vector3 zeroy = transform.position;
            zeroy.y = 0;
            transform.position = zeroy;

            DrawPath();

            yield return delay;
        }
    }

    public void SetDestination(Vector3 pos)
    {
        targetPos = pos;
        targetPos.y = 0;
    }

    public void SetOriginTransform(Transform trans)
    {
        originTransform = trans;
        transform.position = originTransform.position;
        Vector3 zeroy = transform.position;
        zeroy.y = 0;
        transform.position = zeroy;
    }

    private void DrawPath()
    {
        lineRenderer.positionCount = navAngent.path.corners.Length;
        lineRenderer.SetPosition(0, transform.position);

        // �� ������Ʈ�� ������ �Ÿ��� ���� tiling ���� ���� �̹����� �̻����� �ʵ��� ���̰� ��
        float distance = Vector3.Distance(targetPos, transform.position);
        //������Ʈ �̸��� �����ϴ� ����� ���̴� �׷����� ���� �ش� �����̸��� ���� ����
        lineRenderer.material.SetFloat("_Float", -distance);


        if (navAngent.path.corners.Length < 2)
        {
            return;
        }

        for (int i = 1; i < navAngent.path.corners.Length; ++i)
        {
            lineRenderer.SetPosition(i, navAngent.path.corners[i]);
        }
    }
}
