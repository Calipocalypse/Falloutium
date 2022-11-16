﻿using Fallotium.IniManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.DdrawIniManager.Models
{
    public class Preset
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ObservableCollection<PresetOption> PresetOptions { get; set; }

        public Preset(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
