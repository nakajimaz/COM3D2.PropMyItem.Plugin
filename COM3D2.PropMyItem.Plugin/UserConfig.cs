using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x0200000B RID: 11
	public class UserConfig
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000214D File Offset: 0x0000034D
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002144 File Offset: 0x00000344
		public string GuiVisibleKey
		{
			get
			{
				return this._guiVisible;
			}
			set
			{
				this._guiVisible = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000215E File Offset: 0x0000035E
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002155 File Offset: 0x00000355
		public bool IsControlKey
		{
			get
			{
				return this._isControlKey;
			}
			set
			{
				this._isControlKey = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000029 RID: 41 RVA: 0x0000216F File Offset: 0x0000036F
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002166 File Offset: 0x00000366
		public bool IsAltKey
		{
			get
			{
				return this._isAltKey;
			}
			set
			{
				this._isAltKey = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002180 File Offset: 0x00000380
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002177 File Offset: 0x00000377
		public bool IsShiftKey
		{
			get
			{
				return this._isShift;
			}
			set
			{
				this._isShift = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002191 File Offset: 0x00000391
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002188 File Offset: 0x00000388
		public bool IsAutoShoesHide
		{
			get
			{
				return this._isAutoShoesHide;
			}
			set
			{
				this._isAutoShoesHide = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000021A2 File Offset: 0x000003A2
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002199 File Offset: 0x00000399
		public bool IsOutputInfoLog
		{
			get
			{
				return this._isOutputInfoLog;
			}
			set
			{
				this._isOutputInfoLog = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000021B3 File Offset: 0x000003B3
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000021AA File Offset: 0x000003AA
		public List<string> FavList
		{
			get
			{
				return this._favList;
			}
			set
			{
				this._favList = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000021C4 File Offset: 0x000003C4
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000021BB File Offset: 0x000003BB
		public List<string> ColorLockList
		{
			get
			{
				return this._colorDisableList;
			}
			set
			{
				this._colorDisableList = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000021CC File Offset: 0x000003CC
		// (set) Token: 0x06000035 RID: 53 RVA: 0x000021D4 File Offset: 0x000003D4
		public List<string> FilterTextList
		{
			get
			{
				return this._filterTextList;
			}
			set
			{
				this._filterTextList = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00003154 File Offset: 0x00001354
		public static UserConfig Instance
		{
			get
			{
				if (UserConfig._config == null)
				{
					string text = Directory.GetCurrentDirectory() + "\\Sybaris\\UnityInjector\\Config\\PropMyItemUser.xml";
					UserConfig._config = new UserConfig();
					if (File.Exists(text))
					{
						UserConfig._config.Load(text);
					}
					else
					{
						UserConfig._config.IsShiftKey = true;
						UserConfig._config.GuiVisibleKey = "i";
						UserConfig._config.Save();
					}
				}
				return UserConfig._config;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000031C0 File Offset: 0x000013C0
		public void Load(string filePath)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserConfig));
				using (StreamReader streamReader = new StreamReader(filePath, new UTF8Encoding(false)))
				{
					UserConfig userConfig = (UserConfig)xmlSerializer.Deserialize(streamReader);
					this.GuiVisibleKey = userConfig.GuiVisibleKey.ToLower();
					this.IsAutoShoesHide = userConfig.IsAutoShoesHide;
					this.IsOutputInfoLog = userConfig.IsOutputInfoLog;
					this.FavList = userConfig.FavList;
					this.ColorLockList = userConfig.ColorLockList;
					this.FilterTextList = userConfig.FilterTextList;
					this.IsControlKey = userConfig.IsControlKey;
					this.IsAltKey = userConfig.IsAltKey;
					this.IsShiftKey = userConfig.IsShiftKey;
				}
			}
			catch (Exception)
			{
			}
			if (string.IsNullOrEmpty(this.GuiVisibleKey))
			{
				this.GuiVisibleKey = "i";
			}
			if (this.FavList == null)
			{
				this.FavList = new List<string>();
			}
			if (this.FilterTextList == null)
			{
				this.FilterTextList = new List<string>();
			}
			if (this.ColorLockList == null)
			{
				this.ColorLockList = new List<string>();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000032E8 File Offset: 0x000014E8
		public void Save()
		{
			string filePath = Directory.GetCurrentDirectory() + "\\Sybaris\\UnityInjector\\Config\\PropMyItemUser.xml";
			this.Save(filePath);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000330C File Offset: 0x0000150C
		public void Save(string filePath)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserConfig));
				StreamWriter streamWriter = new StreamWriter(filePath, false, new UTF8Encoding(false));
				xmlSerializer.Serialize(streamWriter, this);
				streamWriter.Close();
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}

		// Token: 0x0400002F RID: 47
		private const string DefaultGUIKey = "i";

		// Token: 0x04000030 RID: 48
		private string _guiVisible = "i";

		// Token: 0x04000031 RID: 49
		private bool _isControlKey;

		// Token: 0x04000032 RID: 50
		private bool _isAltKey;

		// Token: 0x04000033 RID: 51
		private bool _isShift;

		// Token: 0x04000034 RID: 52
		private bool _isAutoShoesHide;

		// Token: 0x04000035 RID: 53
		private bool _isOutputInfoLog;

		// Token: 0x04000036 RID: 54
		private List<string> _favList = new List<string>();

		// Token: 0x04000037 RID: 55
		private List<string> _colorDisableList = new List<string>();

		// Token: 0x04000038 RID: 56
		private List<string> _filterTextList = new List<string>();

		// Token: 0x04000039 RID: 57
		private static UserConfig _config;
	}
}
