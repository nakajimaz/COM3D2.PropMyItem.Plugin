using System;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x02000007 RID: 7
	public static class EnumUtil
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002119 File Offset: 0x00000319
		public static T Parse<T>(string value)
		{
			return EnumUtil.Parse<T>(value, true);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002122 File Offset: 0x00000322
		public static T Parse<T>(string value, bool ignoreCase)
		{
			return (T)((object)Enum.Parse(typeof(T), value, ignoreCase));
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000213A File Offset: 0x0000033A
		public static bool TryParse<T>(string value, out T result)
		{
			return EnumUtil.TryParse<T>(value, true, out result);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002A38 File Offset: 0x00000C38
		public static bool TryParse<T>(string value, bool ignoreCase, out T result)
		{
			bool result2;
			try
			{
				result = (T)((object)Enum.Parse(typeof(T), value, ignoreCase));
				result2 = true;
			}
			catch
			{
				result = default(T);
				result2 = false;
			}
			return result2;
		}
	}
}
