using UnityEngine;
using System.Collections;

/// <summary>
/// 匀速直线移动到某点
/// 适用情况：给定速度，目标点不移动
/// </summary>
public class Line1 : MonoBehaviour
{
    //-----------------------------------------------------------------
    // 参数

    /// <summary>
    /// 目标点
    /// </summary>
    readonly Vector3 c_target = new Vector3(2, 3);

    /// <summary>
    /// 速率
    /// </summary>
    const float c_speed = 2.0f;

    // 
    //-----------------------------------------------------------------
    
    /// <summary>
    /// 总移动时间
    /// </summary>
    float m_totalTime = 0.0f;

    /// <summary>
    /// 速度向量
    /// </summary>
    Vector3 m_velocity = new Vector3();

    /// <summary>
    /// 消耗时间
    /// </summary>
    float m_time = 0.0f;
    void Start()
    {
        Application.targetFrameRate = 0;

        Vector3 diff = c_target - this.transform.position;
        float distance = diff.magnitude;

        // 公式 t = S / v;
        m_totalTime = distance / c_speed;

        // 速度向量
        m_velocity = diff / distance * c_speed;
    }

    void Update()
    {
        if (m_time >= m_totalTime)
        {
            return;
        }


        float deltaTime = Time.deltaTime;
        // 时间补偿
        if (m_totalTime - m_time < deltaTime)
        {
            deltaTime = m_totalTime - m_time;
        }

        m_time += deltaTime;

        // 公式：S = v * t 路程
        this.transform.Translate(m_velocity * deltaTime);

        Utility.DrowDebugPoint(c_target);
    }
}
