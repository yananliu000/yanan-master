using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(AttackBehavior))]
public class AttacBehaviorInspector : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        AttackBehavior attack = target as AttackBehavior;
        AttackBehavior[] m_gameObjects = attack.GetAttackObjects();
        int arrayCount = m_gameObjects.Length;

        EditorGUILayout.LabelField("Charts");

        GUILayout.Box("Total Damge To Enemies", GUILayout.Height(100), GUILayout.MaxWidth(1000));
        Rect r = EditorGUILayout.GetControlRect(true, 0);
        r.x += 5;
        r.y -= 5;
        r.height = 50;
        
        var totalObjectsDamage = m_gameObjects.Sum(x => x.GetTotalDamge());

        int barCount = m_gameObjects.Length;
        float barSpacing = 10;
        float barWidth = r.width / (barCount + barSpacing);
        r.width = barWidth;
        float y = r.y;
        Vector3 prePoint = new Vector3();
        Vector3 point = new Vector3();
        Handles.color = Color.red;

        for (int i = 0; i < barCount; ++i)
        {
            float ratio = m_gameObjects[i].GetTotalDamge() / (float)totalObjectsDamage;
            r.height = Mathf.Max(2, ratio * 100);
            r.y = y - r.height;

            point = new Vector3(r.x + r.width / 2.0f, r.y);

            if (m_gameObjects[i] == attack)
            {
                EditorGUI.DrawRect(r, Color.red);
            }
            else
            {
                EditorGUI.DrawRect(r, Color.black);

            }
            EditorGUI.TextField(r, m_gameObjects[i].GetTotalDamge().ToString());
            r.x += barWidth + barSpacing;
            if(i != 0)
            {
                Handles.DrawLine(prePoint, point);
            }
            prePoint = point;
        }


    }
    #region UnityMessages
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

}
