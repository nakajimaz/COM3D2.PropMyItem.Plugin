using System;
using System.Collections.Generic;
using System.Linq;

namespace COM3D2.PropMyItem.Plugin
{
	// Token: 0x02000002 RID: 2
	public class AutoShoesHide
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000022F0 File Offset: 0x000004F0
		public AutoShoesHide()
		{
			this.checkMPNs = new MPN[] 
			{	// 변환
MPN.acchat	  ,
MPN.headset	  ,
MPN.wear	  ,
MPN.skirt	  ,
MPN.onepiece  ,
MPN.mizugi	  ,
MPN.bra		  ,
MPN.panz	  ,
MPN.stkg	  

			};
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002348 File Offset: 0x00000548
		public void Update()
		{
			try
			{
				if (UserConfig.Instance.IsAutoShoesHide)
				{
					List<Maid> visibleMaidList = CommonUtil.GetVisibleMaidList();
					if (visibleMaidList.Count != 0)
					{
						string bgname = GameMain.Instance.BgMgr.GetBGName();
						if (!(this._lastBGName == bgname) || this._lastMaidCount != visibleMaidList.Count)
						{
							if (Config.Instance.TargetBGList.Contains(bgname, StringComparer.OrdinalIgnoreCase))
							{
								using (List<Maid>.Enumerator enumerator = visibleMaidList.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										Maid maid = enumerator.Current;
										if (maid.IsAllProcPropBusy)
										{
											return;
										}
										if (maid.GetProp(MPN.shoes).strTempFileName != "_i_shoes_del.menu")
										{
											Menu.SetMaidItemTemp(maid, "_i_shoes_del.menu", true);
											maid.AllProcProp();
										}
									}
									goto IL_189;
								}
							}
							foreach (Maid maid2 in visibleMaidList)
							{
								if (maid2.IsAllProcPropBusy)
								{
									return;
								}
								bool flag = true;
								foreach (MPN mpn in this.checkMPNs)
								{
									MaidProp prop = maid2.GetProp(mpn);
									if (prop.strFileName == prop.strTempFileName)
									{
										flag = false;
										break;
									}
								}
								if (flag && maid2.GetProp(MPN.shoes).strTempFileName == "_i_shoes_del.menu")
								{
									maid2.ResetProp(MPN.shoes, false);
									maid2.AllProcProp();
								}
							}
							IL_189:
							this._lastBGName = bgname;
							this._lastMaidCount = visibleMaidList.Count;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000001 RID: 1
		private string _lastBGName = string.Empty;

		// Token: 0x04000002 RID: 2
		private int _lastMaidCount;

		// Token: 0x04000003 RID: 3
		private MPN[] checkMPNs;

		// Token: 0x02000003 RID: 3
		public class PropFileName
		{
			// Token: 0x06000003 RID: 3 RVA: 0x00002074 File Offset: 0x00000274
			public PropFileName(int rid, string filename, string tmpFileName)
			{
				this.FileNameRID = rid;
				this.FileName = filename;
				this.TempFileName = tmpFileName;
			}

			// Token: 0x04000004 RID: 4
			public int FileNameRID;

			// Token: 0x04000005 RID: 5
			public string FileName;

			// Token: 0x04000006 RID: 6
			public string TempFileName;
		}
	}
}
