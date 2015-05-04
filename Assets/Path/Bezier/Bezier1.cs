using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 1阶贝塞尔
/// 需要两个参数点
/// 公式：B = (1 - t) * P0 + t * P1    t属于[0-1]    
/// </summary>
public class Bezier1 : MonoBehaviour
{
    //-----------------------------------------------------------------
    // 参数

    /// <summary>
    /// 目标点
    /// </summary>
    Vector3 m_target = new Vector3(-3, 3);

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
    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 0;
        m_initPos = this.transform.position;
    }

    /// <summary>
    /// 轨迹
    /// </summary>
    List<Vector3> m_trace = new List<Vector3>();

    // Update is called once per frame
    void Update()
    {        
        Utility.DrowDebugPoint(m_initPos);
        Utility.DrowDebugPoint(m_target);
        Utility.DrowDebugLine(m_initPos, m_target);
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

        // 公式：B = (1 - t) * P0 + t * P1    t属于[0-1]    
        this.transform.position = (1.0f - t) * m_initPos + t * m_target;

        // 移动目标点
        m_target += new Vector3(1.0f * deleTime, 0);

        m_trace.Add(this.transform.position);

    }
}
