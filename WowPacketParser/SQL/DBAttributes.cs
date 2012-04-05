﻿using System;
using System.Text;

namespace WowPacketParser.SQL
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DBFieldNameAttribute : Attribute
    {
        public readonly string Name;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private int _count;

        public DBFieldNameAttribute(string name)
        {
            Name = name;
            Count = 1;
        }

        public override string ToString()
        {
            if (Count == 1)
                return Name;

            var result = new StringBuilder();
            for (var i = 1; i <= _count; i++)
            {
                result.Append(Name);
                result.Append(i);
                if (i != _count)
                    result.Append(",");
            }
            return result.ToString();
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DBTableNameAttribute : Attribute
    {
        public readonly string Name;

        public DBTableNameAttribute(string name)
        {
            Name = name;
        }
    }
}