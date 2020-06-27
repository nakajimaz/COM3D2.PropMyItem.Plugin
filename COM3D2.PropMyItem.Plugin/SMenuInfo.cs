using System;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x02000008 RID: 8
	public class SMenuInfo
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002D14 File Offset: 0x00000F14
		public SMenuInfo()
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002D64 File Offset: 0x00000F64
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

		// Token: 0x04000011 RID: 17
		public string ItemName = string.Empty;

		// Token: 0x04000012 RID: 18
		public string FileName = string.Empty;

		// Token: 0x04000013 RID: 19
		public string IconName = string.Empty;

		// Token: 0x04000014 RID: 20
		public float Priority;

		// Token: 0x04000015 RID: 21
		public MPN ColorSetMPN = MPN.head;

		// Token: 0x04000016 RID: 22
		public string ColorSetMenuName = string.Empty;

		// Token: 0x04000017 RID: 23
		public MPN MPN = MPN.head;
	}
}
