using Systems.SaveSystems;

namespace RaraMagi.Systems
{
    public class SaveController : AbstractSaveDataController
    {
        public static void SetChapter(int chapter, bool save = true)
        {
            data.chapter = chapter;
            if (save) Save();
        }

        public static void SetChapterChara(CharacterNames character, bool save = true)
        {
            data.chapterChara = character;
            if (save) Save();
        }
    }
}