using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace WakanyanStudio.Systems.Editor
{
    public class SaveDataCreator : EditorWindow
    {
        // 無効な文字を管理する配列
        private static readonly string[] INVALUD_CHARS =
        {
            " ", "!", "\"", "#", "$",
            "%", "&", "\'", "(", ")",
            "-", "=", "^", "~", "\\",
            "|", "[", "{", "@", "`",
            "]", "}", ":", "*", ";",
            "+", "/", "?", ".", ">",
            ",", "<"
        };

        private const string ItemName = "Waka-nyan StudioTools/Create Save Data(SaveData.cs)"; // コマンド名
        private const string Path = "Assets/Waka-nyanStudio/Scripts/Systems/ConstantsValues/SaveData.cs"; // ファイルパス

        private static readonly string Filename = System.IO.Path.GetFileName(Path); // ファイル名(拡張子あり)

        private static readonly string
            FilenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(Path); // ファイル名(拡張子なし)

        [MenuItem(ItemName)]
        public static void Open()
        {
            GetWindow<SaveDataCreator>("Save Data Creator");
        }

        #region GUI

        private Vector2 _scrollPos = Vector2.zero;

        private static readonly List<string> _nameSpaces = new List<string>();

        private static readonly List<SaveDataVariable> _saveDataVariables = new List<SaveDataVariable>()
        {
            new SaveDataVariable(new VariableType(VariableBaseType.Int), "variable", "0")
        };

        private class VariableType
        {
            public VariableBaseType VariableBase;

            public VariableType AdditionalVariable { get; set; } = null;

            public bool SetNamespace = false;

            /// <summary>
            /// クラス選択時のみ使用
            /// </summary>
            public string ClassName = "ClassName";

            /// <summary>
            /// namespaceがある場合(Class or Enum)
            /// </summary>
            public string NameSpace = "namespace";

            public VariableType(VariableBaseType variableBase)
            {
                VariableBase = variableBase;
            }

            public VariableType(VariableBaseType variableBase, VariableType additionalVariable)
            {
                VariableBase = variableBase;
                AdditionalVariable = additionalVariable;
            }

            public VariableType(VariableBaseType variableBase, string className)
            {
                VariableBase = variableBase;
                ClassName = className;
            }

            public string ToCode()
            {
                switch (VariableBase)
                {
                    default:
                        return $"{VariableTypeStr[VariableBase]}";
                    case VariableBaseType.Class:
                    case VariableBaseType.Enum:
                        return $"{ClassName}";
                    case VariableBaseType.List:
                        return $"{VariableTypeStr[VariableBase]}<{AdditionalVariable?.ToCode()}>";
                }
            }
        }

        private class SaveDataVariable
        {
            public VariableType VariableType { get; private set; } = null;

            public string Name { get; private set; }

            public string DefaultValue { get; set; }

            public SaveDataVariable(VariableType variableType, string name, string defaultValue)
            {
                VariableType = variableType;
                Name = RemoveInvalidChars(name);
                DefaultValue = defaultValue;
            }

            public void SetName(string name)
            {
                Name = RemoveInvalidChars(name);
            }

            public void SetAutomaticDefaultValue()
            {
                switch (VariableType.VariableBase)
                {
                    case VariableBaseType.Class:
                        DefaultValue = $"new {VariableType.ClassName}()";
                        break;
                    case VariableBaseType.List:
                        DefaultValue = $"new {VariableType.ToCode()}()";
                        break;
                }
            }
        }

        private enum VariableBaseType
        {
            Int,
            Float,
            Bool,
            String,
            List,
            Class,
            Enum,
        }

        private static readonly Dictionary<VariableBaseType, string> VariableTypeStr =
            new Dictionary<VariableBaseType, string>()
            {
                {VariableBaseType.Int, "int"},
                {VariableBaseType.Float, "float"},
                {VariableBaseType.Bool, "bool"},
                {VariableBaseType.String, "string"},
                {VariableBaseType.Class, ""},
                {VariableBaseType.List, "List"},
                {VariableBaseType.Enum, ""},
            };

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField($"保存する項目を追加してください");
            EditorGUILayout.Space(20);

            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            for (int i = 0; i < _saveDataVariables.Count; i++)
            {
                InputFiled(i);
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.Space(10);

            if (GUILayout.Button("Add Element")) Add();
            EditorGUILayout.Space(20);

            if (GUILayout.Button("Create")) Create();
            EditorGUILayout.Space(20);
        }

        private void InputFiled(int index)
        {
            SaveDataVariable saveDataVariable = _saveDataVariables[index];

            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField($"Element {index}");
                    if (GUILayout.Button("Remove", GUILayout.Width(55))) Remove(saveDataVariable);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                {
                    saveDataVariable.VariableType.VariableBase =
                        (VariableBaseType) EditorGUILayout.EnumPopup(
                            saveDataVariable.VariableType.VariableBase,
                            GUILayout.Width(80));

                    if (saveDataVariable.VariableType.VariableBase == VariableBaseType.Class
                        || saveDataVariable.VariableType.VariableBase == VariableBaseType.Enum)
                    {
                        saveDataVariable.VariableType.ClassName =
                            EditorGUILayout.TextField(saveDataVariable.VariableType.ClassName);
                    }

                    // Variable Name
                    saveDataVariable.SetName(EditorGUILayout.TextField($"{saveDataVariable.Name}"));

                    switch (saveDataVariable.VariableType.VariableBase)
                    {
                        // Default Value

                        case VariableBaseType.Int:
                            try
                            {
                                saveDataVariable.DefaultValue =
                                    $"{EditorGUILayout.IntField(int.Parse(saveDataVariable.DefaultValue))}";
                            }
                            catch (Exception e)
                            {
                                saveDataVariable.DefaultValue = $"0";
                                // Debug.Log(e);
                                // throw;
                            }

                            break;
                        case VariableBaseType.Float:
                            try
                            {
                                saveDataVariable.DefaultValue =
                                    $"{EditorGUILayout.FloatField(float.Parse(saveDataVariable.DefaultValue))}";
                            }
                            catch (Exception e)
                            {
                                saveDataVariable.DefaultValue = $"0";
                                // Debug.Log(e);
                                // throw;
                            }

                            break;
                        case VariableBaseType.Bool:
                            try
                            {
                                bool result = EditorGUILayout.Toggle(bool.Parse(saveDataVariable.DefaultValue));
                                saveDataVariable.DefaultValue = result ? "true" : "false";
                            }
                            catch (Exception e)
                            {
                                saveDataVariable.DefaultValue = $"false";
                                // Debug.Log(e);
                                // throw;
                            }

                            break;
                        case VariableBaseType.String:
                        case VariableBaseType.Enum:
                            saveDataVariable.DefaultValue = EditorGUILayout.TextField(saveDataVariable.DefaultValue);
                            break;
                        case VariableBaseType.Class:
                        case VariableBaseType.List:
                            saveDataVariable.SetAutomaticDefaultValue();
                            break;
                    }

                    if (saveDataVariable.VariableType.VariableBase == VariableBaseType.Class
                        || saveDataVariable.VariableType.VariableBase == VariableBaseType.Enum)
                        saveDataVariable.VariableType.SetNamespace =
                            EditorGUILayout.Toggle(saveDataVariable.VariableType.SetNamespace);
                }
                EditorGUILayout.EndHorizontal();

                NameSpaceInputField(saveDataVariable.VariableType);

                if (saveDataVariable.VariableType.VariableBase == VariableBaseType.List)
                    SubInputField(saveDataVariable.VariableType, index, 0);
            }
            EditorGUILayout.EndVertical();
        }

        private void NameSpaceInputField(VariableType variableType)
        {
            if (variableType.SetNamespace) variableType.NameSpace = EditorGUILayout.TextField(variableType.NameSpace);
        }

        private void SubInputField(VariableType variableType, int index, int subIndex)
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField($"SubElement {index} - {subIndex}");
                if (variableType.AdditionalVariable == null)
                    variableType.AdditionalVariable = new VariableType(VariableBaseType.Int);

                if (variableType.AdditionalVariable.VariableBase == VariableBaseType.Class)
                {
                    variableType.AdditionalVariable.ClassName =
                        EditorGUILayout.TextField(variableType.AdditionalVariable.ClassName);
                }


                if (variableType.AdditionalVariable.VariableBase == VariableBaseType.Class
                    || variableType.AdditionalVariable.VariableBase == VariableBaseType.Enum)
                    variableType.AdditionalVariable.SetNamespace =
                        EditorGUILayout.Toggle(variableType.AdditionalVariable.SetNamespace);

                variableType.AdditionalVariable.VariableBase =
                    (VariableBaseType) EditorGUILayout.EnumPopup(
                        variableType.AdditionalVariable.VariableBase,
                        GUILayout.Width(80));
            }
            EditorGUILayout.EndHorizontal();

            NameSpaceInputField(variableType.AdditionalVariable);

            subIndex++;

            if (variableType.AdditionalVariable?.VariableBase == VariableBaseType.List)
                SubInputField(variableType.AdditionalVariable, index, subIndex);
        }

        private static void Add()
        {
            _saveDataVariables.Add(new SaveDataVariable(new VariableType(VariableBaseType.Int), "variable", "0"));
        }

        private static void Remove(SaveDataVariable saveDataVariable)
        {
            if (saveDataVariable == null) return;
            if (_saveDataVariables.Count > 1)
            {
                _saveDataVariables.Remove(saveDataVariable);
            }
        }

        #endregion

        /// <summary>
        /// セーブデータ用スクリプトを作成します
        /// </summary>
        public static void Create()
        {
            if (!CanCreate()) return;

            CreateScript();

            EditorUtility.DisplayDialog($"Created {Filename}", $"{Path}\n作成が完了しました", "OK");
        }

        /// <summary>
        /// スクリプトを作成します
        /// </summary>
        public static void CreateScript()
        {
            foreach (SaveDataVariable saveDataVariable in _saveDataVariables)
            {
                VariableType variableType = saveDataVariable.VariableType;
                while (variableType != null)
                {
                    if (!_nameSpaces.Exists(s => s == variableType.NameSpace))
                    {
                        _nameSpaces.Add(variableType.NameSpace);
                    }

                    variableType = variableType.AdditionalVariable;
                }
            }

            var builder = new StringBuilder();

            foreach (string nameSpace in _nameSpaces)
            {
                if (nameSpace != "namespace") builder.AppendLine($"using {nameSpace};");
            }

            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine();
            builder.AppendLine("namespace WakanyanStudio.Systems.ConstantsValues");
            builder.AppendLine("{");
            builder.Append("\t").AppendLine("/// <summary>");
            builder.Append("\t").AppendLine("/// 保存されるデータ");
            builder.Append("\t").AppendLine("/// </summary>");
            builder.Append("\t").AppendLine("[System.Serializable]");
            builder.Append("\t").AppendFormat("public class {0}", FilenameWithoutExtension).AppendLine();
            builder.Append("\t").AppendLine("{");

            foreach (SaveDataVariable saveDataVariable in _saveDataVariables)
            {
                builder.Append("\t").Append("\t")
                    .Append($"public {saveDataVariable.VariableType.ToCode()} {saveDataVariable.Name}")
                    .AppendLine(" { get; private set; }");

                builder.AppendLine(); // メンバ間に見やすいように改行1つ
            }

            builder.Append("\t").Append("\t").AppendLine("public SaveData()");
            builder.Append("\t").Append("\t").AppendLine("{");
            foreach (SaveDataVariable saveDataVariable in _saveDataVariables)
            {
                if (saveDataVariable.VariableType.VariableBase == VariableBaseType.String)
                {
                    builder.Append("\t").Append("\t").Append("\t")
                        .AppendLine($"{saveDataVariable.Name} = \"{saveDataVariable.DefaultValue}\";");
                }
                else if (saveDataVariable.VariableType.VariableBase == VariableBaseType.Enum)
                {
                    builder.Append("\t").Append("\t").Append("\t")
                        .AppendLine(
                            $"{saveDataVariable.Name} = {saveDataVariable.VariableType.ClassName}.{saveDataVariable.DefaultValue};");
                }
                else
                {
                    builder.Append("\t").Append("\t").Append("\t")
                        .AppendLine($"{saveDataVariable.Name} = {saveDataVariable.DefaultValue};");
                }
            }

            builder.Append("\t").Append("\t").AppendLine("}");
            builder.AppendLine();

            builder.Append("\t").Append("\t").Append("public SaveData(");
            builder.Append($"{_saveDataVariables[0]?.VariableType.ToCode()} {_saveDataVariables[0]?.Name}");

            for (int i = 1; i < _saveDataVariables.Count; i++)
            {
                builder.Append(", ")
                    .Append($"{_saveDataVariables[i]?.VariableType.ToCode()} {_saveDataVariables[i]?.Name}");
            }

            builder.AppendLine(")");
            builder.Append("\t").Append("\t").AppendLine("{");
            foreach (SaveDataVariable saveDataVariable in _saveDataVariables)
            {
                builder.Append("\t").Append("\t").Append("\t")
                    .AppendLine($"this.{saveDataVariable.Name} = {saveDataVariable.Name};");
            }

            builder.Append("\t").Append("\t").AppendLine("}");

            builder.Append("\t").AppendLine("}");
            builder.AppendLine("}");

            var directoryName = System.IO.Path.GetDirectoryName(Path);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            File.WriteAllText(Path, builder.ToString(), Encoding.UTF8);
            AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
        }

        /// <summary>
        /// シーン名を定数で管理するクラスを作成できるかどうかを取得します
        /// </summary>
        [MenuItem(ItemName, true)]
        public static bool CanCreate()
        {
            return !EditorApplication.isPlaying && !Application.isPlaying && !EditorApplication.isCompiling;
        }

        /// <summary>
        /// 無効な文字を削除します
        /// </summary>
        public static string RemoveInvalidChars(string str)
        {
            Array.ForEach(INVALUD_CHARS, c => str = str.Replace(c, string.Empty));
            return str;
        }
    }
}