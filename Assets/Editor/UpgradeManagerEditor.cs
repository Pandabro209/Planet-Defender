using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UpgradeManager))]
public class UpgradeManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		GUILayout.Space(15);

		GUI.backgroundColor = Color.red;

		if (GUILayout.Button("RESET ALL PROGRESS"))
		{
			UpgradeManager upgradeManager = (UpgradeManager)target;

			if (EditorUtility.DisplayDialog(
				"Reset Everything?",
				"This will reset Total Points, High Score, Fire Rate Level and Fire Rate Cost.",
				"RESET",
				"Cancel"))
			{
				upgradeManager.ResetAllProgress();
			}
		}

		GUI.backgroundColor = Color.white;
	}
}