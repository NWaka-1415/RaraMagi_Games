using RaraMagi.Systems;
using System.Collections.Generic;

namespace WakanyanStudio.Systems.ConstantsValues
{
	/// <summary>
	/// 保存されるデータ
	/// </summary>
	[System.Serializable]
	public class SaveData
	{
		public int chapter;

		public CharacterNames chapterChara;

		public int currentLineIndex;

		public SaveData()
		{
			chapter = 0;
			chapterChara = CharacterNames.All;
			currentLineIndex = 0;
		}
	}
}
