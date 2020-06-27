using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x02000004 RID: 4
	public class CommonUtil
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000022A4 File Offset: 0x000004A4
		public static void Log(string text)
		{
			try
			{
				Console.WriteLine(string.Format("{0}({1}) : {2}", "PropMyItem", "2.3.0.0", text));
			}
			catch
			{
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000022E0 File Offset: 0x000004E0
		public static string WildCardMatchEvaluator(Match match)
		{
			string value = match.Value;
			if (value.Equals("?"))
			{
				return ".";
			}
			if (value.Equals("*"))
			{
				return ".*";
			}
			return Regex.Escape(value);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002320 File Offset: 0x00000520
		public static Maid GetVisibleMaid(int index)
		{
			Maid result = null;
			try
			{
				List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
				if (visibleMaidList.Count > index)
				{
					result = visibleMaidList[index];
				}
			}
			catch (Exception ex)
			{
				CommonUtil.Log(ex.ToString());
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002368 File Offset: 0x00000568
		public static List<Maid> GetVisibleMaidList()
		{
			List<Maid> list = new List<Maid>();
			CharacterMgr characterMgr = GameMain.Instance.CharacterMgr;
			int maidCount = characterMgr.GetMaidCount();
			for (int i = 0; i < maidCount; i++)
			{
				Maid maid = characterMgr.GetMaid(i);
				if (maid != null && maid.isActiveAndEnabled && maid.Visible)
				{
					list.Add(maid);
				}
			}
			int stockMaidCount = characterMgr.GetStockMaidCount();
			for (int j = 0; j < stockMaidCount; j++)
			{
				Maid stockMaid = characterMgr.GetStockMaid(j);
				if (stockMaid != null && stockMaid.isActiveAndEnabled && stockMaid.Visible && !list.Contains(stockMaid))
				{
					list.Add(stockMaid);
				}
			}
			return list;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000241C File Offset: 0x0000061C
		public static string GetSelectedMenuFileName(MPN? mpn, Maid maid)
		{
			string result = string.Empty;
			if (mpn != null)
			{
				MPN? mpn2 = mpn;
				MPN mpn3 = MPN.set_maidwear;
				if (!(mpn2.GetValueOrDefault() == mpn3 & mpn2 != null))
				{
					mpn2 = mpn;
					mpn3 = MPN.set_mywear;
					if (!(mpn2.GetValueOrDefault() == mpn3 & mpn2 != null))
					{
						mpn2 = mpn;
						mpn3 = MPN.set_underwear;
						if (!(mpn2.GetValueOrDefault() == mpn3 & mpn2 != null))
						{
							result = maid.GetProp(mpn.Value).strFileName;
						}
					}
				}
			}
			return result;
		}
	}
}
