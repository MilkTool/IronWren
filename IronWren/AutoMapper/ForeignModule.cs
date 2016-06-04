﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace IronWren.AutoMapper
{
    /// <summary>
    /// Represents a Wren module that was generated by the <see cref="AutoMapper"/>.
    /// </summary>
    internal sealed class ForeignModule
    {
        private readonly Dictionary<string, ForeignClass> classes = new Dictionary<string, ForeignClass>();

        private readonly StringBuilder source = new StringBuilder();

        /// <summary>
        /// Gets the <see cref="ForeignClass"/>es that are part of the module.
        /// </summary>
        public ReadOnlyDictionary<string, ForeignClass> Classes { get; }

        /// <summary>
        /// Gets whether the module's source has been used.
        /// </summary>
        public bool Used { get; private set; }

        public ForeignModule()
        {
            Classes = new ReadOnlyDictionary<string, ForeignClass>(classes);
        }

        public void Add(Type type)
        {
            var foreignClass = new ForeignClass(type);
            classes.Add(foreignClass.Name, foreignClass);

            source.AppendLine(foreignClass.Source);
        }

        public string GetSource()
        {
            Used = true;

            return source.ToString();
        }
    }
}