using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ExcelDataViewer
{
    public class SettingsController
    {
        public class Filter
        {
            public string Column { get; set; }
            public RowCell RowCell { get; set; }
            public RowArguments RowArguments { get; set; }
            public CellArguments CellArguments { get; set; }
            public string FilterWord { get; set; }
            public string ApplyToCol { get; set; }
            public string Value { get; set; }
            public bool ExactMatch { get; set; }
            public bool Negate { get; set; }

            public Filter(RowArguments rowArguments, string column, string filterWord, string value, bool exactMatch, bool negate)
            {
                RowCell = RowCell.Row;
                Column = column;
                RowArguments = rowArguments;
                FilterWord = filterWord;
                Value = value;
                ExactMatch = exactMatch;
                Negate = negate;
            }

            public Filter(CellArguments cellArguments, string column, string filterWord, string applyToCol, string value, bool exactMatch, bool negate)
            {
                RowCell = RowCell.Cell;
                Column = column;
                CellArguments = cellArguments;
                FilterWord = filterWord;
                ApplyToCol = applyToCol;
                Value = value;
                ExactMatch = exactMatch;
                Negate = negate;
            }
        }

        public enum RowCell : int
        {
            Row = 1,
            Cell = 2
        }

        public enum RowArguments : int
        {
            Hide = 1,
            Colour = 2
        }

        public enum CellArguments : int
        {
            Colour = 1
        }

        private readonly MainForm Main;
        public Dictionary<string, bool> EnabledColumns;
        public List<Filter> Filters;
        private readonly string SettingsPath = @"ExcelDataViewer\settings\";


        public SettingsController(MainForm main)
        {
            this.Main = main;
            this.EnabledColumns = Main.GetColumnsEnabledState();
            this.Filters = new List<Filter>();

            LoadExistingSettings();
        }

        private void LoadExistingSettings()
        {
            string filename = Path.GetFileNameWithoutExtension(Properties.Settings.Default.File);
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string settingsPath = Path.Combine(appdata, SettingsPath);
            string settingsFile = Path.Combine(settingsPath, filename);

            if (!Directory.Exists(settingsPath))
            {
                Directory.CreateDirectory(settingsPath);
            }

            if (File.Exists(settingsFile))
            {
                LoadSettingsFromFile(settingsFile);
            }
        }

        private void LoadSettingsFromFile(string filename)
        {
            string line;
            using (var file = new StreamReader(filename))
            {
                bool firstLine = false;
                while ((line = file.ReadLine()) != null)
                {
                    if (!firstLine)
                    {
                        ParseEnabledColumnsLine(line);
                        firstLine = true;
                    }
                    else
                    {
                        ParseSettingLine(line);
                    }
                }
            }
        }

        private void ParseEnabledColumnsLine(string line)
        {
            foreach (string col in line.Split(','))
            {
                if (EnabledColumns.ContainsKey(col))
                {
                    EnabledColumns[col] = false;
                }
            }
        }

        private void ParseSettingLine(string line)
        {
            string[] args = line.Split(',');
            bool exact = bool.Parse(args[0]);
            bool negate = bool.Parse(args[1]);
            string col = args[2];
            string filterword = args[3];
            switch ((RowCell)int.Parse(args[4]))
            {
                case RowCell.Cell:
                    string effectCol = args[5];
                    switch ((CellArguments)int.Parse(args[6]))
                    {
                        case CellArguments.Colour:
                            Filters.Add(new Filter(CellArguments.Colour, col, filterword, effectCol, args[7], exact, negate));
                            break;
                    }
                    break;
                case RowCell.Row:
                    switch ((RowArguments)int.Parse(args[5]))
                    {
                        case RowArguments.Colour:
                            Filters.Add(new Filter(RowArguments.Colour, col, filterword, args[6], exact, negate));
                            break;
                        case RowArguments.Hide:
                            Filters.Add(new Filter(RowArguments.Hide, col, filterword, "", exact, negate));
                            break;
                    }
                    break;
            }
        }
        
        public void LaunchSettingsForm()
        {
            var settingsForm = new SettingsForm(Main, this);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                EnabledColumns = settingsForm.GetEnableColumnsValues();              
            }

            SaveSettingsToFile();
        }

        private void SaveSettingsToFile()
        {
            string filename = Path.GetFileNameWithoutExtension(Properties.Settings.Default.File);
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string settingsPath = Path.Combine(appdata, SettingsPath);
            string settingsFile = Path.Combine(settingsPath, filename);

            using (var file = new StreamWriter(settingsFile, false))
            {
                List<string> disabledColumns = new List<string>();
                foreach (string col in EnabledColumns.Keys)
                {
                    if (!EnabledColumns[col])
                    {
                        disabledColumns.Add(col);
                    }
                }
                file.WriteLine(string.Join(",", disabledColumns));

                foreach (Filter f in Filters)
                {
                    string rowcell = ((int)f.RowCell).ToString();
                    string exact = f.ExactMatch.ToString();
                    string negate = f.Negate.ToString();
                    string action;
                    switch (f.RowCell)
                    {
                        case RowCell.Cell:
                            action = ((int)f.CellArguments).ToString();
                            switch (f.CellArguments)
                            {
                                case CellArguments.Colour:
                                    file.WriteLine(string.Join(",", new String[] { exact, negate, f.Column, f.FilterWord, rowcell, f.ApplyToCol, action, f.Value }));
                                    break;
                            }
                            break;
                        case RowCell.Row:
                            action = ((int)f.RowArguments).ToString();
                            switch (f.RowArguments)
                            {
                                case RowArguments.Colour:
                                    file.WriteLine(string.Join(",", new string[] { exact, negate, f.Column, f.FilterWord, rowcell, action, f.Value }));
                                    break;
                                case RowArguments.Hide:
                                    file.WriteLine(string.Join(",", new string[] { exact, negate, f.Column, f.FilterWord, rowcell, action }));
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}
