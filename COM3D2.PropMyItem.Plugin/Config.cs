using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x0200000C RID: 12
	public class Config
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000221C File Offset: 0x0000041C
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002213 File Offset: 0x00000413
		public List<string> TargetBGList
		{
			get
			{
				return this._targetBGList;
			}
			set
			{
				this._targetBGList = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000222D File Offset: 0x0000042D
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002224 File Offset: 0x00000424
		public List<SMenuInfo> MenuItems
		{
			get
			{
				return this._menuItems;
			}
			set
			{
				this._menuItems = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000335C File Offset: 0x0000155C
		public static Config Instance
		{
			get
			{
				if (Config._config == null)
				{
					string text = Directory.GetCurrentDirectory() + "\\Sybaris\\UnityInjector\\Config\\PropMyItem.xml";
					Config._config = new Config();
					Config._config.SetDefault();
					if (File.Exists(text))
					{
						Config._config.Load(text);
					}
					else
					{
						Config._config.Save();
					}
				}
				return Config._config;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000033B8 File Offset: 0x000015B8
		public void Load(string filePath)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
				using (StreamReader streamReader = new StreamReader(filePath, new UTF8Encoding(false)))
				{
					Config config = (Config)xmlSerializer.Deserialize(streamReader);
					this.TargetBGList.Clear();
					this.TargetBGList.AddRange(config.TargetBGList.ToArray());
					this.MenuItems = config.MenuItems;
				}
			}
			catch (Exception)
			{
				this.SetDefault();
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003450 File Offset: 0x00001650
		public void SetDefault()
		{
			try
			{
				string[] collection = new string[]
				{
					"MyRoom",
					"MyRoom_Night",
					"Shukuhakubeya_BedRoom",
					"Shukuhakubeya_BedRoom_Night",
					"Soap",
					"SMClub",
					"HeroineRoom_A1",
					"HeroineRoom_A1_night",
					"HeroineRoom_B1",
					"HeroineRoom_B1_night",
					"HeroineRoom_C1",
					"HeroineRoom_C1_night",
					"HeroineRoom_A",
					"HeroineRoom_A_night",
					"HeroineRoom_B",
					"HeroineRoom_B_night",
					"HeroineRoom_C",
					"HeroineRoom_C_night"
				};
				this.TargetBGList.AddRange(collection);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003520 File Offset: 0x00001720
		public void Save()
		{
			string filePath = Directory.GetCurrentDirectory() + "\\Sybaris\\UnityInjector\\Config\\PropMyItem.xml";
			this.Save(filePath);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003544 File Offset: 0x00001744
		public void Save(string filePath)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
				StreamWriter streamWriter = new StreamWriter(filePath, false, new UTF8Encoding(false));
				xmlSerializer.Serialize(streamWriter, this);
				streamWriter.Close();
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}

		// Token: 0x0400003A RID: 58
		private List<string> _targetBGList = new List<string>();

		// Token: 0x0400003B RID: 59
		private List<SMenuInfo> _menuItems = new List<SMenuInfo>();

		// Token: 0x0400003C RID: 60
		private static Config _config;
	}
}
