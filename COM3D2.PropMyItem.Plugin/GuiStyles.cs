using System;
using UnityEngine;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x02000006 RID: 6
	public class GuiStyles
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002099 File Offset: 0x00000299
		public static int FontSize
		{
			get
			{
				return GuiStyles._fontSize;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020A0 File Offset: 0x000002A0
		public static float WindowHeight
		{
			get
			{
				return GuiStyles._windowHeight;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020A7 File Offset: 0x000002A7
		public static float ScrollWidth
		{
			get
			{
				return GuiStyles._scrollWidth;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020AE File Offset: 0x000002AE
		public static float ControlHeight
		{
			get
			{
				return (float)(GuiStyles.FontSize * 2);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020B8 File Offset: 0x000002B8
		public static float Margin
		{
			get
			{
				return (float)GuiStyles.FontSize * 0.5f;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002738 File Offset: 0x00000938
		public static GUIStyle WindowStyle
		{
			get
			{
				if (GuiStyles._windowStyle == null)
				{
					GuiStyles._windowStyle = new GUIStyle("box");
					GuiStyles._windowStyle.fontSize = GuiStyles.FontSize;
					GuiStyles._windowStyle.alignment = TextAnchor.UpperRight;
					GuiStyles._windowStyle.normal.textColor = Color.white;
				}
				return GuiStyles._windowStyle;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002794 File Offset: 0x00000994
		public static GUIStyle LabelStyle
		{
			get
			{
				if (GuiStyles._labelStyle == null)
				{
					GuiStyles._labelStyle = new GUIStyle("label");
					GuiStyles._labelStyle.fontSize = GuiStyles.FontSize;
					GuiStyles._labelStyle.alignment = TextAnchor.MiddleLeft;
					GuiStyles._labelStyle.normal.textColor = Color.white;
				}
				return GuiStyles._labelStyle;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000027F0 File Offset: 0x000009F0
		public static GUIStyle TextFieldStyle
		{
			get
			{
				if (GuiStyles._textfieldStyle == null)
				{
					GuiStyles._textfieldStyle = new GUIStyle("textfield");
					GuiStyles._textfieldStyle.fontSize = GuiStyles.FontSize;
					GuiStyles._textfieldStyle.alignment = TextAnchor.MiddleLeft;
					GuiStyles._textfieldStyle.normal.textColor = Color.white;
				}
				return GuiStyles._textfieldStyle;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000012 RID: 18 RVA: 0x0000284C File Offset: 0x00000A4C
		public static GUIStyle ButtonStyle
		{
			get
			{
				if (GuiStyles._buttonStyle == null)
				{
					GuiStyles._buttonStyle = new GUIStyle("button");
					GuiStyles._buttonStyle.fontSize = GuiStyles.FontSize;
					GuiStyles._buttonStyle.alignment = TextAnchor.MiddleCenter;
					GuiStyles._buttonStyle.normal.textColor = Color.white;
				}
				return GuiStyles._buttonStyle;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000020C6 File Offset: 0x000002C6
		public static GUIStyle ToggleStyle
		{
			get
			{
				if (GuiStyles._buttonStyle == null)
				{
					GuiStyles._toggleStyle = new GUIStyle("toggle");
					GuiStyles._toggleStyle.fontSize = GuiStyles.FontSize;
				}
				return GuiStyles._toggleStyle;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000028A8 File Offset: 0x00000AA8
		public static GUIStyle ListStyle
		{
			get
			{
				if (GuiStyles._listStyle == null)
				{
					GuiStyles._listStyle = new GUIStyle();
					GuiStyles._listStyle.onHover.background = (GuiStyles._listStyle.hover.background = new Texture2D(2, 2));
					GuiStyles._listStyle.padding.left = (GuiStyles._listStyle.padding.right = 4);
					GuiStyles._listStyle.padding.top = (GuiStyles._listStyle.padding.bottom = 1);
					GuiStyles._listStyle.normal.textColor = (GuiStyles._listStyle.onNormal.textColor = Color.white);
					GuiStyles._listStyle.hover.textColor = (GuiStyles._listStyle.onHover.textColor = Color.white);
					GuiStyles._listStyle.active.textColor = (GuiStyles._listStyle.onActive.textColor = Color.white);
					GuiStyles._listStyle.focused.textColor = (GuiStyles._listStyle.onFocused.textColor = Color.blue);
					GuiStyles._listStyle.fontSize = GuiStyles.FontSize;
				}
				return GuiStyles._listStyle;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000020F7 File Offset: 0x000002F7
		public static GUIStyle BoxStyle
		{
			get
			{
				if (GuiStyles._listStyle == null)
				{
					GuiStyles._boxStyle = new GUIStyle("box");
				}
				return GuiStyles._boxStyle;
			}
		}

		// Token: 0x0400000A RID: 10
		private static int _fontSize = 12;

		// Token: 0x0400000B RID: 11
		private static float _windowHeight = 12f;

		// Token: 0x0400000C RID: 12
		private static float _scrollWidth = 20f;

		// Token: 0x0400000D RID: 13
		private static GUIStyle _windowStyle = null;

		// Token: 0x0400000E RID: 14
		private static GUIStyle _labelStyle = null;

		// Token: 0x0400000F RID: 15
		private static GUIStyle _textfieldStyle = null;

		// Token: 0x04000010 RID: 16
		private static GUIStyle _buttonStyle = null;

		// Token: 0x04000011 RID: 17
		private static GUIStyle _toggleStyle = null;

		// Token: 0x04000012 RID: 18
		private static GUIStyle _listStyle = null;

		// Token: 0x04000013 RID: 19
		private static GUIStyle _boxStyle = null;
	}
}
