using System.Collections.Generic;

namespace CSharptoScratch
{
    internal class ParsedScratchProject
    {
        public ParsedCSharpClass SourceClass { get; set; } = new ParsedCSharpClass();
        public ParsedScratchTarget Stage { get; set; } = new ParsedScratchTarget { IsStage = true, Name = "Stage" };
        public List<ParsedScratchTarget> Sprites { get; } = new List<ParsedScratchTarget>();
    }

    internal class ParsedCSharpClass
    {
        public string Namespace { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public List<ParsedCSharpMethod> Methods { get; } = new List<ParsedCSharpMethod>();
    }

    internal class ParsedCSharpMethod
    {
        public string Name { get; set; } = string.Empty;
        public List<ParsedStatement> Statements { get; } = new List<ParsedStatement>();
    }

    internal class ParsedStatement
    {
        public string OriginalText { get; set; } = string.Empty;
        public ParsedScratchBlock? ScratchBlock { get; set; }
    }

    internal class ParsedScratchTarget
    {
        public bool IsStage { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ParsedScratchScript> Scripts { get; } = new List<ParsedScratchScript>();
    }

    internal class ParsedScratchScript
    {
        public string EventName { get; set; } = string.Empty;
        public List<ParsedScratchBlock> Blocks { get; } = new List<ParsedScratchBlock>();
    }

    internal class ParsedScratchBlock
    {
        public string Opcode { get; set; } = string.Empty;
        public Dictionary<string, object> Inputs { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> Fields { get; } = new Dictionary<string, object>();
        public ParsedScratchBlock? Next { get; set; }
    }
}
