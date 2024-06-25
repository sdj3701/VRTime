using System.Collections;
using System.Collections.Generic;
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
    }

    private void Update()
    {
        InitNaviManager(originTransform, positionable.GetWayPointPosition(positionable.GetWayCount()), 0.1f);
    }

    public void InitNaviManager(Transform trans, Vector3 pos, float updateDelay)
    {
        SetOriginTransform(trans);
        SetDestination(pos);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.positionCount = 0;

        //셰이더 파일이름에 주소로 가지고 와야 찾음
        Material mat = new Material(Shader.Find("Custom/SampleTwinkle"));
        mat.SetColor("_BaseColor", Color.green);
        lineRenderer.material = mat;

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

            DrawPath();

            yield return delay;
        }
    }

    public void SetDestination(Vector3 pos)
    {
        targetPos = pos;
    }

    public void SetOriginTransform(Transform trans)
    {
        originTransform = trans;
        transform.position = originTransform.position;
    }

    private void DrawPath()
    {
        lineRenderer.positionCount = navAngent.path.corners.Length;
        lineRenderer.SetPosition(0, transform.position);

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
