using System;
using System.Linq;
using Nekko.UI.Element;
using UnityEngine;
using static Nekko.UI.UIScript.ElementKey;

namespace Nekko.UI
{
    public class UIAssembler: MonoBehaviour
    {
        [SerializeField] private UIScript CurrentUIScript;
        
        public void ReadFile(string path)
        {
             var txt = (TextAsset)Resources.Load(path, typeof(TextAsset));
             var lines = txt.text
                 .Split("\n")
                 .Select(line => line.Trim())
                 .Where(line => !string.IsNullOrEmpty(line))
                 .ToArray();

            CurrentUIScript = new UIScript();
            
            UIGroupElement currentGroup = null;
            
            foreach (var line in lines)
            {
                if (line.StartsWith("GROUP"))
                {
                    var groupName = line.Split(' ')[1];
                    currentGroup = new UIGroupElement
                    {
                        Name = groupName
                    };
                    CurrentUIScript.Groups.Add(currentGroup);
                }
                else if (line.StartsWith("DEFAULTGROUP"))
                {
                    var defaultGroupName = line.Split(' ')[1];
                    currentGroup = CurrentUIScript.Groups.FirstOrDefault(group => group.Name == defaultGroupName);
                }
                else
                {
                    if (currentGroup == null) return;
                    var data = line.Split(' ');
                    if (data.Length != 2) continue;
                    Debug.Log(line);
                    var itemKey = data[0];
                    var itemValue = data[1];
                    UIElement item = null;
                    switch (itemKey)
                    {
                        case Image:
                            item = new UIImageElement
                            {
                                Id = itemValue,
                                Type = UIElementType.Image
                            };
                            break;
                        case Edit:
                            Debug.Log("Created UIEditElement");
                            item = new UIEditElement
                            {
                                Id = itemValue,
                                Type = UIElementType.Edit
                            };
                            break;
                        default:
                            break;
                    }
                    if (item is null) continue;
                    lines = IterateAttributes(lines, nextLine =>
                    {
                        var key = nextLine.Split(' ')[0];
                        var value = nextLine.Split(' ')[1];
                        key = key.Replace("-", "");
                        item.SetAttribute(key, value);
                    });
                    currentGroup.Elements.Add(item);
                }
            }
            DebugCurrent();
        }

        public void DebugCurrent()
        {
            foreach (var group in CurrentUIScript.Groups)
            {
                Debug.Log($"GroupName {group.Name} Elements ({group.Elements.Count})");
                foreach (var element in group.Elements)
                {
                    Debug.Log($"- {element.Id} ({element.Type})");
                }
            }
        }
        
        private static string[] IterateAttributes(string[] lines, Action<string> callback)
        {
            while (true)
            {
                var nextLine = lines.First();
                lines = lines.Skip(1).ToArray();
                if (string.IsNullOrEmpty(nextLine) || nextLine == "-END")
                {
                    lines = lines.Skip(1).ToArray();
                    break;
                }
                callback(nextLine);
            }

            return lines;
        }
        
        public UIScript CurrentUI => CurrentUIScript;
    }
}