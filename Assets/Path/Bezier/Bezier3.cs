using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 三阶贝塞尔
/// 需要四个参数点
/// 公式：B = (1 - t) * (1 - t) * (1 - t) * P0 + 3 * t * (1 - t) * (1 - t) * P1 + 3 * t * t * (1 - t) * P2 + t * t * t * P3   t属于[0-1]    
/// </summary>
public class Bezier3 : MonoBehaviour
{

    //-----------------------------------------------------------------
    // 参数

    /// <summary>
    /// 参数点2（控制点）
    /// </summary>
    readonly Vector3 c_p1 = new Vector3(4, 6);

    /// <summary>
    /// 参数点3（控制点）
    /// </summary>
    readonly Vector3 c_p2 = new Vector3(6, -6);

    /// <summary>
    /// 参数点4(最终目标点)
    /// </summary>
    readonly Vector3 c_p3 = new Vector3(7, 0);

    /// <summary>
    /// 总移动时间
    /// </summary>
    const float c_totalTime = 2.0f;

    // 
    //-----------------------------------------------------------------

    /// <summary>
    /// 消耗时间
    /// </summary>
    float m_time = 0.0f;

    Vector3 m_initPos = Vector3.zero;

    /// <summary>
    /// 轨迹
    /// </summary>
    List<Vector3> m_trace = new List<Vector3>();

    // Use this for initialization
    void Start()
    {
        m_initPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Utility.DrowDebugPoint(m_initPos);
        Utility.DrowDebugPoint(c_p1);
        Utility.DrowDebugPoint(c_p2);
        Utility.DrowDebugPoint(c_p3);
        Utility.DrowDebugLine(m_initPos, c_p1, c_p2, c_p3, m_initPos);
        Utility.DrowDebugLine(m_trace);


        if (m_time >= c_totalTime)
        {
            return;
        }

        float deleTime = Time.deltaTime;

        // 时间补偿
        if (c_totalTime - m_time < deleTime)
        {
            deleTime = c_totalTime - m_time;
        }

        m_time += deleTime;

        // 构建t
        float t = m_time / c_totalTime;

        // 公式：B = (1 - t) * (1 - t) * (1 - t) * P0 + 3 * t * (1 - t) * (1 - t) * P1 + 3 * t * t * (1 - t) * P2 + t * t * t * P3   t属于[0-1]    
        this.transform.position = (1.0f - t) * (1.0f - t) * (1.0f - t) * m_initPos
                                 + 3.0f * t * (1.0f - t) * (1.0f - t) * c_p1 
                                 + 3.0f * t * t * (1.0f - t) * c_p2
                                 + t * t * t * c_p3;

        m_trace.Add(this.transform.position);
    }
}
