using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 抛物线运动
/// 一般情况下我们使用的抛物线都是已知最大高度的形式
/// 公式：
/// Sy = vy0*t + 1/2*g*t*t
/// Sx = vx0*t;
/// </summary>
public class Parabola : MonoBehaviour
{
    //-----------------------------------------------------------------
    // 参数

    /// <summary>
    /// 抛起高度
    /// </summary>
    const float c_height = 3.0f;

    /// <summary>
    /// 重力加速度
    /// </summary>
    const float c_gravity = 10.0f;

    /// <summary>
    /// x轴移动距离
    /// </summary>
    const float c_moveX = 2.0f;

    // 
    //-----------------------------------------------------------------

    /// <summary>
    /// x轴初速度
    /// </summary>
    float m_speedX = 0.0f;

    /// <summary>
    /// y轴初速度
    /// </summary>
    float m_speedY = 0.0f;

    /// <summary>
    /// 总时间
    /// </summary>
    float m_totalTime = 0.0f;

    /// <summary>
    /// 初始位置
    /// </summary>
    Vector3 m_initPos = Vector3.zero;

    /// <summary>
    /// 轨迹
    /// </summary>
    List<Vector3> m_trace = new List<Vector3>();

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 0;

        m_initPos = this.transform.position;

        // 总时间公式：t = 2*sqrt(2h/g)
        m_totalTime = 2.0f * Mathf.Sqrt(2.0f * c_height / c_gravity);

        // x轴初速度公式: vx0 = S / t;
        m_speedX = c_moveX / m_totalTime;

        // y轴初速度公式：vy0 = sqrt(2gh)
        m_speedY = Mathf.Sqrt(2.0f * c_gravity * c_height);

        m_trace.Add(m_initPos);

    }

    float m_time = 0.0f;
    // Update is called once per frame
    void Update()
    {
        Utility.DrowDebugLine(m_trace);

        if (m_time >= m_totalTime)
        {
            return;
        }

        float deleTime = Time.deltaTime;

        // 时间补偿
        if (m_totalTime - m_time < deleTime)
        {
            deleTime = m_totalTime - m_time;
        }

        m_time += deleTime;

        float x = m_speedX * m_time;

        /// 公式：Sy = vy0*t + 1/2*g*t*t 注意：标准公式中g是负数
        float y = m_speedY * m_time - 0.5f * c_gravity * m_time * m_time;

        this.transform.position = m_initPos + new Vector3(x, y);

        m_trace.Add(this.transform.position);
    }
}
