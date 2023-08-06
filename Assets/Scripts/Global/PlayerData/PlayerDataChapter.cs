using System.Collections.Generic;
public class PlayerDataChapter
{
    private int _currentChapter = 3;
    private int _maxWave = 42;
    private List<ChapterCases> _cases = new();
}

class ChapterCases
{
    public int ChapterID = 0;
    public int CasesID = 0;
}
