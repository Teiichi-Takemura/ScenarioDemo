﻿using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ManipulationController : MonoBehaviour, IManipulationHandler
{

    Vector3 prevPos;

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        prevPos = eventData.CumulativeDelta;

        // これが無いとオブジェクトにフォーカス時しか操作ができない
        InputManager.Instance.PushModalInputHandler(gameObject);
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        Vector3 moveVector = Vector3.zero;
        moveVector = eventData.CumulativeDelta - prevPos;

        prevPos = eventData.CumulativeDelta;

        // 手の位置が取得できないので決め打ちで40cmに
        var handDistance = 0.4f;
        var objectDistance = Vector3.Distance(Camera.main.transform.position, gameObject.transform.position);

        gameObject.transform.position += (moveVector * (objectDistance / handDistance));
    }
}