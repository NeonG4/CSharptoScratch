using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class CSParser
    {
        string csCode;

        string nameSpace;
        List<string> usingDirectives;
        string bodyCode;
        public CSParser(string csCode)
        {
            this.csCode = csCode;
        }

        private List<string> ResolveUsingDirectives()
        {
            var directives = new List<string>();
            var lines = csCode.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            var remaining = new List<string>();

            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith("using ", StringComparison.Ordinal) && trimmed.EndsWith(";", StringComparison.Ordinal))
                {
                    var directive = trimmed.Substring("using ".Length).Trim().TrimEnd(';').Trim();
                    if (!string.IsNullOrWhiteSpace(directive))
                    {
                        directives.Add(directive);
                    }
                }
                else
                {
                    remaining.Add(line);
                }
            }

            usingDirectives = directives;
            csCode = string.Join(Environment.NewLine, remaining).Trim();
            return directives;
        }

        private string ResolveNamespace(string code)
        {
            var match = Regex.Match(code, @"\bnamespace\s+([A-Za-z_][\w\.]*)");
            if (!match.Success)
            {
                throw new Exception("Namespace not found");
            }

            nameSpace = match.Groups[1].Value;
            var updatedCode = (code.Substring(0, match.Index) + code.Substring(match.Index + match.Length)).Trim();
            csCode = updatedCode;
            return updatedCode;
        }

        private string ResolveBodyCode()
        {
            var match = Regex.Match(csCode, @"\bclass\s+[A-Za-z_][\w]*");
            if (!match.Success)
            {
                throw new Exception("Class not found");
            }

            var braceIndex = csCode.IndexOf('{', match.Index + match.Length);
            if (braceIndex < 0)
            {
                throw new Exception("Class body not found");
            }

            bodyCode = csCode.Substring(braceIndex);
            return bodyCode;
        }

        public ParsedScratchProject Parse()
        {
            ResolveUsingDirectives();

            try
            {
                ResolveNamespace(csCode);
            }
            catch (Exception)
            {
                nameSpace = string.Empty;
            }

            ResolveBodyCode();

            var classNameMatch = Regex.Match(csCode, @"\bclass\s+([A-Za-z_][\w]*)");
            if (!classNameMatch.Success)
            {
                throw new Exception("Class not found");
            }

            var className = classNameMatch.Groups[1].Value;
            var parsedClass = new ParsedCSharpClass
            {
                Namespace = nameSpace ?? string.Empty,
                ClassName = className
            };

            foreach (var method in ParseMethods())
            {
                parsedClass.Methods.Add(method);
            }

            var project = new ParsedScratchProject
            {
                SourceClass = parsedClass
            };

            var spriteTarget = new ParsedScratchTarget
            {
                IsStage = false,
                Name = className
            };

            foreach (var method in parsedClass.Methods)
            {
                if (string.Equals(method.Name, "GreenFlag", StringComparison.Ordinal))
                {
                    var script = new ParsedScratchScript
                    {
                        EventName = "event_whenflagclicked"
                    };
                    foreach (var statement in method.Statements)
                    {
                        script.Blocks.Add(new ParsedScratchBlock { Opcode = "unmapped", Fields = { { "text", statement.OriginalText } } });
                    }
                    spriteTarget.Scripts.Add(script);
                }
            }

            project.Sprites.Add(spriteTarget);
            return project;
        }

        private IEnumerable<ParsedCSharpMethod> ParseMethods()
        {
            var methods = new List<ParsedCSharpMethod>();
            var methodPattern = new Regex(@"\b(?:public|private|protected|internal)?\s*(?:static\s+)?(?:void|[A-Za-z_][\w]*)\s+([A-Za-z_][\w]*)\s*\([^)]*\)\s*\{", RegexOptions.Multiline);
            var matches = methodPattern.Matches(csCode);

            foreach (Match match in matches)
            {
                var methodName = match.Groups[1].Value;
                var bodyStart = csCode.IndexOf('{', match.Index + match.Length - 1);
                if (bodyStart < 0)
                {
                    continue;
                }

                var bodyEnd = FindMatchingBrace(csCode, bodyStart);
                if (bodyEnd < 0)
                {
                    continue;
                }

                var body = csCode.Substring(bodyStart + 1, bodyEnd - bodyStart - 1);
                var parsedMethod = new ParsedCSharpMethod { Name = methodName };

                var statements = body.Split(';');
                foreach (var statement in statements)
                {
                    var trimmed = statement.Trim();
                    if (string.IsNullOrWhiteSpace(trimmed))
                    {
                        continue;
                    }

                    parsedMethod.Statements.Add(new ParsedStatement { OriginalText = trimmed + ";" });
                }

                methods.Add(parsedMethod);
            }

            return methods;
        }

        private static int FindMatchingBrace(string code, int openBraceIndex)
        {
            var depth = 0;
            for (var i = openBraceIndex; i < code.Length; i++)
            {
                if (code[i] == '{')
                {
                    depth++;
                }
                else if (code[i] == '}')
                {
                    depth--;
                    if (depth == 0)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
