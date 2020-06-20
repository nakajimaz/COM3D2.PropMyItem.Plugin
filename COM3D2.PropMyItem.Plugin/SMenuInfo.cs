using System;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x02000009 RID: 9
	public class SMenuInfo
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002F04 File Offset: 0x00001104
		public SMenuInfo()
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002F54 File Offset: 0x00001154
		public SMenuInfo(MenuInfo menuInfo)
		{
			this.ItemName = menuInfo.ItemName;
			this.FileName = menuInfo.FileName;
			this.IconName = menuInfo.IconName;
			this.Priority = menuInfo.Priority;
			this.ColorSetMPN = menuInfo.ColorSetMPN;
			this.ColorSetMenuName = menuInfo.ColorSetMenuName;
			this.MPN = menuInfo.MPN;
		}

		// Token: 0x04000014 RID: 20
		public string ItemName = string.Empty;

		// Token: 0x04000015 RID: 21
		public string FileName = string.Empty;

		// Token: 0x04000016 RID: 22
		public string IconName = string.Empty;

		// Token: 0x04000017 RID: 23
		public float Priority;

		// Token: 0x04000018 RID: 24
		public MPN ColorSetMPN = MPN.Yorime;

		// Token: 0x04000019 RID: 25
		public string ColorSetMenuName = string.Empty;

		// Token: 0x0400001A RID: 26
		public MPN MPN = MPN.Yorime;
	}
}
