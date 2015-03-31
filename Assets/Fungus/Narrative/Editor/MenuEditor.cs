using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Fungus
{

	[CustomEditor (typeof(Fungus.Menu))]
	public class MenuEditor : CommandEditor 
	{
		protected SerializedProperty textProp;
		protected SerializedProperty targetBlockProp;
		protected SerializedProperty hideIfVisitedProp;
		protected SerializedProperty setMenuDialogProp;

		protected virtual void OnEnable()
		{
			textProp = serializedObject.FindProperty("text");
			targetBlockProp = serializedObject.FindProperty("targetBlock");
			hideIfVisitedProp = serializedObject.FindProperty("hideIfVisited");
			setMenuDialogProp = serializedObject.FindProperty("setMenuDialog");
		}
		
		public override void DrawCommandGUI()
		{
			Flowchart flowchart = FlowchartWindow.GetFlowchart();
			if (flowchart == null)
			{
				return;
			}
			
			serializedObject.Update();
			
			EditorGUILayout.PropertyField(textProp);
			
			BlockEditor.BlockField(targetBlockProp,
			                             new GUIContent("Target Block", "Block to call when option is selected"), 
			                             new GUIContent("<None>"), 
			                             flowchart);
			
			EditorGUILayout.PropertyField(hideIfVisitedProp);
			EditorGUILayout.PropertyField(setMenuDialogProp);

			serializedObject.ApplyModifiedProperties();
		}
	}
	
}