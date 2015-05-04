using UnityEngine;
using System.Collections;

/// <summary>
/// 匀速直线移动到某点
/// 适用情况：给定时间，目标点不移动
/// </summary>
public class Line2 : MonoBehaviour
{
    //-----------------------------------------------------------------
    // 参数

    /// <summary>
    /// 目标点
    /// </summary>
    readonly Vector3 c_target = new Vector3(2, 3);

    /// <summary>
    /// 总移动时间
    /// </summary>
    const float c_totalTime = 2.0f;

    // 
    //-----------------------------------------------------------------
  
    /// <summary>
    /// 速度向量
    /// </summary>
    Vector3 m_velocity = Vector3.zero;

    /// <summary>
    /// 时间
    /// </summary>
    float m_time = 0;

    void Start()
    {
        Application.targetFrameRate = 0;

        Vector3 diff = c_target - this.transform.position;

        // 公式：v = S / t
        m_velocity = diff / c_totalTime;
    }

    void Update()
    {
        if(m_time >= c_totalTime)
        {
            return;
        }

        
        float deltaTime = Time.deltaTime;
        // 时间补偿
        if (c_totalTime - m_time < deltaTime)
        {
            deltaTime = c_totalTime - m_time;
        }

        m_time += deltaTime;

        // 公式：S = v * t 路程
        this.transform.Translate(m_velocity * deltaTime);

        Utility.DrowDebugPoint(c_target);
    }
}
