using System;
using System.Collections.Generic;
using UnityEngine;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x02000009 RID: 9
	public class MenuInfo
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002E08 File Offset: 0x00001008
		public MenuInfo()
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002E8C File Offset: 0x0000108C
		public MenuInfo(SMenuInfo menuInfo)
		{
			this.ItemName = menuInfo.ItemName;
			this.FileName = menuInfo.FileName;
			this.IconName = menuInfo.IconName;
			this.Priority = menuInfo.Priority;
			this.ColorSetMPN = menuInfo.ColorSetMPN;
			this.ColorSetMenuName = menuInfo.ColorSetMenuName;
			this.MPN = menuInfo.MPN;
		}

		// Token: 0x04000018 RID: 24
		public string ItemName = string.Empty;

		// Token: 0x04000019 RID: 25
		public string FileName = string.Empty;

		// Token: 0x0400001A RID: 26
		public string IconName = string.Empty;

		// Token: 0x0400001B RID: 27
		public float Priority;

		// Token: 0x0400001C RID: 28
		public Texture2D Icon;

		// Token: 0x0400001D RID: 29
		public MPN ColorSetMPN = MPN.head;

		// Token: 0x0400001E RID: 30
		public string ColorSetMenuName = string.Empty;

		// Token: 0x0400001F RID: 31
		public List<MenuInfo> VariationMenuList = new List<MenuInfo>();

		// Token: 0x04000020 RID: 32
		public List<MenuInfo> ColorSetMenuList = new List<MenuInfo>();

		// Token: 0x04000021 RID: 33
		public int ColorNumber;

		// Token: 0x04000022 RID: 34
		public MPN MPN = MPN.head;

		// Token: 0x04000023 RID: 35
		public bool IsMod;

		// Token: 0x04000024 RID: 36
		public bool IsOfficialMOD;

		// Token: 0x04000025 RID: 37
		public bool IsShopTarget;

		// Token: 0x04000026 RID: 38
		public bool IsHave = true;

		// Token: 0x04000027 RID: 39
		public string FilePath = string.Empty;

		// Token: 0x04000028 RID: 40
		public string CategoryName = string.Empty;

		// Token: 0x04000029 RID: 41
		public bool IsFavorite;

		// Token: 0x0400002A RID: 42
		public bool IsColorLock;

		// Token: 0x0400002B RID: 43
		public bool IsError;
	}
}
