using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CapsuleCollider))]
[AddComponentMenu("Physics/Cloth Capsule Margin")]
public sealed class ClothCapsuleMargin : MonoBehaviour
{
    [SerializeField, Tooltip("이 캡슐과 부딪힐 천의 Cloth 컴포넌트입니다.")]
    private Cloth targetCloth;

    [SerializeField, Min(0f), Tooltip("보이는 캡슐 바깥에 추가할 충돌 여유입니다. 월드 단위이며 0.2부터 시험하세요.")]
    private float margin = 0.2f;

    private CapsuleCollider source;
    private CapsuleCollider proxy;
    private Cloth registeredCloth;
    private bool replacedSource;

    private void OnEnable()
    {
        if (!Application.isPlaying)
            return;

        source = GetComponent<CapsuleCollider>();
        if (targetCloth == null || source == null)
        {
            Debug.LogError("Cloth Capsule Margin: Target Cloth에 천의 Cloth를 연결하세요.", this);
            enabled = false;
            return;
        }

        var proxyObject = new GameObject("Cloth Collision Margin");
        proxyObject.transform.SetParent(source.transform, false);
        proxy = proxyObject.AddComponent<CapsuleCollider>();
        // Cloth reads its registered shapes even when ordinary physics collision is disabled.
        proxy.enabled = false;

        if (!SyncShape())
        {
            enabled = false;
            return;
        }

        registeredCloth = targetCloth;
        var colliders = new List<CapsuleCollider>(registeredCloth.capsuleColliders);
        int index = colliders.IndexOf(source);
        replacedSource = index >= 0;
        if (replacedSource)
            colliders[index] = proxy;
        else
            colliders.Add(proxy);
        registeredCloth.capsuleColliders = colliders.ToArray();
    }

    private void LateUpdate()
    {
        if (source == null || registeredCloth == null || proxy == null || !SyncShape())
            enabled = false;
    }

    private bool SyncShape()
    {
        Vector3 scale = source.transform.lossyScale;
        scale = new Vector3(Mathf.Abs(scale.x), Mathf.Abs(scale.y), Mathf.Abs(scale.z));
        int axis = source.direction;
        float axisScale = scale[axis];
        float radialScale = Mathf.Max(scale[(axis + 1) % 3], scale[(axis + 2) % 3]);
        if (axisScale < 0.0001f || radialScale < 0.0001f || float.IsNaN(margin) || float.IsInfinity(margin) || margin < 0f)
        {
            Debug.LogError("Cloth Capsule Margin: Scale은 0이 아니어야 하며 Margin은 0 이상의 유한한 수여야 합니다.", this);
            return false;
        }

        float radius = source.radius * radialScale;
        float height = Mathf.Max(source.height * axisScale, radius * 2f);
        proxy.direction = axis;
        proxy.center = source.center;
        proxy.radius = (radius + margin) / radialScale;
        proxy.height = (height + margin * 2f) / axisScale;
        // shortcut: A margin cannot cover arbitrarily large cloth triangles; refine the cloth mesh if gaps persist.
        return true;
    }

    private void OnDisable()
    {
        if (registeredCloth != null && proxy != null)
        {
            var colliders = new List<CapsuleCollider>(registeredCloth.capsuleColliders);
            int index = colliders.IndexOf(proxy);
            if (index >= 0)
            {
                if (replacedSource && source != null)
                    colliders[index] = source;
                else
                    colliders.RemoveAt(index);
                registeredCloth.capsuleColliders = colliders.ToArray();
            }
        }

        registeredCloth = null;
        if (proxy != null)
        {
            if (Application.isPlaying)
                Destroy(proxy.gameObject);
            else
                DestroyImmediate(proxy.gameObject);
            proxy = null;
        }
    }
}
