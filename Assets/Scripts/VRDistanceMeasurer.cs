using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class VRDistanceMeasurer : MonoBehaviour
{
    private enum State
    {
        Clear,
        FirstPointSet,
        SecondPointSet
    }

    private Vector3 firstPoint;
    private Vector3 secondPoint;

    private List<GameObject> markers;

    [SerializeField]
    private TextMesh label;

    [SerializeField]
    private Material material;

    [SerializeField]
    private VRTK_ControllerEvents[] controllerEvents;

    private State currentState = State.Clear;


    private void Awake()
    {
        markers = new List<GameObject>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < controllerEvents.Length; i++)
            controllerEvents[i].TouchpadReleased += OnTriggerReleased;
    }

    private void OnDisable()
    {
        for (int i = 0; i < controllerEvents.Length; i++)
            controllerEvents[i].TouchpadReleased -= OnTriggerReleased;
    }

    private void OnTriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        var controllerEvents = e.controllerReference.actual.GetComponentInChildren<VRTK_ControllerEvents>();
        PlacePoint(controllerEvents);
    }

    private void PlacePoint(VRTK_ControllerEvents controllerEvents)
    {
        switch (currentState)
        {
            case State.Clear:             
                firstPoint = PlaceMarker(controllerEvents);
                if (firstPoint != Vector3.zero)
                    currentState = State.FirstPointSet;
                break;

            case State.FirstPointSet:
                secondPoint = PlaceMarker(controllerEvents);
                if (secondPoint != Vector3.zero)
                {
                    TakeMeasurement();
                    currentState = State.SecondPointSet;
                }
                break;

            case State.SecondPointSet:
                ClearAllPoints();              
                break;
        }
    }

    private Vector3 PlaceMarker(VRTK_ControllerEvents controllerEvents)
    {
        RaycastHit hitInfo;
        var ray = new Ray(controllerEvents.transform.position, controllerEvents.transform.forward);

        if (Physics.Raycast(ray, out hitInfo))
        {
            CreateSphereMarker(hitInfo.point);
            return hitInfo.point;
        }
        else
            return Vector3.zero;
    }

    private void CreateSphereMarker(Vector3 position)
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphere.GetComponentInChildren<Renderer>().sharedMaterial = material;
        markers.Add(sphere);
    }

    private void ClearAllPoints()
    {
        for (int j = 0; j < markers.Count; j++)
        {
            Destroy(markers[j]);
        }

        firstPoint = Vector3.zero;
        secondPoint = Vector3.zero;
        label.text = "0m";

        currentState = State.Clear;
    }

    private void TakeMeasurement()
    {
        if (firstPoint == Vector3.zero || secondPoint == Vector3.zero)
            return;

        var lineRenderer = new GameObject("Line Renderer").AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new Vector3[] { firstPoint, secondPoint });
        lineRenderer.material = material;
        lineRenderer.startWidth = 0.1f;
        markers.Add(lineRenderer.gameObject);

        label.text = Vector3.Distance(firstPoint, secondPoint).ToString() + "m";
    }
}
