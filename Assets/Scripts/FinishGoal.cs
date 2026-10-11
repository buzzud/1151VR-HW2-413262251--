
using UnityEngine;

public class FinishGoal : MonoBehaviour
{
    private bool isWin = false;

    // 當企鵝碰到終點
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            isWin = true;
            Debug.Log("企鵝成功過關！");
        }
    }

    // 顯示過關畫面
    void OnGUI()
    {
        if (isWin)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);

            style.fontSize = 45;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleCenter;
            style.normal.textColor = Color.yellow;

            GUI.Label(
                new Rect(
                    Screen.width / 2f - 200f,
                    Screen.height / 2f - 60f,
                    400f,
                    120f
                ),
                "過關！",
                style
            );
        }
    }
}
