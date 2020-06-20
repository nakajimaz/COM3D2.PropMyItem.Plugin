using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityInjector;
using UnityInjector.Attributes;
using wf;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x0200000D RID: 13
	[PluginFilter("COM3D2x64")]
	[PluginFilter("COM3D2x86")]
	[PluginFilter("COM3D2VRx64")]
	[PluginFilter("COM3D2OHx86")]
	[PluginFilter("COM3D2OHx64")]
	[PluginFilter("COM3D2OHVRx64")]
	[PluginName("PropMyItem")]
	[PluginVersion("2.3.0.0")]
	public class PropMyItem : PluginBase
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00003594 File Offset: 0x00001794
		public PropMyItem()
		{
			this._folders.Add(new PropMyItem.FolderMenu("頭", new string[]
			{
				"顔",
				"眉",
				"目",
				"目ハイライト",
				"ほくろ",
				"唇",
				"歯"
			}));
			this._folders.Add(new PropMyItem.FolderMenu("髪", new string[]
			{
				"前髪",
				"後髪",
				"横髪",
				"エクステ髪",
				"アホ毛"
			}));
			this._folders.Add(new PropMyItem.FolderMenu("身体", new string[]
			{
				"肌",
				"乳首",
				"タトゥー",
				"アンダーヘア",
				"ボディ"
			}));
			this._folders.Add(new PropMyItem.FolderMenu("服装", new string[]
			{
				"帽子",
				"ヘッドドレス",
				"トップス",
				"ボトムス",
				"ワンピース",
				"水着",
				"ブラジャー",
				"パンツ",
				"靴下",
				"靴"
			}));
			this._folders.Add(new PropMyItem.FolderMenu("アクセサリ", new string[]
			{
				" 前髪 ",
				"メガネ",
				"アイマスク",
				"鼻",
				"耳",
				"手袋",
				"ネックレス",
				"チョーカー",
				"リボン",
				"\u3000乳首\u3000",
				"腕",
				"へそ",
				"足首",
				"背中",
				"しっぽ",
				"前穴"
			}));
			this._folders.Add(new PropMyItem.FolderMenu("セット", new string[]
			{
				"メイド服",
				"コスチューム",
				"下着"
			}));
			this._folders.Add(new PropMyItem.FolderMenu("プリセット", new string[]
			{
				"服 / 身体",
				"服",
				"身体"
			}));
			this._folders.Add(new PropMyItem.FolderMenu("全て", new string[0]));
			this._folders.Add(new PropMyItem.FolderMenu("選択中", new string[0]));
			this._categoryMPNDic.Add("顔", MPN.Yorime);
			this._categoryMPNDic.Add("眉", MPN.accsenaka);
			this._categoryMPNDic.Add("目", MPN.accashi);
			this._categoryMPNDic.Add("目ハイライト", MPN.hairs);
			this._categoryMPNDic.Add("ほくろ", MPN.head);
			this._categoryMPNDic.Add("唇", MPN.hairr);
			this._categoryMPNDic.Add("歯", MPN.facegloss);
			this._categoryMPNDic.Add("前髪", MPN.MabutaUpIn);
			this._categoryMPNDic.Add("後髪", MPN.MabutaUpIn2);
			this._categoryMPNDic.Add("横髪", MPN.MabutaUpOut);
			this._categoryMPNDic.Add("エクステ髪", MPN.MabutaUpMiddle);
			this._categoryMPNDic.Add("アホ毛", MPN.MabutaUpOut2);
			this._categoryMPNDic.Add("肌", MPN.accanl);
			this._categoryMPNDic.Add("乳首", MPN.haircolor);
			this._categoryMPNDic.Add("タトゥー", MPN.MabutaLowUpOut);
			this._categoryMPNDic.Add("アンダーヘア", MPN.accshippo);
			this._categoryMPNDic.Add("ボディ", MPN.MayuThick);
			this._categoryMPNDic.Add("帽子", MPN.accmimi);
			this._categoryMPNDic.Add("ヘッドドレス", MPN.chikubicolor);
			this._categoryMPNDic.Add("トップス", MPN.hokuro);
			this._categoryMPNDic.Add("ボトムス", MPN.mayu);
			this._categoryMPNDic.Add("ワンピース", MPN.accnip);
			this._categoryMPNDic.Add("水着", MPN.lip);
			this._categoryMPNDic.Add("ブラジャー", MPN.eye);
			this._categoryMPNDic.Add("パンツ", MPN.eye_hi);
			this._categoryMPNDic.Add("靴下", MPN.eye_hi_r);
			this._categoryMPNDic.Add("靴", MPN.chikubi);
			this._categoryMPNDic.Add(" 前髪 ", MPN.futae);
			this._categoryMPNDic.Add("メガネ", MPN.acchana);
			this._categoryMPNDic.Add("アイマスク", MPN.nose);
			this._categoryMPNDic.Add("鼻", MPN.matsuge_up);
			this._categoryMPNDic.Add("耳", MPN.wear);
			this._categoryMPNDic.Add("手袋", MPN.eyewhite);
			this._categoryMPNDic.Add("ネックレス", MPN.mizugi);
			this._categoryMPNDic.Add("チョーカー", MPN.bra);
			this._categoryMPNDic.Add("リボン", MPN.matsuge_low);
			this._categoryMPNDic.Add("\u3000乳首\u3000", MPN.skirt);
			this._categoryMPNDic.Add("腕", MPN.stkg);
			this._categoryMPNDic.Add("へそ", MPN.panz);
			this._categoryMPNDic.Add("足首", MPN.shoes);
			this._categoryMPNDic.Add("背中", MPN.headset);
			this._categoryMPNDic.Add("しっぽ", MPN.glove);
			this._categoryMPNDic.Add("前穴", MPN.acckamisub);
			this._categoryMPNDic.Add("メイド服", MPN.acckubi);
			this._categoryMPNDic.Add("コスチューム", MPN.acckubiwa);
			this._categoryMPNDic.Add("下着", MPN.accheso);
			foreach (string text in this._categoryMPNDic.Keys)
			{
				this._menuMPNCategoryDic.Add(this._categoryMPNDic[text], text);
			}
			foreach (object obj in Enum.GetValues(typeof(MPN)))
			{
				MPN key = (MPN)obj;
				this._mpnMenuListDictionary.Add(key, new List<MenuInfo>());
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003CB0 File Offset: 0x00001EB0
		public void Awake()
		{
			try
			{
				SceneManager.sceneLoaded += new UnityAction<Scene, LoadSceneMode>(this.OnSceneLoaded);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002253 File Offset: 0x00000453
		private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
		{
			this._sceneLevel = scene.buildIndex;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003CE4 File Offset: 0x00001EE4
		public void Update()
		{
			try
			{
				this._autoShoesHide.Update();
				if (this._isPluginKeyChange && Event.current.type == EventType.keyUp)
				{
					bool control = Event.current.control;
					bool alt = Event.current.alt;
					bool shift = Event.current.shift;
					string text = Event.current.keyCode.ToString();
					if (!string.IsNullOrEmpty(text))
					{
						UserConfig.Instance.IsControlKey = control;
						UserConfig.Instance.IsAltKey = alt;
						UserConfig.Instance.IsShiftKey = shift;
						UserConfig.Instance.GuiVisibleKey = text.ToLower();
						UserConfig.Instance.Save();
						this._isPluginKeyChange = false;
						return;
					}
				}
				KeyCode keyCode = KeyCode.I;// 키코드 설정

				if (EnumUtil.TryParse<KeyCode>(UserConfig.Instance.GuiVisibleKey, true, out keyCode) && UserConfig.Instance.IsControlKey == Event.current.control && UserConfig.Instance.IsAltKey == Event.current.alt && UserConfig.Instance.IsShiftKey == Event.current.shift && Event.current.keyCode == keyCode && Event.current.type == EventType.KeyUp)
				{
					this._isVisible = !this._isVisible;
					this._isMinimum = !this._isVisible;
				}
				else
				{
					if (this._isVisible && (!this._isStartUpLoadead || this._isForcedInit))
					{
						this._isStartUpLoadead = true;
						this.LoadMenuFiles(this._isForcedInit);
						this._isForcedInit = false;
					}
					if (this._isVisible && this._windowRect.Contains(new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y)))
					{
						GameMain.Instance.MainCamera.SetControl(false);
						if (Event.current.type != EventType.keyDown && Event.current.type != EventType.keyUp)
						{
							Input.ResetInputAxes();
						}
					}
					else if (!GameMain.Instance.MainCamera.GetControl())
					{
						GameMain.Instance.MainCamera.SetControl(true);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003F14 File Offset: 0x00002114
		public void OnGUI()
		{
			if (!this._isVisible)
			{
				return;
			}
			if (this._isShowSetting)
			{
				this._windowRect = GUI.Window(4511, this._windowRect, new GUI.WindowFunction(this.GuiSettingFunc), "PropMyItem", GuiStyles.WindowStyle);
				return;
			}
			if (this._isShowFilterSetting)
			{
				this._windowRect = GUI.Window(4511, this._windowRect, new GUI.WindowFunction(this.GuiFilterSettingFunc), "PropMyItem", GuiStyles.WindowStyle);
				return;
			}
			this._windowRect = GUI.Window(4511, this._windowRect, new GUI.WindowFunction(this.GuiFunc), "PropMyItem", GuiStyles.WindowStyle);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003FC0 File Offset: 0x000021C0
		private void GuiSettingFunc(int windowID)
		{
			this._windowRect.width = 300f;
			float num = GuiStyles.ControlHeight + GuiStyles.Margin;
			float margin = GuiStyles.Margin;
			float num2 = this._windowRect.width - GuiStyles.Margin * 2f;
			string text = "キー入力待機中...";
			if (!this._isPluginKeyChange)
			{
				List<string> list = new List<string>();
				if (UserConfig.Instance.IsControlKey)
				{
					list.Add("Ctrl");
				}
				if (UserConfig.Instance.IsShiftKey)
				{
					list.Add("Shift");
				}
				if (UserConfig.Instance.IsAltKey)
				{
					list.Add("Alt");
				}
				list.Add(UserConfig.Instance.GuiVisibleKey.ToUpper());
				text = "表示キー : ";
				for (int i = 0; i < list.Count; i++)
				{
					text += list[i];
					if (i != list.Count - 1)
					{
						text += " + ";
					}
				}
			}
			GUI.enabled = !this._isPluginKeyChange;
			if (GUI.Button(new Rect(margin, num, num2, GuiStyles.ControlHeight), text, GuiStyles.ButtonStyle))
			{
				this._isPluginKeyChange = !this._isPluginKeyChange;
			}
			GUI.enabled = true;
			num += GuiStyles.ControlHeight + GuiStyles.Margin + GuiStyles.Margin;
			bool flag = UserConfig.Instance.IsAutoShoesHide;
			flag = GUI.Toggle(new Rect(margin, num, num2, GuiStyles.ControlHeight), flag, "室内で自動的に靴を脱ぐ ", GuiStyles.ToggleStyle);
			if (flag != UserConfig.Instance.IsAutoShoesHide)
			{
				UserConfig.Instance.IsAutoShoesHide = flag;
				UserConfig.Instance.Save();
			}
			num += GuiStyles.ControlHeight + GuiStyles.Margin + GuiStyles.Margin;
			bool flag2 = UserConfig.Instance.IsOutputInfoLog;
			flag2 = GUI.Toggle(new Rect(margin, num, num2, GuiStyles.ControlHeight), flag2, "アイテム変更時のログ出力", GuiStyles.ToggleStyle);
			if (flag2 != UserConfig.Instance.IsOutputInfoLog)
			{
				UserConfig.Instance.IsOutputInfoLog = flag2;
				UserConfig.Instance.Save();
			}
			num += GuiStyles.ControlHeight + GuiStyles.Margin + GuiStyles.Margin;
			if (GUI.Button(new Rect(margin, num, num2, GuiStyles.ControlHeight), "Menu/Mod 再読み込み", GuiStyles.ButtonStyle))
			{
				this._isShowSetting = false;
				this._isPluginKeyChange = false;
				this._isForcedInit = true;
			}
			num += GuiStyles.ControlHeight + GuiStyles.Margin + GuiStyles.Margin;
			if (GUI.Button(new Rect(margin, num, num2, GuiStyles.ControlHeight), "戻る", GuiStyles.ButtonStyle))
			{
				this._isShowSetting = false;
				this._isPluginKeyChange = false;
			}
			num += GuiStyles.ControlHeight + GuiStyles.Margin;
			this._windowRect.height = num;
			GUI.DragWindow();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004270 File Offset: 0x00002470
		private void GuiFilterSettingFunc(int windowID)
		{
			float num = this._windowRect.width - GuiStyles.Margin * 2f;
			float num2 = this._windowRect.height - GuiStyles.Margin * 2f;
			float num3 = GuiStyles.ControlHeight + GuiStyles.Margin;
			float num4 = GuiStyles.Margin;
			string text = "フィルタ文字列：";
			GUI.Label(new Rect(num4, num3, (float)(GuiStyles.FontSize * text.Length), GuiStyles.ControlHeight), text, GuiStyles.LabelStyle);
			num4 += (float)(GuiStyles.FontSize * text.Length) + GuiStyles.Margin;
			float num5 = num - num4 - GuiStyles.Margin - (float)(GuiStyles.FontSize * 4);
			this._selectedFilterText = GUI.TextField(new Rect(num4, num3, num5, GuiStyles.ControlHeight), this._selectedFilterText, GuiStyles.TextFieldStyle);
			num4 += num5 + GuiStyles.Margin;
			GUI.enabled = !string.IsNullOrEmpty(this._selectedFilterText);
			if (GUI.Button(new Rect(num4, num3, (float)(GuiStyles.FontSize * 4), GuiStyles.ControlHeight), "登録", GuiStyles.ButtonStyle))
			{
				UserConfig.Instance.FilterTextList.Add(this._selectedFilterText);
				UserConfig.Instance.FilterTextList.Sort();
				UserConfig.Instance.Save();
				this._isShowFilterSetting = false;
			}
			GUI.enabled = true;
			num4 = GuiStyles.Margin;
			num3 += GuiStyles.ControlHeight + GuiStyles.Margin;
			List<string> filterTextList = UserConfig.Instance.FilterTextList;
			int count = filterTextList.Count;
			Rect rect =new Rect(num4, num3, num, num2 - num3 - GuiStyles.ControlHeight - (GuiStyles.Margin * 2f));
			Rect rect2 = new Rect(0f, 0f, num - GuiStyles.ScrollWidth, (float)count * (GuiStyles.ControlHeight + GuiStyles.Margin));
			this._scrollFilterPosition = GUI.BeginScrollView(rect, this._scrollFilterPosition, rect2);
			Rect rect3 = new Rect(GuiStyles.Margin, 0f, rect2.width - GuiStyles.Margin - 50f, GuiStyles.ControlHeight);
			Rect rect4 = new Rect(rect3.x + rect3.width + GuiStyles.Margin, 0f, 50f, GuiStyles.ControlHeight);
			for (int i = 0; i < filterTextList.Count; i++)
			{
				rect3.y = (float)i * (GuiStyles.ControlHeight + GuiStyles.Margin);
				rect4.y = rect3.y;
				if (GUI.Button(rect3, filterTextList[i], GuiStyles.ButtonStyle))
				{
					this._selectedFilterText = filterTextList[i];
					this._isShowFilterSetting = false;
				}
				if (GUI.Button(rect4, "x", GuiStyles.ButtonStyle))
				{
					UserConfig.Instance.FilterTextList.RemoveAt(i);
					UserConfig.Instance.Save();
				}
			}
			GUI.EndScrollView();
			num3 = num2 - GuiStyles.ControlHeight - GuiStyles.Margin * 2f;
			if (GUI.Button(new Rect(num4, num3, num, GuiStyles.ControlHeight), "戻る", GuiStyles.ButtonStyle))
			{
				this._isShowSetting = false;
				this._isPluginKeyChange = false;
				this._isShowFilterSetting = false;
			}
			num3 += GuiStyles.ControlHeight + GuiStyles.Margin;
			GUI.DragWindow();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004590 File Offset: 0x00002790
		private void GuiFunc(int windowID)
		{
			try
			{
				string text = this._isMinimum ? "" : "最小化";
				Rect rect = new Rect(GuiStyles.Margin, 0f, (float)(GuiStyles.FontSize * (text.Length + 2)), GuiStyles.ControlHeight);
				this._isMinimum = GUI.Toggle(rect, this._isMinimum, text, GuiStyles.ToggleStyle);
				if (this._isMinimum)
				{
					this._windowRect.width = 100f;
					this._windowRect.height = GuiStyles.ControlHeight;
				}
				else
				{
					this._windowRect.height = 570f;
					float yPos = GuiStyles.ControlHeight + GuiStyles.Margin;
					float margin = GuiStyles.Margin;
					this.guiSelectedMaid(ref margin, ref yPos);
					this.guiSelectedCategoryFolder(ref margin, yPos, this._windowRect.height);
					this.guiSelectedCategory(ref margin, yPos, this._windowRect.height);
					if (this._folders[this._selectedFolder].Name == "プリセット")
					{
						this.guiSelectedPreset(ref margin, yPos, this._windowRect.height);
					}
					else if (this._folders[this._selectedFolder].Name == "Debug")
					{
						this.guiDebug(ref margin, yPos, this._windowRect.height);
					}
					else
					{
						if (this._selectedMPN != MPN.null_mpn || this._folders[this._selectedFolder].Name == "全て" || this._folders[this._selectedFolder].Name == "選択中")
						{
							this.guiSelectedItemFilter(margin, yPos);
							this.guiSelectedItem(ref margin, yPos, this._windowRect.height);
						}
						this.guiSelectedColorSet(ref margin, ref yPos);
						this.guiSelectedMugenColor(ref margin, ref yPos);
					}
					this._windowRect.width = margin;
				}
			}
			catch (Exception ex)
			{
				CommonUtil.Log(ex.StackTrace);
			}
			finally
			{
				GUI.DragWindow();
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000047B4 File Offset: 0x000029B4
		private void guiSelectedMaid(ref float xPos, ref float yPos)
		{
			try
			{
				List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
				if (visibleMaidList.Count < 1)
				{
					this._selectedMaid = -1;
				}
				else
				{
					if (this._selectedMaid >= visibleMaidList.Count || this._selectedMaid < 0)
					{
						this._selectedMaid = 0;
					}
					string text = visibleMaidList[this._selectedMaid].status.isFirstNameCall ? visibleMaidList[this._selectedMaid].status.firstName : visibleMaidList[this._selectedMaid].status.lastName;
					Rect rect = new Rect(xPos + 30f, 8f, 50f, 75f);
					Rect rect2 = new Rect(xPos + 85f, yPos, (float)(10 * GuiStyles.FontSize), GuiStyles.ControlHeight);
					Rect rect3 = new Rect(xPos, yPos + 24f, (float)(2 * GuiStyles.FontSize), GuiStyles.ControlHeight);
					Rect rect4 = new Rect(xPos + 85f, yPos + 24f, (float)(2 * GuiStyles.FontSize), GuiStyles.ControlHeight);
					GUI.Label(rect, visibleMaidList[this._selectedMaid].GetThumIcon(), GuiStyles.LabelStyle);
					GuiStyles.LabelStyle.alignment = TextAnchor.MiddleLeft;
					GUI.Label(rect2, text, GuiStyles.LabelStyle);
					GuiStyles.LabelStyle.alignment = TextAnchor.MiddleCenter;
					if (GUI.Button(rect3, "<", GuiStyles.ButtonStyle))
					{
						this._selectedMaid = ((this._selectedMaid == 0) ? (visibleMaidList.Count - 1) : (this._selectedMaid - 1));
					}
					if (GUI.Button(rect4, ">", GuiStyles.ButtonStyle))
					{
						this._selectedMaid = ((this._selectedMaid == visibleMaidList.Count - 1) ? 0 : (this._selectedMaid + 1));
					}
				}
			}
			finally
			{
				yPos += 50f;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000498C File Offset: 0x00002B8C
		private void updateMaidEyePosY(Maid maid, float value)
		{
			float num = 5000f;
			float num2 = maid.body0.trsEyeL.localPosition.y * num;
			if (value < 0f)
			{
				value = 0f;
			}
			Vector3 localPosition = maid.body0.trsEyeL.localPosition;
			Vector3 localPosition2 = maid.body0.trsEyeR.localPosition;
			maid.body0.trsEyeL.localPosition = new Vector3(localPosition.x, System.Math.Max((num2 + value) / num, 0f), localPosition.z);
			maid.body0.trsEyeR.localPosition = new Vector3(localPosition.x, System.Math.Min((num2 - value) / num, 0f), localPosition.z);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004A48 File Offset: 0x00002C48
		private void guiSelectedCategoryFolder(ref float xPos, float yPos, float windowHeight)
		{
			float num = (float)(GuiStyles.FontSize * 6);
			float num2 = (float)((double)GuiStyles.ControlHeight * 1.5);
			for (int i = 0; i < this._folders.Count; i++)
			{
				if (this._folders[i].Name == "全て")
				{
					yPos += GuiStyles.Margin * 2f;
				}
				Rect rect = new Rect(xPos, yPos + (num2 + GuiStyles.Margin) * (float)i, num, num2);
				GUI.enabled = (this._selectedFolder != i);
				if (GUI.Button(rect, this._folders[i].Name, GuiStyles.ButtonStyle))
				{
					this._selectedFolder = i;
					this._selectedMPN = MPN.null_mpn;
					this._selectedCategory = -1;
					this._selectedItem = null;
					this._selectedVariationItem = null;
				}
				GUI.enabled = true;
			}
			if (GUI.Button(new Rect(xPos, windowHeight - num2 - GuiStyles.Margin, num, num2), "設定", GuiStyles.ButtonStyle))
			{
				this._isShowSetting = true;
			}
			xPos += num + GuiStyles.Margin;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004B5C File Offset: 0x00002D5C
		private void nextPattern(Maid maid, MPN mpn, string basename, string filename, bool isPrev = false)
		{
			List<MenuInfo> list = null;
			if (!this._mpnMenuListDictionary.TryGetValue(mpn, out list))
			{
				return;
			}
			foreach (MenuInfo menuInfo in list)
			{
				if (!(menuInfo.FileName.ToLower() != basename))
				{
					if (menuInfo.IsColorLock)
					{
						break;
					}
					List<MenuInfo> variationMenuList = menuInfo.VariationMenuList;
					if (variationMenuList == null || variationMenuList.Count < 2)
					{
						break;
					}
					for (int i = 0; i < variationMenuList.Count; i++)
					{
						if (variationMenuList[i].FileName.ToLower() == filename)
						{
							string fileName = variationMenuList[0].FileName;
							if (!isPrev)
							{
								if (i < variationMenuList.Count - 1)
								{
									fileName = variationMenuList[i + 1].FileName;
								}
							}
							else if (i == 0)
							{
								fileName = variationMenuList[variationMenuList.Count - 1].FileName;
							}
							else
							{
								fileName = variationMenuList[i - 1].FileName;
							}
							maid.SetProp(mpn, fileName, fileName.GetHashCode(), false, false);
							maid.AllProcProp();
							if (UserConfig.Instance.IsOutputInfoLog)
							{
								Console.WriteLine("PropMyItem：change item = " + fileName);
							}
							return;
						}
					}
				}
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004CD0 File Offset: 0x00002ED0
		private void guiSelectedCategory(ref float xPos, float yPos, float windowHeight)
		{
			int num = this._folders[this._selectedFolder].Categories.Length;
			if (num > 0)
			{
				float num2 = (float)(7 * GuiStyles.FontSize);
				float num3 = GuiStyles.ControlHeight * 1.5f;
				Rect rect = new Rect(0f, 0f, num2, (num3 + GuiStyles.Margin) * (float)num);
				Rect rect2 = new Rect(xPos, yPos, rect.width + GuiStyles.ScrollWidth, windowHeight - yPos - GuiStyles.Margin);
				this._categoryScrollPosition = GUI.BeginScrollView(rect2, this._categoryScrollPosition, rect);
				for (int i = 0; i < num; i++)
				{
					Rect rect3 = new Rect(0f, (num3 + GuiStyles.Margin) * (float)i, num2, num3);
					GUI.enabled = (this._selectedCategory != i);
					if (GUI.Button(rect3, this._folders[this._selectedFolder].Categories[i], GuiStyles.ButtonStyle))
					{
						this._selectedPresetList.Clear();
						this._selectedItem = null;
						this._selectedVariationItem = null;
						this._scrollPosition.y = 0f;
						MPN selectedMPN = MPN.Yorime;
						if (this._categoryMPNDic.TryGetValue(this._folders[this._selectedFolder].Categories[i], out selectedMPN))
						{
							this._selectedMPN = selectedMPN;
						}
						else
						{
							if (this._folders[this._selectedFolder].Name == "プリセット")
							{
								List<CharacterMgr.Preset> list = GameMain.Instance.CharacterMgr.PresetListLoad();
								this._selectedPresetType = CharacterMgr.PresetType.All;
								if (this._folders[this._selectedFolder].Categories[i] == "服")
								{
									this._selectedPresetType = CharacterMgr.PresetType.Wear;
								}
								else if (this._folders[this._selectedFolder].Categories[i] == "身体")
								{
									this._selectedPresetType = CharacterMgr.PresetType.Body;
								}
								foreach (CharacterMgr.Preset preset in list)
								{
									if (preset.ePreType == this._selectedPresetType)
									{
										this._selectedPresetList.Add(preset);
									}
								}
							}
							this._selectedMPN = MPN.null_mpn;
						}
						this._selectedCategory = i;
					}
					GUI.enabled = true;
				}
				//this._folders[this._selectedFolder].Name == "プリセット";
				GUI.EndScrollView();
				xPos += rect2.width + GuiStyles.Margin;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002262 File Offset: 0x00000462
		private static int CompareCreateTime(string fileX, string fileY)
		{
			return DateTime.Compare(File.GetLastWriteTime(fileX), File.GetCreationTime(fileY));
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004F68 File Offset: 0x00003168
		private void guiDebug(ref float xPos, float yPos, float windowHeight)
		{
			float num = 200f;
			if (GUI.Button(new Rect(xPos, yPos, num, GuiStyles.ControlHeight), "プリセット保存", GuiStyles.ButtonStyle))
			{
				List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
				if (this._selectedMaid >= 0 && visibleMaidList.Count - 1 >= this._selectedMaid)
				{
					Maid f_maid = visibleMaidList[this._selectedMaid];
					GameMain.Instance.CharacterMgr.PresetSave(f_maid, CharacterMgr.PresetType.All);
				}
			}
			yPos += GuiStyles.ControlHeight + GuiStyles.Margin + GuiStyles.Margin;
			xPos += num + GuiStyles.Margin;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004FFC File Offset: 0x000031FC
		private void guiSelectedPreset(ref float xPos, float yPos, float windowHeight)
		{
			float num = 300f;
			float num2 = 4f;
			float num3 = num / num2;
			float num4 = (float)((double)num3 * 1.5);
			if (this._selectedPresetList.Count > 0)
			{
				int count = this._selectedPresetList.Count;
				int num5 = ((float)count % num2 == 0f) ? 0 : 1;
				Rect rect = new Rect(0f, 0f, num, (float)((int)((float)count / num2) + num5) * num4);
				Rect rect2 = new Rect(xPos, yPos, rect.width + GuiStyles.ScrollWidth, windowHeight - yPos - (float)GuiStyles.FontSize);
				this._scrollPosition = GUI.BeginScrollView(rect2, this._scrollPosition, rect);
				new List<int>();
				new Rect(0f, 0f, num3, num4);
				for (int i = 0; i < count; i++)
				{
					Rect rect3 = new Rect(num3 * ((float)i % num2), num4 * (float)((int)((float)i / num2)), num3, num4);
					new Rect(num3 * ((float)i % num2), num4 * (float)((int)((float)i / num2)), 20f, 20f);
					if (Event.current.type == EventType.Repaint)
					{
						if (GUI.Button(rect3, this._selectedPresetList[i].texThum))
						{
							List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
							if (this._selectedMaid >= 0 && visibleMaidList.Count - 1 >= this._selectedMaid)
							{
								Maid maid = visibleMaidList[this._selectedMaid];
								MPN[] array = new MPN[]
								{
									MPN.acchana,
									MPN.futae,
									MPN.matsuge_low,
									MPN.MabutaUpMiddle,
									MPN.chikubicolor,
									MPN.accmimi
								};
								this.presetRestoreDic_.Clear();
								foreach (MPN mpn in array)
								{
									MaidProp prop = maid.GetProp(mpn);
									this.presetRestoreDic_.Add(mpn, prop.strFileName);
								}
								GameMain.Instance.CharacterMgr.PresetSet(maid, this._selectedPresetList[i]);
							}
						}
					}
					else if (GUI.Button(rect3, this._selectedPresetList[i].texThum))
					{
						List<Maid> visibleMaidList2 = CommonUtil.GetVisibleMaidList();
						if (this._selectedMaid >= 0 && visibleMaidList2.Count - 1 >= this._selectedMaid)
						{
							Maid maid2 = visibleMaidList2[this._selectedMaid];
							MPN[] array3 = new MPN[]
							{
								MPN.acchana,
								MPN.futae,
								MPN.matsuge_low,
								MPN.MabutaUpMiddle,
								MPN.chikubicolor,
								MPN.accmimi
							};
							this.presetRestoreDic_.Clear();
							foreach (MPN mpn2 in array3)
							{
								MaidProp prop2 = maid2.GetProp(mpn2);
								this.presetRestoreDic_.Add(mpn2, prop2.strFileName);
							}
							GameMain.Instance.CharacterMgr.PresetSet(maid2, this._selectedPresetList[i]);
						}
					}
				}
				GUI.EndScrollView();
				xPos += num + GuiStyles.ScrollWidth + GuiStyles.Margin;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000052F8 File Offset: 0x000034F8
		private void guiSelectedItemFilter(float xPos, float yPos)
		{
			float num = xPos;
			float num2 = yPos - GuiStyles.ControlHeight - GuiStyles.Margin;
			string[] array = new string[]
			{
				"全て",
				"製品",
				"MOD"
			};
			int num3 = 112;
			if (this._folders[this._selectedFolder].Name == "全て" || this._folders[this._selectedFolder].Name == "選択中")
			{
				num += 40f;
			}
			else
			{
				num3 += 40;
			}
			GUI.Label(new Rect(num, num2, (float)(GuiStyles.FontSize * 6), GuiStyles.ControlHeight), "フィルタ：", GuiStyles.LabelStyle);
			num += (float)(GuiStyles.FontSize * 5) + GuiStyles.Margin;
			Rect rect = new Rect(num, num2 - GuiStyles.ControlHeight, (float)(GuiStyles.FontSize * 7), GuiStyles.ControlHeight);
			this._isFavFilter = GUI.Toggle(rect, this._isFavFilter, "お気に入り", GuiStyles.ToggleStyle);
			Rect rect2 = new Rect(num, num2, (float)(GuiStyles.FontSize * 4), GuiStyles.ControlHeight);
			if (GUI.Button(rect2, array[this._selectedFilter], GuiStyles.ButtonStyle))
			{
				this._selectedFilter = ((this._selectedFilter == 2) ? 0 : (this._selectedFilter + 1));
				this._scrollPosition.y = 0f;
			}
			num += (float)(GuiStyles.FontSize * 4) + GuiStyles.Margin;
			Rect rect3 = new Rect(num, num2, (float)num3, GuiStyles.ControlHeight);
			this._selectedFilterText = GUI.TextField(rect3, this._selectedFilterText, GuiStyles.TextFieldStyle);
			num += (float)(num3 + 4);
			rect2.Set(num, num2, (float)(GuiStyles.FontSize * 2), GuiStyles.ControlHeight);
			if (GUI.Button(rect2, "▽", GuiStyles.ButtonStyle))
			{
				this._isShowFilterSetting = true;
			}
			num += (float)(GuiStyles.FontSize * 2) + GuiStyles.Margin;
			rect2.Set(num, num2, (float)(GuiStyles.FontSize * 2), GuiStyles.ControlHeight);
			if (GUI.Button(rect2, "x", GuiStyles.ButtonStyle))
			{
				this._selectedFilterText = string.Empty;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00005504 File Offset: 0x00003704
		private List<MenuInfo> getItemList()
		{
			List<MenuInfo> list = new List<MenuInfo>();
			if (this._folders[this._selectedFolder].Name == "全て")
			{
				using (Dictionary<string, MPN>.ValueCollection.Enumerator enumerator = this._categoryMPNDic.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MPN key = enumerator.Current;
						List<MenuInfo> collection = null;
						if (this._mpnMenuListDictionary.TryGetValue(key, out collection))
						{
							list.AddRange(collection);
						}
					}
					return list;
				}
			}
			if (this._folders[this._selectedFolder].Name == "選択中")
			{
				List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
				if (this._selectedMaid < 0 || this._selectedMaid > visibleMaidList.Count - 1)
				{
					return list;
				}
				Maid maid = visibleMaidList[this._selectedMaid];
				using (Dictionary<string, MPN>.ValueCollection.Enumerator enumerator = this._categoryMPNDic.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MPN mpn = enumerator.Current;
						if (mpn != MPN.acckubi && mpn != MPN.acckubiwa && mpn != MPN.accheso)
						{
							List<MenuInfo> list2 = null;
							if (this._mpnMenuListDictionary.TryGetValue(mpn, out list2))
							{
								string selectedMenuFileName = CommonUtil.GetSelectedMenuFileName(new MPN?(mpn), maid);
								bool flag = false;
								foreach (MenuInfo menuInfo in list2)
								{
									if (menuInfo != null)
									{
										foreach (MenuInfo menuInfo2 in menuInfo.VariationMenuList)
										{
											if (menuInfo2.FileName.IndexOf(selectedMenuFileName, StringComparison.OrdinalIgnoreCase) == 0)
											{
												if (menuInfo2.IconName != "_I_del.tex")
												{
													list.Add(menuInfo);
												}
												flag = true;
												break;
											}
										}
										if (flag)
										{
											break;
										}
									}
								}
							}
						}
					}
					return list;
				}
			}
			this._mpnMenuListDictionary.TryGetValue(this._selectedMPN, out list);
			return list;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00005744 File Offset: 0x00003944
		private void guiSelectedItem(ref float xPos, float yPos, float windowHeight)
		{
			List<MenuInfo> itemList = this.getItemList();
			if (itemList == null || itemList.Count == 0)
			{
				return;
			}
			float num = 8f;
			float num2 = 20f;
			float num3 = 8f;
			float num4 = 3f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = num6;
			int num8 = itemList.Count;
			int num9 = 0;
			if (this._selectedMPN == MPN.acckubi || this._selectedMPN == MPN.acckubiwa || this._selectedMPN == MPN.accheso)
			{
				num6 = 75f;
				num7 = num6 * 1.44f;
				num4 = 4f;
				num = 16f;
				num2 = 16f;
				num3 = 10f;
			}
			else
			{
				num6 = 60f;
				num7 = 60f;
				num4 = 5f;
				num = 18f;
				num2 = 24f;
				num3 = 6f;
			}
			num5 = num6 * num4;
			ReadOnlyDictionary<string, bool> havePartsItems = GameMain.Instance.CharacterMgr.status.havePartsItems;
			for (int i = 0; i < num8; i++)
			{
				MenuInfo menuInfo = itemList[i];
				menuInfo.IsHave = true;
				if (menuInfo.IsShopTarget && havePartsItems.ContainsKey(menuInfo.FileName) && !havePartsItems[menuInfo.FileName])
				{
					num9++;
					menuInfo.IsHave = false;
				}
				else
				{
					if (this._selectedFilter == 1)
					{
						if (menuInfo.IsMod)
						{
							num9++;
							menuInfo.IsHave = false;
							goto IL_1DC;
						}
					}
					else if (this._selectedFilter == 2 && !menuInfo.IsMod)
					{
						num9++;
						menuInfo.IsHave = false;
						goto IL_1DC;
					}
					if (this._isFavFilter && !menuInfo.IsFavorite)
					{
						num9++;
						menuInfo.IsHave = false;
					}
					else if (!string.IsNullOrEmpty(this._selectedFilterText) && menuInfo.ItemName.IndexOf(this._selectedFilterText, StringComparison.OrdinalIgnoreCase) == -1 && menuInfo.FilePath.IndexOf(this._selectedFilterText, StringComparison.OrdinalIgnoreCase) == -1)
					{
						num9++;
						menuInfo.IsHave = false;
					}
				}
				IL_1DC:;
			}
			num8 -= num9;
			int num10 = ((float)num8 % num4 == 0f) ? 0 : 1;
			int num11 = (int)(windowHeight - yPos - (float)GuiStyles.FontSize - GuiStyles.ControlHeight);
			Rect rect = new Rect(0f, 0f, num6 * num4, (float)((int)((float)num8 / num4) + num10) * num7);
			if (this._folders[this._selectedFolder].Name == "選択中")
			{
				rect.Set(0f, 0f, num6 * num4, (float)((int)((float)(num8 + 5) / num4) + num10) * num7);
			}
			Rect rect2 = new Rect(xPos, yPos + GuiStyles.ControlHeight, rect.width + GuiStyles.ScrollWidth, (float)num11);
			this._scrollPosition = GUI.BeginScrollView(rect2, this._scrollPosition, rect);
			new List<int>();
			new Rect(0f, 0f, num6, num7);
			GUIStyle guistyle = new GUIStyle();
			guistyle.alignment = TextAnchor.UpperRight;
			guistyle.fontSize = 10;
			guistyle.normal = new GUIStyleState
			{
				textColor = Color.black
			};
			GUIStyle guistyle2 = new GUIStyle("button");
			guistyle2.fontSize = 14;
			guistyle2.alignment = TextAnchor.UpperRight;
			guistyle2.normal.textColor = Color.white;
			guistyle2.hover.textColor = Color.white;
			guistyle2.padding = new RectOffset(0, 3, 1, 0);
			GUIStyle guistyle3 = new GUIStyle("button");
			guistyle3.fontSize = 14;
			guistyle3.alignment = TextAnchor.UpperRight;
			guistyle3.normal.textColor = Color.yellow;
			guistyle3.hover.textColor = Color.yellow;
			guistyle3.padding = new RectOffset(0, 3, 1, 0);
			GUIStyle guistyle4 = new GUIStyle("button");
			guistyle4.fontSize = 14;
			guistyle4.alignment = TextAnchor.UpperRight;
			guistyle4.normal.textColor = Color.white;
			guistyle4.hover.textColor = Color.white;
			guistyle4.padding = new RectOffset(0, 6, 1, 0);
			GUIStyle guistyle5 = new GUIStyle("button");
			guistyle5.fontSize = 14;
			guistyle5.alignment = TextAnchor.UpperRight;
			guistyle5.normal.textColor = Color.red;
			guistyle5.hover.textColor = Color.red;
			guistyle5.padding = new RectOffset(0, 6, 1, 0);
			Maid maid = null;
			string text = string.Empty;
			List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
			if (this._selectedMaid >= 0 && visibleMaidList.Count - 1 >= this._selectedMaid)
			{
				maid = visibleMaidList[this._selectedMaid];
				text = CommonUtil.GetSelectedMenuFileName(new MPN?(this._selectedMPN), maid);
			}
			float y = this._scrollPosition.y;
			float num12 = this._scrollPosition.y + (float)num11;
			int num13 = 0;
			for (int j = 0; j < itemList.Count; j++)
			{
				MenuInfo menuInfo2 = itemList[j];
				if (menuInfo2.IsHave)
				{
					bool enabled = true;
					if (!string.IsNullOrEmpty(text))
					{
						if (menuInfo2.FileName.IndexOf(text, StringComparison.OrdinalIgnoreCase) == 0)
						{
							enabled = false;
							this._selectedItem = menuInfo2;
							this._selectedVariationItem = menuInfo2.VariationMenuList[0];
						}
						else if (menuInfo2.VariationMenuList.Count > 1)
						{
							foreach (MenuInfo menuInfo3 in menuInfo2.VariationMenuList)
							{
								if (menuInfo3.FileName.IndexOf(text, StringComparison.OrdinalIgnoreCase) == 0)
								{
									this._selectedItem = menuInfo2;
									this._selectedVariationItem = menuInfo3;
									enabled = false;
									break;
								}
							}
						}
					}
					float num14 = num7 * (float)((int)((float)num13 / num4));
					float num15 = num14 + num7;
					if ((y <= num14 && num15 <= num12) || (num14 <= y && y <= num15) || (y <= num14 && num14 <= num12))
					{
						if (menuInfo2.Icon == null && !string.IsNullOrEmpty(menuInfo2.IconName) && !menuInfo2.IsError)
						{
							if (!menuInfo2.IsOfficialMOD)
							{
								try
								{
									menuInfo2.Icon = ImportCM.CreateTexture(menuInfo2.IconName);
									goto IL_637;
								}
								catch (Exception)
								{
									menuInfo2.IsError = true;
									goto IL_D69;
								}
							}
							MenuInfo menuInfo4 = MenuModParser.parseMod(menuInfo2.FilePath);
							menuInfo2.Icon = menuInfo4.Icon;
						}
						IL_637:
						string text2 = menuInfo2.ItemName;
						if (this._folders[this._selectedFolder].Name == "全て" || this._folders[this._selectedFolder].Name == "選択中")
						{
							text2 = menuInfo2.CategoryName + "：" + menuInfo2.ItemName;
						}
						Rect rect3 = new Rect(num6 * ((float)num13 % num4), num7 * (float)((int)((float)num13 / num4)), num6, num7);
						Rect rect4 = new Rect(rect3.x, rect3.y + rect3.height - 20f, 20f, 20f);
						Rect rect5 = new Rect(rect3.x, rect3.y, 20f, 20f);
						Rect rect6 = new Rect(rect3.x + rect3.width - 20f, rect3.y + rect3.height - 20f, 20f, 20f);
						if (Event.current.type == EventType.Repaint)
						{
							GUI.enabled = enabled;
							if (GUI.Button(rect3, new GUIContent(menuInfo2.Icon, text2)))
							{
								this._selectedItem = menuInfo2;
								this._selectedVariationItem = menuInfo2.VariationMenuList[0];
								List<Maid> visibleMaidList2 = CommonUtil.GetVisibleMaidList();
								if (this._selectedMaid >= 0 && visibleMaidList2.Count - 1 >= this._selectedMaid)
								{
									if (UserConfig.Instance.IsOutputInfoLog)
									{
										Console.WriteLine("PropMyItem：change item = " + menuInfo2.FileName);
									}
									visibleMaidList2[this._selectedMaid].SetProp(menuInfo2.MPN, menuInfo2.FileName, Path.GetFileName(menuInfo2.FileName).GetHashCode(), false, false);
									if ((menuInfo2.MPN == MPN.accashi || menuInfo2.MPN == MPN.accsenaka || menuInfo2.MPN == MPN.accanl || menuInfo2.MPN == MPN.accshippo || menuInfo2.MPN == MPN.haircolor) && menuInfo2.ColorSetMenuList.Count > 0)
									{
										MenuInfo menuInfo5 = this._selectedVariationItem.ColorSetMenuList[0];
										visibleMaidList2[this._selectedMaid].SetProp(menuInfo2.ColorSetMPN, menuInfo5.FileName, Path.GetFileName(menuInfo5.FileName).GetHashCode(), false, false);
									}
									visibleMaidList2[this._selectedMaid].AllProcProp();
								}
							}
							GUI.enabled = true;
							GUIStyle guistyle6 = guistyle2;
							if (menuInfo2.IsFavorite)
							{
								guistyle6 = guistyle3;
							}
							if (GUI.Button(rect4, new GUIContent("★", text2), guistyle6))
							{
								if (menuInfo2.IsFavorite)
								{
									menuInfo2.IsFavorite = false;
									UserConfig.Instance.FavList.Remove(menuInfo2.FileName.ToLower());
								}
								else
								{
									menuInfo2.IsFavorite = true;
									UserConfig.Instance.FavList.Add(menuInfo2.FileName.ToLower());
								}
								UserConfig.Instance.Save();
							}
							if (this._folders[this._selectedFolder].Name == "選択中")
							{
								if (GUI.Button(rect5, new GUIContent("×", text2)))
								{
									maid.DelProp(menuInfo2.MPN, false);
									maid.AllProcProp();
								}
								GUIStyle guistyle7 = guistyle4;
								if (menuInfo2.IsColorLock)
								{
									guistyle7 = guistyle5;
								}
								if (GUI.Button(rect6, new GUIContent("■", text2), guistyle7))
								{
									if (menuInfo2.IsColorLock)
									{
										menuInfo2.IsColorLock = false;
										UserConfig.Instance.ColorLockList.Remove(menuInfo2.FileName.ToLower());
									}
									else
									{
										menuInfo2.IsColorLock = true;
										UserConfig.Instance.ColorLockList.Add(menuInfo2.FileName.ToLower());
									}
									UserConfig.Instance.Save();
								}
							}
						}
						else
						{
							if (this._folders[this._selectedFolder].Name == "選択中")
							{
								if (GUI.Button(rect5, new GUIContent("×", text2)))
								{
									maid.DelProp(menuInfo2.MPN, false);
									maid.AllProcProp();
								}
								GUIStyle guistyle8 = guistyle4;
								if (menuInfo2.IsColorLock)
								{
									guistyle8 = guistyle5;
								}
								if (GUI.Button(rect6, new GUIContent("■", text2), guistyle8))
								{
									if (menuInfo2.IsColorLock)
									{
										menuInfo2.IsColorLock = false;
										UserConfig.Instance.ColorLockList.Remove(menuInfo2.FileName.ToLower());
									}
									else
									{
										menuInfo2.IsColorLock = true;
										UserConfig.Instance.ColorLockList.Add(menuInfo2.FileName.ToLower());
									}
									UserConfig.Instance.Save();
								}
							}
							GUIStyle guistyle9 = guistyle2;
							if (menuInfo2.IsFavorite)
							{
								guistyle9 = guistyle3;
							}
							if (GUI.Button(rect4, new GUIContent("★", text2), guistyle9))
							{
								if (menuInfo2.IsFavorite)
								{
									menuInfo2.IsFavorite = false;
									UserConfig.Instance.FavList.Remove(menuInfo2.FileName.ToLower());
								}
								else
								{
									menuInfo2.IsFavorite = true;
									UserConfig.Instance.FavList.Add(menuInfo2.FileName.ToLower());
								}
								UserConfig.Instance.Save();
							}
							GUI.enabled = enabled;
							if (GUI.Button(rect3, new GUIContent(menuInfo2.Icon, text2)))
							{
								this._selectedItem = menuInfo2;
								this._selectedVariationItem = menuInfo2.VariationMenuList[0];
								List<Maid> visibleMaidList3 = CommonUtil.GetVisibleMaidList();
								if (this._selectedMaid >= 0 && visibleMaidList3.Count - 1 >= this._selectedMaid)
								{
									if (UserConfig.Instance.IsOutputInfoLog)
									{
										Console.WriteLine("PropMyItem：change item = " + menuInfo2.FileName);
									}
									visibleMaidList3[this._selectedMaid].SetProp(menuInfo2.MPN, menuInfo2.FileName, Path.GetFileName(menuInfo2.FileName).GetHashCode(), false, false);
									if ((menuInfo2.MPN == MPN.accashi || menuInfo2.MPN == MPN.accsenaka || menuInfo2.MPN == MPN.accanl || menuInfo2.MPN == MPN.accshippo || menuInfo2.MPN == MPN.haircolor) && menuInfo2.ColorSetMenuList.Count > 0)
									{
										MenuInfo menuInfo6 = this._selectedVariationItem.ColorSetMenuList[0];
										visibleMaidList3[this._selectedMaid].SetProp(menuInfo2.ColorSetMPN, menuInfo6.FileName, Path.GetFileName(menuInfo6.FileName).GetHashCode(), false, false);
									}
									visibleMaidList3[this._selectedMaid].AllProcProp();
								}
							}
							GUI.enabled = true;
						}
						int count = menuInfo2.VariationMenuList.Count;
						if (count > 1)
						{
							Rect rect7 = new Rect(rect3.x + rect3.width - num, rect3.y + num3, 10f, 10f);
							if (menuInfo2.MPN == MPN.acckubi || menuInfo2.MPN == MPN.acckubiwa || menuInfo2.MPN == MPN.accheso)
							{
								rect7.Set(rect3.x + rect3.width - num2, rect3.y + num3, 10f, 10f);
							}
							GUI.Label(rect7, count.ToString(), guistyle);
						}
					}
					num13++;
				}
				IL_D69:;
			}
			if (this._folders[this._selectedFolder].Name == "選択中")
			{
				float num16 = num7 * (float)((int)((float)num13 / num4));
				num16 = (((float)num13 % num4 == 0f) ? num16 : (num16 + num7));
				Rect rect8 = new Rect(0f, num16, num6 * 2f, num7);
				Rect rect9 = new Rect(num6 * 3f, num16, num6 * 2f, num7);
				MPN[] array = new MPN[]
				{
					MPN.accmimi,
					MPN.chikubicolor,
					MPN.hokuro,
					MPN.mayu,
					MPN.accnip,
					MPN.lip,
					MPN.eye,
					MPN.eye_hi,
					MPN.eye_hi_r,
					MPN.chikubi,
					MPN.futae,
					MPN.acchana,
					MPN.nose,
					MPN.matsuge_up,
					MPN.wear,
					MPN.eyewhite,
					MPN.mizugi,
					MPN.bra,
					MPN.matsuge_low,
					MPN.skirt,
					MPN.stkg,
					MPN.panz,
					MPN.shoes,
					MPN.headset,
					MPN.glove,
					MPN.acckamisub
				};
				if (GUI.Button(rect8, "カラバリ変更(前)", GuiStyles.ButtonStyle) && maid != null)
				{
					foreach (MPN mpn in array)
					{
						MaidProp prop = maid.GetProp(mpn);
						string text3 = prop.strFileName.ToLower();
						string basename = prop.strFileName.ToLower();
						if (Regex.IsMatch(text3, "_z\\d{1,4}"))
						{
							Match match = Regex.Match(text3, "_z\\d{1,4}");
							basename = text3.Replace(match.Value, "");
						}
						this.nextPattern(maid, mpn, basename, text3, true);
					}
				}
				if (GUI.Button(rect9, "カラバリ変更(後)", GuiStyles.ButtonStyle) && maid != null)
				{
					foreach (MPN mpn2 in array)
					{
						try
						{
							MaidProp prop2 = maid.GetProp(mpn2);
							string text4 = prop2.strFileName.ToLower();
							string basename2 = prop2.strFileName.ToLower();
							if (Regex.IsMatch(text4, "_z\\d{1,4}"))
							{
								Match match2 = Regex.Match(text4, "_z\\d{1,4}");
								basename2 = text4.Replace(match2.Value, "");
							}
							this.nextPattern(maid, mpn2, basename2, text4, false);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.ToString());
						}
					}
				}
			}
			GUI.EndScrollView();
			GuiStyles.LabelStyle.alignment = TextAnchor.UpperLeft;
			Rect rect10 = new Rect(xPos, yPos, num6 * num4 + GuiStyles.ScrollWidth, GuiStyles.ControlHeight);
			xPos += num5 + GuiStyles.ScrollWidth + 8f;
			GUI.Label(rect10, GUI.tooltip, GuiStyles.LabelStyle);
			GuiStyles.LabelStyle.alignment = TextAnchor.MiddleCenter;
			if (this._selectedItem != null && this._selectedItem.VariationMenuList.Count > 1)
			{
				this.guiSelectedVariation(ref xPos, yPos, this._selectedItem, num6, num7, windowHeight, text);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000067EC File Offset: 0x000049EC
		private void guiSelectedVariation(ref float posX, float posY, MenuInfo itemMenuInfo, float iconWidth, float iconHeight, float windowHeight, string selectedFileName)
		{
			int count = itemMenuInfo.VariationMenuList.Count;
			Rect rect = new Rect(0f, 0f, iconWidth, (float)count * (iconWidth + 4f));
			Rect rect2 = new Rect(posX, posY + GuiStyles.ControlHeight, rect.width + GuiStyles.ScrollWidth, windowHeight - posY - (float)GuiStyles.FontSize - GuiStyles.ControlHeight);
			this._colorItemScrollPosition = GUI.BeginScrollView(rect2, this._colorItemScrollPosition, rect);
			new Rect(0f, 0f, iconWidth, iconWidth);
			int i = 0;
			while (i < count)
			{
				MenuInfo menuInfo = itemMenuInfo.VariationMenuList[i];
				if (menuInfo.Icon == null && !string.IsNullOrEmpty(menuInfo.IconName) && !menuInfo.IsError)
				{
					if (!menuInfo.IsOfficialMOD)
					{
						try
						{
							menuInfo.Icon = ImportCM.CreateTexture(menuInfo.IconName);
							goto IL_103;
						}
						catch (Exception)
						{
							menuInfo.IsError = true;
							goto IL_24F;
						}
					}
					MenuInfo menuInfo2 = MenuModParser.parseMod(menuInfo.FilePath);
					menuInfo.Icon = menuInfo2.Icon;
					goto IL_103;
				}
				goto IL_103;
				IL_24F:
				i++;
				continue;
				IL_103:
				string text = menuInfo.ItemName;
				if (this._folders[this._selectedFolder].Name == "全て" || this._folders[this._selectedFolder].Name == "選択中")
				{
					text = menuInfo.CategoryName + "：" + menuInfo.ItemName;
				}
				if (!string.IsNullOrEmpty(selectedFileName) && menuInfo.FileName.IndexOf(selectedFileName, StringComparison.OrdinalIgnoreCase) == 0)
				{
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect(0f, (iconWidth + 4f) * (float)i, iconWidth, iconWidth), new GUIContent(menuInfo.Icon, text)))
				{
					this._selectedVariationItem = menuInfo;
					List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
					if (this._selectedMaid >= 0 && visibleMaidList.Count - 1 >= this._selectedMaid)
					{
						visibleMaidList[this._selectedMaid].SetProp(menuInfo.MPN, menuInfo.FileName, Path.GetFileName(menuInfo.FileName).GetHashCode(), false, false);
						visibleMaidList[this._selectedMaid].AllProcProp();
						if (UserConfig.Instance.IsOutputInfoLog)
						{
							Console.WriteLine("PropMyItem：change item = " + menuInfo.FileName);
						}
					}
				}
				GUI.enabled = true;
				goto IL_24F;
			}
			GUI.EndScrollView();
			posX += iconWidth + GuiStyles.ScrollWidth + 8f;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006A80 File Offset: 0x00004C80
		private void guiSelectedColorSet(ref float posX, ref float posY)
		{
			if (this._selectedVariationItem != null && this._selectedVariationItem.ColorSetMenuList.Count > 0)
			{
				string value = string.Empty;
				List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
				if (this._selectedMaid >= 0 && visibleMaidList.Count - 1 >= this._selectedMaid)
				{
					Maid maid = visibleMaidList[this._selectedMaid];
					value = CommonUtil.GetSelectedMenuFileName(new MPN?(this._selectedVariationItem.ColorSetMPN), maid);
				}
				float num = (float)(420 / this._selectedVariationItem.ColorSetMenuList.Count);
				num = ((num > 28f) ? 28f : num);
				int i = 0;
				while (i < this._selectedVariationItem.ColorSetMenuList.Count)
				{
					MenuInfo menuInfo = this._selectedVariationItem.ColorSetMenuList[i];
					if (menuInfo.Icon == null && !string.IsNullOrEmpty(menuInfo.IconName) && !menuInfo.IsError)
					{
						if (!menuInfo.IsOfficialMOD)
						{
							try
							{
								menuInfo.Icon = ImportCM.CreateTexture(menuInfo.IconName);
								goto IL_11F;
							}
							catch (Exception)
							{
								menuInfo.IsError = true;
								goto IL_221;
							}
						}
						MenuInfo menuInfo2 = MenuModParser.parseMod(menuInfo.FilePath);
						menuInfo.Icon = menuInfo2.Icon;
						goto IL_11F;
					}
					goto IL_11F;
					IL_221:
					i++;
					continue;
					IL_11F:
					if (!string.IsNullOrEmpty(value) && menuInfo.FileName.IndexOf(value, StringComparison.OrdinalIgnoreCase) == 0)
					{
						if (menuInfo.FileName.IndexOf("mugen", StringComparison.OrdinalIgnoreCase) != -1)
						{
							this._isFreeColor = true;
						}
						else
						{
							this._isFreeColor = false;
						}
						GUI.enabled = false;
					}
					if (GUI.Button(new Rect(posX, posY + 10f + (num + 1f) * (float)i, num, num), menuInfo.Icon))
					{
						if (menuInfo.FileName.IndexOf("mugen", StringComparison.OrdinalIgnoreCase) != -1)
						{
							this._isFreeColor = true;
						}
						else
						{
							this._isFreeColor = false;
						}
						List<Maid> visibleMaidList2 = CommonUtil.GetVisibleMaidList();
						if (this._selectedMaid >= 0 && visibleMaidList2.Count - 1 >= this._selectedMaid)
						{
							visibleMaidList2[this._selectedMaid].SetProp(menuInfo.MPN, menuInfo.FileName, Path.GetFileName(menuInfo.FileName).GetHashCode(), false, false);
							visibleMaidList2[this._selectedMaid].AllProcProp();
						}
					}
					GUI.enabled = true;
					goto IL_221;
				}
				posX += num + 8f;
				return;
			}
			this._isFreeColor = false;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00006CF0 File Offset: 0x00004EF0
		private void guiSelectedMugenColor(ref float posX, ref float posY)
		{
			if (this._isFreeColor)
			{
				int fontSize = GuiStyles.FontSize;
				float controlHeight = GuiStyles.ControlHeight;
				GUIStyle buttonStyle = GuiStyles.ButtonStyle;
				GUIStyle labelStyle = GuiStyles.LabelStyle;
				List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
				if (this._selectedMaid >= 0 && visibleMaidList.Count - 1 >= this._selectedMaid)
				{
					float num = posY;
					Maid maid = visibleMaidList[this._selectedMaid];
					MaidParts.PARTS_COLOR parts_COLOR = MaidParts.PARTS_COLOR.SKIN;
					MPN mpn = this._selectedItem.MPN;
					switch (mpn)
					{
					case MPN.MabutaUpIn:
					case MPN.MabutaUpIn2:
					case MPN.MabutaUpMiddle:
					case MPN.MabutaUpOut:
					case MPN.MabutaUpOut2:
					case MPN.MabutaLowIn:
						parts_COLOR = MaidParts.PARTS_COLOR.HAIR;
						goto IL_187;
					case MPN.MabutaLowUpMiddle:
						break;
					case MPN.MabutaLowUpOut:
					case MPN.body:
					case MPN.head:
					case MPN.hairr:
					case MPN.hairs:
					case MPN.hairaho:
						goto IL_187;
					case MPN.moza:
						goto IL_EE;
					case MPN.hairf:
						goto IL_FE;
					case MPN.hairt:
						goto IL_106;
					case MPN.haircolor:
					case MPN.skin:
						parts_COLOR = MaidParts.PARTS_COLOR.NIPPLE;
						goto IL_187;
					default:
						switch (mpn)
						{
						case MPN.accashi:
							goto IL_106;
						case MPN.accsenaka:
							goto IL_FE;
						case MPN.accshippo:
							goto IL_EE;
						case MPN.accanl:
							break;
						default:
							goto IL_187;
						}
						break;
					}
					parts_COLOR = MaidParts.PARTS_COLOR.SKIN;
					goto IL_187;
					IL_EE:
					parts_COLOR = MaidParts.PARTS_COLOR.UNDER_HAIR;
					goto IL_187;
					IL_FE:
					parts_COLOR = MaidParts.PARTS_COLOR.EYE_BROW;
					goto IL_187;
					IL_106:
					string text = string.Empty;
					if (this._selectedEyeClorType == 0)
					{
						parts_COLOR = MaidParts.PARTS_COLOR.EYE_L;
						text = "両目";
					}
					else if (this._selectedEyeClorType == 1)
					{
						parts_COLOR = MaidParts.PARTS_COLOR.EYE_L;
						text = "左目";
					}
					else if (this._selectedEyeClorType == 2)
					{
						parts_COLOR = MaidParts.PARTS_COLOR.EYE_R;
						text = "右目";
					}
					if (GUI.Button(new Rect(posX, posY, (float)(fontSize * 8), controlHeight), text, buttonStyle))
					{
						this._selectedEyeClorType = ((this._selectedEyeClorType == 2) ? 0 : (this._selectedEyeClorType + 1));
					}
					num = controlHeight + 8f + posY;
					IL_187:
					MaidParts.PartsColor partsColor = maid.Parts.GetPartsColor(parts_COLOR);
					string[] array = new string[]
					{
						"色相\u3000",
						"彩度\u3000",
						"明度\u3000",
						"対称\u3000",
						"影率\u3000",
						"影色 色相",
						"影色 彩度",
						"影色 明度",
						"影色 対称"
					};
					int[] array2 = new int[]
					{
						partsColor.m_nMainHue,
						partsColor.m_nMainChroma,
						partsColor.m_nMainBrightness,
						partsColor.m_nMainContrast,
						partsColor.m_nShadowRate,
						partsColor.m_nShadowHue,
						partsColor.m_nShadowChroma,
						partsColor.m_nShadowBrightness,
						partsColor.m_nShadowContrast
					};
					int[] array3 = new int[]
					{
						255,
						255,
						510,
						200,
						255,
						255,
						255,
						510,
						200
					};
					float num2 = controlHeight * 0.8f;
					for (int i = 0; i < array.Length; i++)
					{
						float num3 = num + (float)i * (num2 * 2f + 8f);
						Rect rect = new Rect(posX, num3, (float)(fontSize * array[i].Length), num2);
						Rect rect2 = new Rect(posX + (float)(fontSize * array[i].Length + 4), num3, (float)(fontSize * 4), num2);
						Rect rect3 = new Rect(posX, num3 + num2, (float)(fontSize * 2), num2);
						Rect rect4 = new Rect(posX + (float)(fontSize * 2) + 4f, num3 + num2 + (float)((double)num2 * 0.25), 80f, num2);
						Rect rect5 = new Rect(posX + 80f + (float)(fontSize * 2) + 8f, num3 + num2, (float)(fontSize * 2), num2);
						GUI.Label(rect, array[i], labelStyle);
						GUI.Label(rect2, array2[i].ToString(), labelStyle);
						float num4 = (float)((int)GUI.HorizontalSlider(rect4, (float)array2[i], 0f, (float)array3[i]));
						if (num4 != (float)array2[i])
						{
							array2[i] = (int)num4;
							this.changeColor(partsColor, parts_COLOR, array2, maid);
						}
						if (GUI.Button(rect3, "-", buttonStyle))
						{
							int num5 = array2[i] - 1;
							num5 = ((num5 < 0) ? 0 : num5);
							array2[i] = num5;
							this.changeColor(partsColor, parts_COLOR, array2, maid);
						}
						if (GUI.Button(rect5, "+", buttonStyle))
						{
							int num6 = array2[i] + 1;
							num6 = ((num6 > array3[i]) ? array3[i] : num6);
							array2[i] = num6;
							this.changeColor(partsColor, parts_COLOR, array2, maid);
						}
					}
					posX += (float)(80 + fontSize * 2 + 8 + fontSize * 2 + 8);
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00007120 File Offset: 0x00005320
		private void changeColor(MaidParts.PartsColor partsColor, MaidParts.PARTS_COLOR partsColorType, int[] values, Maid maid)
		{
			partsColor.m_nMainHue = values[0];
			partsColor.m_nMainChroma = values[1];
			partsColor.m_nMainBrightness = values[2];
			partsColor.m_nMainContrast = values[3];
			partsColor.m_nShadowRate = values[4];
			partsColor.m_nShadowHue = values[5];
			partsColor.m_nShadowChroma = values[6];
			partsColor.m_nShadowBrightness = values[7];
			partsColor.m_nShadowContrast = values[8];
			maid.Parts.SetPartsColor(partsColorType, partsColor);
			if (partsColorType == MaidParts.PARTS_COLOR.EYE_L && this._selectedEyeClorType == 0)
			{
				partsColor.m_nMainHue = values[0];
				partsColor.m_nMainChroma = values[1];
				partsColor.m_nMainBrightness = values[2];
				partsColor.m_nMainContrast = values[3];
				partsColor.m_nShadowRate = values[4];
				partsColor.m_nShadowHue = values[5];
				partsColor.m_nShadowChroma = values[6];
				partsColor.m_nShadowBrightness = values[7];
				partsColor.m_nShadowContrast = values[8];
				maid.Parts.SetPartsColor(MaidParts.PARTS_COLOR.EYE_R, partsColor);
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007208 File Offset: 0x00005408
		public void LoadMenuFiles(bool isInit = false)
		{
			try
			{
				List<SMenuInfo> menuItems = new List<SMenuInfo>();
				Dictionary<string, MenuInfo> dictionary = new Dictionary<string, MenuInfo>();
				if (!isInit)
				{
					using (List<SMenuInfo>.Enumerator enumerator = Config.Instance.MenuItems.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							SMenuInfo smenuInfo = enumerator.Current;
							if (!dictionary.ContainsKey(smenuInfo.FileName))
							{
								dictionary.Add(smenuInfo.FileName, new MenuInfo(smenuInfo));
							}
						}
						goto IL_CA;
					}
				}
				this._mpnMenuListDictionary = new Dictionary<MPN, List<MenuInfo>>();
				foreach (object obj in Enum.GetValues(typeof(MPN)))
				{
					MPN key = (MPN)obj;
					this._mpnMenuListDictionary.Add(key, new List<MenuInfo>());
				}
				IL_CA:
				if (dictionary.Count == 0)
				{
					Console.Write("PropMyItem：準備中...");
				}
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
				foreach (string text in UserConfig.Instance.FavList)
				{
					if (!dictionary2.ContainsKey(text))
					{
						dictionary2.Add(text.ToLower(), text);
					}
				}
				Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
				foreach (string text2 in UserConfig.Instance.ColorLockList)
				{
					if (!dictionary3.ContainsKey(text2))
					{
						dictionary3.Add(text2.ToLower(), text2);
					}
				}
				List<MenuInfo> list = new List<MenuInfo>();
				this.GetMainMenuFiles(ref list, dictionary, dictionary2, dictionary3, ref menuItems);
				this.GetModFiles(ref list, dictionary, dictionary2, dictionary3, ref menuItems);
				this.SetVariationMenu(dictionary2, dictionary3, ref list);
				this.sort(false, true);
				this.setColorSet();
				Config.Instance.MenuItems = menuItems;
				Config.Instance.Save();
				if (dictionary.Count == 0)
				{
					Console.WriteLine("PropMyItem：完了");
				}
				this._selectedFolder = 0;
				this._selectedMPN = MPN.null_mpn;
				this._selectedCategory = -1;
				this._selectedItem = null;
				this._selectedVariationItem = null;
				this._selectedPresetList.Clear();
				this._selectedItem = null;
				this._selectedVariationItem = null;
				this._scrollPosition.y = 0f;
				MPN selectedMPN = MPN.Yorime;
				if (this._categoryMPNDic.TryGetValue(this._folders[this._selectedFolder].Categories[0], out selectedMPN))
				{
					this._selectedMPN = selectedMPN;
				}
				this._selectedCategory = 0;
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00007504 File Offset: 0x00005704
		private void sort(bool isFilePath, bool isColorNumber)
		{

			foreach (MPN key in this._mpnMenuListDictionary.Keys)
			{
				List<MenuInfo> list = this._mpnMenuListDictionary[key];
				Comparison<MenuInfo> comparison;

					comparison  = delegate(MenuInfo a, MenuInfo b)
					{
						if (isFilePath)
						{
							if (a.IsMod && !b.IsMod)
							{
								return 1;
							}
							if (!a.IsMod && b.IsMod)
							{
								return -1;
							}
							if (a.IsMod && b.IsMod)
							{
								return string.Compare(a.FilePath, b.FilePath);
							}
						}
						if ((int)a.Priority != (int)b.Priority)
						{
							return (int)a.Priority - (int)b.Priority;
						}
						return string.Compare(a.ItemName, b.ItemName);
					};

				list.Sort(comparison);
				if (isColorNumber)
				{
					foreach (MenuInfo menuInfo in this._mpnMenuListDictionary[key])
					{
						if (menuInfo.VariationMenuList.Count > 1)
						{
							menuInfo.VariationMenuList.Sort(delegate(MenuInfo a, MenuInfo b)
							{
								if (a.ColorNumber != b.ColorNumber)
								{
									return a.ColorNumber - b.ColorNumber;
								}
								return string.Compare(a.FileName, b.FileName);
							});
						}
					}
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00007618 File Offset: 0x00005818
		private void GetMainMenuFiles(ref List<MenuInfo> variationMenuList, Dictionary<string, MenuInfo> loadItems, Dictionary<string, string> favDic, Dictionary<string, string> colorLockDic, ref List<SMenuInfo> saveItems)
		{
			ReadOnlyDictionary<string, bool> havePartsItems = GameMain.Instance.CharacterMgr.status.havePartsItems;
			string[] menuFiles = GameUty.MenuFiles;
			this._menuList.Clear();
			string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.menu", SearchOption.AllDirectories);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (string text in files)
			{
				string key = Path.GetFileName(text).ToLower();
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, text);
				}
			}
			List<string> list = new List<string>();
			foreach (string text2 in menuFiles)
			{
				try
				{
					if (text2.IndexOf("_i_man_") != 0 && text2.IndexOf("mbody") != 0 && text2.IndexOf("mhead") != 0)
					{
						if (!(Path.GetExtension(text2) != ".menu"))
						{
							string fileName = Path.GetFileName(text2);
							this._menuList.Add(fileName.ToLower());
							if (fileName.Contains("cv_pattern"))
							{
								this._myPatternList.Add(fileName.ToLower());
							}
							if (!list.Contains(fileName))
							{
								MenuInfo menuInfo = null;
								if (!loadItems.TryGetValue(fileName, out menuInfo))
								{
									menuInfo = MenuModParser.ParseMenu(text2);
								}
								if (menuInfo != null && menuInfo.MPN != MPN.null_mpn)
								{
									menuInfo.FileName = fileName;
									if (havePartsItems.ContainsKey(fileName))
									{
										menuInfo.IsShopTarget = true;
									}
									else
									{
										menuInfo.IsShopTarget = false;
									}
									string filePath = text2;
									if (dictionary.TryGetValue(fileName, out filePath))
									{
										menuInfo.IsMod = true;
										menuInfo.FilePath = filePath;
									}
									else
									{
										menuInfo.IsMod = false;
										menuInfo.FilePath = fileName;
									}
									string empty = string.Empty;
									if (this._menuMPNCategoryDic.TryGetValue(menuInfo.MPN, out empty))
									{
										menuInfo.CategoryName = empty;
									}
									list.Add(fileName);
									if (!string.IsNullOrEmpty(menuInfo.IconName))
									{
										if (Regex.IsMatch(text2, "_z\\d{1,4}") || text2.Contains("_zurashi") || text2.Contains("_mekure") || text2.Contains("_porori") || text2.Contains("_back"))
										{
											variationMenuList.Add(menuInfo);
										}
										else
										{
											if (favDic.ContainsKey(menuInfo.FileName))
											{
												menuInfo.IsFavorite = true;
											}
											if (colorLockDic.ContainsKey(menuInfo.FileName))
											{
												menuInfo.IsColorLock = true;
											}
											menuInfo.ColorNumber = 0;
											menuInfo.VariationMenuList.Add(menuInfo);
											this._mpnMenuListDictionary[menuInfo.MPN].Add(menuInfo);
										}
									}
									saveItems.Add(new SMenuInfo(menuInfo));
								}
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000078FC File Offset: 0x00005AFC
		private void GetModFiles(ref List<MenuInfo> variationMenuList, Dictionary<string, MenuInfo> loadItems, Dictionary<string, string> favDic, Dictionary<string, string> colorLockDic, ref List<SMenuInfo> saveItems)
		{
			List<string> list = new List<string>();
			string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.mod", SearchOption.AllDirectories);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				if (!dictionary.ContainsKey(fileName))
				{
					list.Add(text);
					dictionary.Add(fileName, text);
				}
			}
			foreach (string text2 in list)
			{
				try
				{
					if (Path.GetExtension(text2) == ".mod")
					{
						MenuInfo menuInfo = null;
						string fileName2 = Path.GetFileName(text2);
						if (!loadItems.TryGetValue(fileName2, out menuInfo))
						{
							menuInfo = MenuModParser.parseMod(text2);
						}
						menuInfo.FileName = fileName2;
						menuInfo.IsShopTarget = false;
						menuInfo.IsMod = true;
						menuInfo.IsOfficialMOD = true;
						menuInfo.FilePath = text2;
						string empty = string.Empty;
						if (this._menuMPNCategoryDic.TryGetValue(menuInfo.MPN, out empty))
						{
							menuInfo.CategoryName = empty;
						}
						string text3 = fileName2.ToLower();
						if (Regex.IsMatch(text3, "_z\\d{1,4}") || text3.Contains("_porori") || text3.Contains("_zurashi") || text3.Contains("_mekure") || text3.Contains("_back"))
						{
							variationMenuList.Add(menuInfo);
						}
						else
						{
							if (favDic.ContainsKey(menuInfo.FileName.ToLower()))
							{
								menuInfo.IsFavorite = true;
							}
							if (colorLockDic.ContainsKey(menuInfo.FileName.ToLower()))
							{
								menuInfo.IsColorLock = true;
							}
							menuInfo.ColorNumber = 0;
							menuInfo.VariationMenuList.Add(menuInfo);
							this._mpnMenuListDictionary[menuInfo.MPN].Add(menuInfo);
						}
						saveItems.Add(new SMenuInfo(menuInfo));
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.StackTrace);
				}
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00007B2C File Offset: 0x00005D2C
		private void SetVariationMenu(Dictionary<string, string> favDic, Dictionary<string, string> colorLockDic, ref List<MenuInfo> variationMenuList)
		{
			List<MenuInfo> list = new List<MenuInfo>();
			List<MenuInfo> list2 = new List<MenuInfo>();
			foreach (MenuInfo menuInfo in variationMenuList)
			{
				string fileName = Path.GetFileName(menuInfo.FileName.ToLower());
				int colorNumber = 0;
				string[] array = Regex.Split(fileName, "_z\\d{1,4}");
				if (array.Length > 1)
				{
					int.TryParse(array[1].Remove(0, 3).Split(new char[]
					{
						'.',
						'_'
					})[0], out colorNumber);
				}
				menuInfo.ColorNumber = colorNumber;
				string text = Regex.Replace(fileName, "_z\\d{1,4}", "");
				text = Regex.Replace(text, "_zurashi\\d{0,4}", "");
				text = Regex.Replace(text, "_mekure\\d{0,4}", "");
				text = Regex.Replace(text, "_porori\\d{0,4}", "");
				text = Regex.Replace(text, "_back\\d{0,4}", "");
				text = text.Replace("_i.", "_i_.");
				if (this._mpnMenuListDictionary.TryGetValue(menuInfo.MPN, out list))
				{
					bool flag = false;
					foreach (MenuInfo menuInfo2 in list)
					{
						if (menuInfo2.FileName.IndexOf(text, StringComparison.OrdinalIgnoreCase) == 0)
						{
							flag = true;
							menuInfo2.VariationMenuList.Add(menuInfo);
							break;
						}
					}
					if (!flag)
					{
						if (favDic.ContainsKey(menuInfo.FileName.ToLower()))
						{
							menuInfo.IsFavorite = true;
						}
						if (colorLockDic.ContainsKey(menuInfo.FileName.ToLower()))
						{
							menuInfo.IsColorLock = true;
						}
						menuInfo.ColorNumber = 0;
						menuInfo.VariationMenuList.Add(menuInfo);
						list2.Add(menuInfo);
					}
				}
			}
			foreach (MenuInfo menuInfo3 in list2)
			{
				this._mpnMenuListDictionary[menuInfo3.MPN].Add(menuInfo3);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00007D90 File Offset: 0x00005F90
		private void setColorSet()
		{
			foreach (MPN key in this._mpnMenuListDictionary.Keys)
			{
				foreach (MenuInfo menuInfo in this._mpnMenuListDictionary[key])
				{
					List<MenuInfo> list = new List<MenuInfo>();
					list.AddRange(menuInfo.VariationMenuList);
					foreach (MenuInfo menuInfo2 in list)
					{
						if (!string.IsNullOrEmpty(menuInfo2.ColorSetMenuName))
						{
							List<MenuInfo> list2 = new List<MenuInfo>();
							List<MenuInfo> list3 = new List<MenuInfo>();
							if (this._mpnMenuListDictionary.TryGetValue(menuInfo2.ColorSetMPN, out list3))
							{
								string pattern = Regex.Replace(menuInfo2.ColorSetMenuName, ".", new MatchEvaluator(CommonUtil.WildCardMatchEvaluator));
								foreach (MenuInfo menuInfo3 in list3)
								{
									if (Regex.IsMatch(menuInfo3.FileName, pattern, RegexOptions.IgnoreCase))
									{
										list2.Add(menuInfo3);
									}
								}
							}
							menuInfo2.ColorSetMenuList.AddRange(list2);
						}
					}
				}
			}
		}

		// Token: 0x0400003D RID: 61
		private int _sceneLevel;

		// Token: 0x0400003E RID: 62
		private Rect _windowRect;

		// Token: 0x0400003F RID: 63
		private AutoShoesHide _autoShoesHide = new AutoShoesHide();

		// Token: 0x04000040 RID: 64
		private bool _isMinimum;

		// Token: 0x04000041 RID: 65
		private bool _isVisible;

		// Token: 0x04000042 RID: 66
		private bool _isPluginKeyChange;

		// Token: 0x04000043 RID: 67
		private bool _isShowSetting;

		// Token: 0x04000044 RID: 68
		private bool _isShowFilterSetting;

		// Token: 0x04000045 RID: 69
		private string _selectedFilterText = string.Empty;

		// Token: 0x04000046 RID: 70
		private Vector2 _scrollFilterPosition;

		// Token: 0x04000047 RID: 71
		private Vector2 _categoryScrollPosition;

		// Token: 0x04000048 RID: 72
		private Vector2 _scrollPosition;

		// Token: 0x04000049 RID: 73
		private Vector2 _colorItemScrollPosition;

		// Token: 0x0400004A RID: 74
		private List<PropMyItem.FolderMenu> _folders = new List<PropMyItem.FolderMenu>();

		// Token: 0x0400004B RID: 75
		private int _selectedMaid;

		// Token: 0x0400004C RID: 76
		private int _selectedFolder;

		// Token: 0x0400004D RID: 77
		private MPN _selectedMPN;

		// Token: 0x0400004E RID: 78
		private int _selectedCategory = -1;

		// Token: 0x0400004F RID: 79
		private MenuInfo _selectedItem;

		// Token: 0x04000050 RID: 80
		private MenuInfo _selectedVariationItem;

		// Token: 0x04000051 RID: 81
		private Dictionary<string, MPN> _categoryMPNDic = new Dictionary<string, MPN>();

		// Token: 0x04000052 RID: 82
		private Dictionary<MPN, string> _menuMPNCategoryDic = new Dictionary<MPN, string>();

		// Token: 0x04000053 RID: 83
		private List<CharacterMgr.Preset> _selectedPresetList = new List<CharacterMgr.Preset>();

		// Token: 0x04000054 RID: 84
		private int _selectedFilter;

		// Token: 0x04000055 RID: 85
		private bool _isFavFilter;

		// Token: 0x04000056 RID: 86
		public Dictionary<MPN, List<MenuInfo>> _mpnMenuListDictionary = new Dictionary<MPN, List<MenuInfo>>();

		// Token: 0x04000057 RID: 87
		private int _selectedEyeClorType;

		// Token: 0x04000058 RID: 88
		private bool _isFreeColor;

		// Token: 0x04000059 RID: 89
		private bool _isForcedInit;

		// Token: 0x0400005A RID: 90
		private bool _isStartUpLoadead;

		// Token: 0x0400005B RID: 91
		private Dictionary<MPN, string> presetRestoreDic_ = new Dictionary<MPN, string>();

		// Token: 0x0400005C RID: 92
		private List<string> _menuList = new List<string>();

		// Token: 0x0400005D RID: 93
		private int _savePresetState;

		// Token: 0x0400005E RID: 94
		private CharacterMgr.PresetType _targetSavePreset = CharacterMgr.PresetType.All;

		// Token: 0x0400005F RID: 95
		private CharacterMgr.PresetType _selectedPresetType = CharacterMgr.PresetType.All;

		// Token: 0x04000060 RID: 96
		private SavePreset _savepreset = new SavePreset();

		// Token: 0x04000061 RID: 97
		private List<string> _myPatternList = new List<string>();

		// Token: 0x0200000E RID: 14
		private class FolderMenu
		{
			// Token: 0x06000064 RID: 100 RVA: 0x00002275 File Offset: 0x00000475
			public FolderMenu(string name, string[] categories)
			{
				this.Name = name;
				this.Categories = categories;
			}

			// Token: 0x04000062 RID: 98
			public string Name = string.Empty;

			// Token: 0x04000063 RID: 99
			public string[] Categories;
		}
	}
}
