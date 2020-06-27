using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x0200000B RID: 11
	public class Config
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00003243 File Offset: 0x00001443
		// (set) Token: 0x0600003B RID: 59 RVA: 0x0000323A File Offset: 0x0000143A
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
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00003254 File Offset: 0x00001454
		// (set) Token: 0x0600003D RID: 61 RVA: 0x0000324B File Offset: 0x0000144B
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
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000325C File Offset: 0x0000145C
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

		// Token: 0x06000041 RID: 65 RVA: 0x000032D8 File Offset: 0x000014D8
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

		// Token: 0x06000042 RID: 66 RVA: 0x00003370 File Offset: 0x00001570
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

		// Token: 0x06000043 RID: 67 RVA: 0x00003440 File Offset: 0x00001640
		public void Save()
		{
			string filePath = Directory.GetCurrentDirectory() + "\\Sybaris\\UnityInjector\\Config\\PropMyItem.xml";
			this.Save(filePath);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003464 File Offset: 0x00001664
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

		// Token: 0x04000037 RID: 55
		private List<string> _targetBGList = new List<string>();

		// Token: 0x04000038 RID: 56
		private List<SMenuInfo> _menuItems = new List<SMenuInfo>();

		// Token: 0x04000039 RID: 57
		private static Config _config;
	}
}
